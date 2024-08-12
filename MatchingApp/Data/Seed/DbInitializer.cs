using CsvHelper;
using MatchingApp.Data.Repository;
using MatchingApp.Data.UnitOfWork;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MatchingApp.Data.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IUnitOfWork _unitofwork;

        public DbInitializer(ApplicationDbContext applicationDbContext, IUnitOfWork unitofwork)
        {
            _applicationDbContext = applicationDbContext;
            _unitofwork = unitofwork;
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
                var dataToBeSeed = ReadData("C:\\Users\\Qamko\\Source\\Repos\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                /*
                 * Your code here ...
                 */
                
                _applicationDbContext.Users.AddRange(dataToBeSeed);
                //_applicationDbContext.SaveChanges();

            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var getRecords = csv.GetRecords<User>();
                records = getRecords.ToList();
            }

            return records;
        }
    }
}
