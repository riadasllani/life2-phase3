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
                var dataToBeSeed = ReadData("User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                /*
                 * Your code here ...
                 */

                foreach(var user in dataToBeSeed)
                {
                    _applicationDbContext.Users.Add(user);
                }

                
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


            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<User>().ToList();
            }
            /*
                        string filePath = Path.GetFullPath(path);

                        StreamReader reader = new StreamReader(filePath);
                        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HasHeaderRecord = true
                        }))
                        {
                            records = csv.GetRecords<User>().ToList();
                        }*/

            return records;
        }
    }
}
