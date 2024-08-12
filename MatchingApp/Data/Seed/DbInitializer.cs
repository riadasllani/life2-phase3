using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Data.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbInitializer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Initialize()
        {
            try
            {
                if (_applicationDbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _applicationDbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            var dataExisting = _applicationDbContext.Users.Any();
            if (!dataExisting)
            {
                var dataToBeSeed = ReadData("C:\\Users\\Admin\\Desktop\\Task-Exam\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 
                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges(); 
                /*
                 * Your code here ...
                 */
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */ 
            
            //spom kujtohet 

            var lines = File.ReadLines(path);

            foreach (var line in lines.Skip(1))
            {
                var attributes = line.Split(",");
                var newUser = MapToUser(attributes);
                records.Add(newUser);
            }

            return records;
        }

        private User MapToUser(string[] attributes)
        {
            User user = new User();

            user.Id = attributes[0];
            user.Gender = attributes[1];

            if (int.TryParse(attributes[2], out int age))
            {
                user.Age = age;
            }

            if (int.TryParse(attributes[3], out int credits))
            {
                user.Credits = credits;
            }

            if (bool.TryParse(attributes[4], out bool isActive))
            {
                user.IsActive = isActive;
            }

            return user;
        }
    }
}
