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
                var dataToBeSeed = ReadData("C:\\Users\\AURON\\Desktop\\life2-phase3\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 


                /*
                * Your code here ...
                */
                _applicationDbContext.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
            }
        }
        

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var values = line.Split(",");

                var users = new User()
                {
                    Id = values[0],
                    Gender = values[1],
                    Age = int.Parse(values[2]),
                    Credits = int.Parse(values[3]),
                    Active = bool.Parse(values[4]),

                };
                records.Add(users);

                /*
                 * Your code here ...
                 * You MUST use csv helper
                 */




            }
            return records;
        }
    }
}
