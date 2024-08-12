using System.Globalization;
using CsvHelper;
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
                var dataToBeSeed = ReadData(""); //Send the right path for ApplicationData.csv within Data folder 

                /*
                 * Your code here ...
                 */
				_applicationDbContext.Users.AddRange(dataToBeSeed);
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */
			using (var reader = new StreamReader($"{path}/User_Data.csv"))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				records = csv.GetRecords<User>().ToList();
			}

            return records;
        }
    }
}
