using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolDatabase.Data;
using SchoolDatabase.Models;
using Microsoft.Extensions.Configuration;

namespace SchoolDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<SchoolContext>();

            context.Database.Migrate();
            SeedData(context);

            Console.WriteLine("Database has been updated.");
        }

        public static void SeedData(SchoolContext context)
        {
            if (!context.Groups.Any())
            {
                var groupA = new Group { Name = "Group A" };
                var groupB = new Group { Name = "Group B" };
                context.Groups.AddRange(groupA, groupB);

                var student1 = new Student { FirstName = "Alice", LastName = "Smith", Group = groupA };
                var student2 = new Student { FirstName = "Bob", LastName = "Johnson", Group = groupA };
                var student3 = new Student { FirstName = "Charlie", LastName = "Brown", Group = groupB };
                context.Students.AddRange(student1, student2, student3);

                var teacher1 = new Teacher { FirstName = "Emily", LastName = "Stone" };
                var teacher2 = new Teacher { FirstName = "John", LastName = "Doe" };
                context.Teachers.AddRange(teacher1, teacher2);

                var math = new Subject { Title = "Mathematics" };
                var science = new Subject { Title = "Science" };
                context.Subjects.AddRange(math, science);

                context.SubjectTeachers.AddRange(
                    new SubjectTeacher { Subject = math, Teacher = teacher1 },
                    new SubjectTeacher { Subject = science, Teacher = teacher2 }
                );

                context.Marks.AddRange(
                    new Mark { Student = student1, Subject = math, Date = DateTime.Now, Value = 90 },
                    new Mark { Student = student2, Subject = science, Date = DateTime.Now, Value = 85 },
                    new Mark { Student = student3, Subject = math, Date = DateTime.Now, Value = 78 }
                );

                context.SaveChanges();
                Console.WriteLine("Seeded full data.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<SchoolContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                });
    }
}