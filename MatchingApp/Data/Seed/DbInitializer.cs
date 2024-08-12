using CsvHelper;
using CsvHelper.Configuration;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;

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
                var dataToBeSeed = ReadData(@"C:\\Users\\PC\\OneDrive\\Desktop\\MatchingProfile\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                if (dataToBeSeed.Any())
                {
                    _applicationDbContext.Users.AddRange(dataToBeSeed);
                    _applicationDbContext.SaveChanges();
                }
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            //using var reader = new StreamReader(path);
            //using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    Delimiter = ",",
              
            //});

            //var recordsFromCsv = csv.GetRecords<User>();
            //records = recordsFromCsv.ToList();
            return records;
        }
    }
}
