 namespace FrontToBacktask2.Areas.Admin.ViewModels.FeaturedWork
{
    public class FeaturedWorkIndexVM
    {
        public FeaturedWorkIndexVM()
        {
            FeaturedWorks = new List<Models.FeaturedWork>();
        }
        public List<Models.FeaturedWork> FeaturedWorks { get; set; }
    }
}
