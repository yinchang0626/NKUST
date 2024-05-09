using Sample.Models;

namespace Sample.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<Activity> Activities { get; set; } = null!;
        public List<ActivityApply> ActivityApplies { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Filter { get; set; }
        public bool? Apply { get; set; }


        public bool IsApply(Activity activity)
        {
            return ActivityApplies.Any(x => x.UserName == UserName && x.PrgId == activity.PrgId);
        }
    }
}
