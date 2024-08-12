using CsvHelper.Configuration;
using CsvHelper;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
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
                var dataToBeSeed = ReadData("./User_Data.csv");

                _applicationDbContext.AddRange(dataToBeSeed);
                _applicationDbContext.Database.OpenConnection();
                try
                {
                    _applicationDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                    _applicationDbContext.SaveChanges();
                    _applicationDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
                }
                finally
                {
                    _applicationDbContext.Database.CloseConnection();
                }

                _applicationDbContext.SaveChanges();

                
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                MissingFieldFound = null
            }))
            {
                records = csv.GetRecords<User>().ToList();
            }

            return records;

        }
    }
}













