using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sample.Models;
using System.Reflection.Emit;

namespace Sample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sample.Models.Activity> Activities { get; set; } = default!;

        public DbSet<Sample.Models.ActivityApply> ActivityApplies { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ImportActivities();

            base.OnModelCreating(builder);

            void ImportActivities()
            {
                string webRootPath = this.GetService<IWebHostEnvironment>().WebRootPath;
                var str = System.IO.File.ReadAllText(Path.Combine(webRootPath, "高雄活動.json"));
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(str);

                var activities = json
                    .GroupBy(x => x.PrgId)
                    .Select(x => x.ToList().FirstOrDefault())
                    .ToList();

                activities.ForEach(i =>
                {
                    i.Id = activities.IndexOf(i) + 1;
                });

                builder.Entity<Activity>().HasData(activities!);
            }
        }
    }
}
