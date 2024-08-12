using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using MatchingApp;

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

            var dataExisting = _applicationDbContext.Users.AnyAsync();
            if (!dataExisting.Result)
            {
                var dataToBeSeed = ReadData("../User_Data.csv");
                if (dataToBeSeed.Any())
                {
                    _applicationDbContext.Users.AddRange((IEnumerable<User>)dataToBeSeed);
                    _applicationDbContext.SaveChanges();
                }
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            using (var reader = new StreamReader(path))
            {
                // Skip the header
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(",");


                    /*var record = new User
                    {
                        Id = value[0],
                        Gender = value[1],
                        Age = value[2],
                        Credits = value[3],
                        IsActive = value[4]
                    };

                    records.Add(record);*/
                }
            }

            return records;
        }
    }
}




