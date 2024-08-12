using CsvHelper;
using CsvHelper.Configuration;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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

        public List<User> ReadData(string path)
        {
            List<User> records = new();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
               // csv.Context.TypeConverterCache.AddConverter<DateTime>(new DateTimeConverter());
                var csvRecords = csv.GetRecords<User>().ToList();
                records = csvRecords.ToList();
            }

            return records;
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
                var dataToBeSeed = ReadData("User_Data.csv");

                _applicationDbContext.Users.AddRangeAsync(dataToBeSeed);
                _applicationDbContext.SaveChangesAsync().Wait();
            }
        }
    }
}
