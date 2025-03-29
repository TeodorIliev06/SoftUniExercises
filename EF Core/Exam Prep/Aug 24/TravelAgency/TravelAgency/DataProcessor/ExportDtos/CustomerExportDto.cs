namespace TravelAgency.DataProcessor.ExportDtos
{
    public class CustomerExportDto
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public BookingExportDto[] Bookings { get; set; }
    }
}
