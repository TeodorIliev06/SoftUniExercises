namespace TravelAgency.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    using Newtonsoft.Json;

    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using TravelAgency.DataProcessor.ImportDtos;

    using static Common.Utilities;
    using static Common.EntityValidationConstants.Booking;

    public class Deserializer
    {
        private static XmlHelper? xmlHelper;

        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";
        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            var customerDtos = xmlHelper.Deserialize<CustomerImportDto[]>(xmlString, "Customers");

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = context.Customers.Any(c =>
                    c.FullName == customerDto.FullName ||
                    c.Email == customerDto.Email ||
                    c.PhoneNumber == customerDto.PhoneNumber);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customerDto.FullName));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var bookings = new HashSet<Booking>();
            var bookingDtos = JsonConvert.DeserializeObject<BookingImportDto[]>(jsonString);

            foreach (var bookingDto in bookingDtos)
            {
                bool isBookingDateValid = DateTime.TryParseExact(bookingDto.BookingDate, BookingDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                if (!IsValid(bookingDto) || !isBookingDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var booking = new Booking()
                {
                    BookingDate = bookingDate,
                    Customer = context.Customers.First(c => c.FullName == bookingDto.CustomerName),
                    TourPackage = context.TourPackages.First(c => c.PackageName == bookingDto.TourPackageName)
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate));
            }

            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
