using System.Globalization;
using System.Text;
using CsvHelper;
using MatchingApp.Models.Entities;
using Microsoft.Data.SqlClient;
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
                var dataToBeSeed =
                    ReadData(
                        "User_Data.csv").Result; //Send the right path for ApplicationData.csv within Data folder 

                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
                /*
                 * Your code here ...
                 */
            }
        }

        private async Task<List<User>> ReadData(string path)
        {
            List<User> records = new();

            using var stream = new StreamReader(path, Encoding.UTF8);

            while (!stream.EndOfStream)
            {
                try
                {
                    records.Add(await ParseUserData(stream.ReadLine()));
                }
                catch
                {

                }
            }

            return records;
        }

        private async Task<User> ParseUserData(string row)
        {
            var columns = row.Split(",");

            if (columns.Length < 11)
            {
                throw new Exception("Invalid row in csv");
            }

            return new User
            {
                Id = int.Parse(columns[0]),
                Gender = columns[1],
                Age = int.Parse(columns[2]),
                Credits = int.Parse(columns[3]),
                Active = bool.Parse(columns[4])
            };

        }
    }
}
