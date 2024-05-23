using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sample.Data;
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
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        // private List<Activity> activities = new List<Activity>();
        // private List<ActivityApply> activityApplies = new List<ActivityApply>();

        public ActivityService(
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Activity? Get(long prgId)
        {
            return context.Activities.Find(prgId);
        }

        public List<Activity> List()
        {
            return context.Activities.ToList();
        }

        public List<ActivityApply> GetApplies()
        {
            return context.ActivityApplies.ToList();
        }

        public void Remove(long prgId)
        {
            var toDelete = context.Activities
                .Where(x => x.PrgId == prgId)
                .FirstOrDefault();

            context.Activities.Remove(toDelete);

            context.SaveChanges();
        }

        public void Add(Activity activity)
        {
            if (context.Activities.Any(x => x.PrgId == activity.PrgId))
            {
                return;
            }

            context.Activities.Add(activity);

            context.SaveChanges();
        }

        public void Update(Activity activity)
        {
            var targets = context.Activities.Where(x => x.PrgId == activity.PrgId).ToList();

            if (targets.Count != 1)
                return;

            var target = targets.Single();
            target.PrgName = activity.PrgName;
            target.PrgAct = activity.PrgAct;
            target.PrgDate = activity.PrgDate;
            target.OrgName = activity.OrgName;
            target.PrgPlace = activity.PrgPlace;
            target.ItemDesc = activity.ItemDesc;

            context.SaveChanges();
        }

        public void Apply(long prgId, string userName)
        {
            var exist = this.context.ActivityApplies.Any(x => x.PrgId == prgId && x.UserName == userName);

            if (exist)
                return;

            context.ActivityApplies.Add(new ActivityApply() { UserName = userName, PrgId = prgId });

            context.SaveChanges();
        }

        public void CancelApply(long prgId, string userName)
        {
            var exist = context.ActivityApplies.SingleOrDefault(x => x.PrgId == prgId && x.UserName == userName);

            if (exist != null)
            {
                context.ActivityApplies.Remove(exist);
            }

            context.SaveChanges();
        }
    }
}
