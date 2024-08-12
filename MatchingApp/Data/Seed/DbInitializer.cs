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
                var dataToBeSeed = ReadData("MatchingApp/User_Data.csv");
                _applicationDbContext.Users.AddRange(dataToBeSeed);

                _applicationDbContext.SaveChanges();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    records.Add(new User
                        {
                            Id = Convert.ToInt32(values[0]),
                            Gender = Convert.ToString(values[1]),
                            Age = Convert.ToInt32(values[2]),
                            Credits = Convert.ToInt32(values[3]),
                            Active = Convert.ToBoolean(values[4])
                        }
                    );
                }
            }
            
            return records;
        }
    }
}
