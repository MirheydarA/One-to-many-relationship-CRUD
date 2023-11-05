using System.ComponentModel.DataAnnotations;

namespace FrontToBacktask2.Areas.Admin.ViewModels.FeaturedWork
{
    public class FeaturecWorkCreateVM
    {
        [Required, MaxLength(20, ErrorMessage = "max lenght is 20")]
        public string Title { get; set; }

        [MaxLength(20, ErrorMessage = "max lenght is 20")]
        public string Subtitle { get; set; }

        [Required, MaxLength(100, ErrorMessage = "max lenght is 100"), MinLength(10, ErrorMessage = "min lenght is 10")]
        public string Description { get; set; }
    }
}
