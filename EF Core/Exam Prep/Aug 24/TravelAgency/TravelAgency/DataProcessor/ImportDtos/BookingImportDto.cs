namespace TravelAgency.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using static Common.EntityValidationConstants.Customer;
    using static Common.EntityValidationConstants.TourPackage;

    public class BookingImportDto
    {
        [Required]
        [JsonProperty]
        public string BookingDate { get; set; } = null!;

        [Required]
        [JsonProperty]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string CustomerName { get; set; } = null!;

        [Required]
        [JsonProperty]
        [StringLength(PackageNameMaxLength, MinimumLength = PackageNameMinLength)]
        public string TourPackageName { get; set; } = null!;
    }
}
