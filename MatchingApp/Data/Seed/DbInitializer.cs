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
                string path = @"C:\Users\djell\Desktop\LifeExam\MatchingApp\User_Data.csv";
                var dataToBeSeed = ReadData(path); //Send the right path for ApplicationData.csv within Data folder 


                /*
                 * Your code here ...
                 */
                try
                {

                    _applicationDbContext.Users.AddRange(dataToBeSeed);
                    _applicationDbContext.SaveChanges();
                    var data = dataToBeSeed;
                } catch(Exception ex)
                {

                }
            }
        }

        public List<User> ReadData(string path)
        {
           // List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */
             var records = File.ReadAllLines(path)
                .Skip(1)
                .Select(x => x.Split(","))
                .Select(x => new User
                {
                      Id = x[0],
                      Gender = x[1],
                      Age = int.Parse(x[2]),
                      Credits = int.Parse(x[3]),
                      Active = int.Parse(x[4]) == 1,
                });

            var users = records.ToList();

            return users;
        }
    }
}
