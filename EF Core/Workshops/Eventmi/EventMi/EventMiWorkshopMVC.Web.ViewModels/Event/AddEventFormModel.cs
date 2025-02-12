namespace EventMiWorkshopMVC.Web.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityConstraints;
    public class AddEventFormModel
    {
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        [StringLength(EventPlaceMaxLength, MinimumLength = EventPlaceMinLength)]
        public string Place { get; set; } = null!;
    }
}
