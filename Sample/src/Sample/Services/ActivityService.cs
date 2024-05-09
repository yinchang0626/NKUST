using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class ActivityService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        private List<Activity> activities = new List<Activity>();
        private List<ActivityApply> activityApplies = new List<ActivityApply>();

        public ActivityService(
            IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;

            string webRootPath = webHostEnvironment.WebRootPath;
            var str = System.IO.File.ReadAllText(Path.Combine(webRootPath, "高雄活動.json"));
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(str)!;

            activities = json
                .GroupBy(x => x.PrgId)
                .Select(x => x.ToList().FirstOrDefault())
                .ToList()!;
        }

        public List<Activity> List()
        {
            return activities;
        }

        public List<ActivityApply> GetApplies()
        {
            return activityApplies;
        }

        public void Remove(long prgId)
        {
            var toDelete = activities.Where(x => x.PrgId == prgId).FirstOrDefault();

            activities.Remove(toDelete);
        }

        public void Add(Activity activity)
        {
            if (activities.Any(x => x.PrgId == activity.PrgId))
            {
                return;
            }

            activities.Add(activity);
        }

        public void Update(Activity activity)
        {
            var targets = activities.Where(x => x.PrgId == activity.PrgId).ToList();

            if (targets.Count != 1)
                return;

            var target = targets.Single();
            target.Id = activity.Id;
            target.PrgName = activity.PrgName;
            target.PrgAct = activity.PrgAct;
            target.PrgDate = activity.PrgDate;
            target.OrgName = activity.OrgName;
            target.PrgPlace = activity.PrgPlace;
            target.ItemDesc = activity.ItemDesc;

        }

        public void Apply(long prgId, string userName)
        {
            var exist = this.activityApplies.Any(x => x.PrgId == prgId && x.UserName == userName);

            if (exist)
                return;

            this.activityApplies.Add(new ActivityApply() { UserName = userName, PrgId = prgId });

        }

        public void CancelApply(long prgId, string userName)
        {
            var exist = this.activityApplies.SingleOrDefault(x => x.PrgId == prgId && x.UserName == userName);

            if (exist != null)
            {
                this.activityApplies.Remove(exist);
            }
        }
    }
}
