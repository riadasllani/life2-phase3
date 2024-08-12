using MatchingApp.Enums;
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
                var dataToBeSeed = ReadData("User_data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                /*
                 * Your code here ...
                 */

                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */

            using var streamReader = new StreamReader(path);


            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                var row = streamReader.ReadLine();

                var columns = row.Split(',');

                var id = columns[0];
                var gender = columns[1] == "Male" ? Gender.Male : Gender.Female;
                var age = int.Parse(columns[2]);
                var credits = int.Parse(columns[3]);
                var active = columns[4] == "1";
                
                records.Add(new User
                {
                    Id = id,
                    Gender = gender,
                    Age = age,
                    Credits = credits,
                    Active = active
                });
            }

            return records;
        }
    }
}
