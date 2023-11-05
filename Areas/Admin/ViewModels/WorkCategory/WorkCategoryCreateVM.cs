using System.ComponentModel.DataAnnotations;

namespace FrontToBacktask2.Areas.Admin.ViewModels.WorkCategory
{
    public class WorkCategoryCreateVM
    {
        [Required(ErrorMessage="Ad mutleq daxil edilmelidi")]
        public string Name { get; set; }
    }
}
