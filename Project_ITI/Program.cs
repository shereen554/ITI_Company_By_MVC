using Microsoft.EntityFrameworkCore;
using Project_ITI.Models;
using Project_ITI.Reposatry;

namespace Project_ITI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // علشان services بيحتاج tools فبديلو tools قبل 
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            // بعرفو انا عاوزه اني dbContext => (ITIContext)----بياخد مني Func--- (SQl Server) بعرفها انا عاوزه اشتغل علي اي اللي هو 
            builder.Services.AddDbContext<ITIContext>(option =>
            {
                                    // بحدد هنا الكونكشن استرنج وبجيب من app setting 
                                    //لازم اعمل الحجات دي قبل ما يبيلد 
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            //Custom Servecis
            builder.Services.AddScoped<IDepartmentReposatry, DepartmentReposatry>();
            builder.Services.AddScoped<ICourseReposatry, CourseReposatry>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
