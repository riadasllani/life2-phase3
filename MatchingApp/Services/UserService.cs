using MatchingApp.Data;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Principal;

namespace MatchingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = _unitOfWork.Repository<User>().GetAll();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Repository<User>().GetById(n => n.Id == id).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task AddAsync(User user)
        {
            _unitOfWork.Repository<User>().Create(user);
            _unitOfWork.Complete();
        }

        public async Task UpdateAsync(User user)
        {
            _unitOfWork.Repository<User>().Update(user);
            _unitOfWork.Complete();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetById(u => u.Id == id).FirstOrDefaultAsync();

            _unitOfWork.Repository<User>().Delete(user);
            _unitOfWork.Complete();
        }

        public async Task<IEnumerable<User>> GetTopUsersAsync(int page, int pageSize)
        {

            var users = await _unitOfWork.Repository<User>().GetAll()
                .OrderByDescending(u => u.Credits)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<User>> GetYoungAndOldUsersAsync(int page, int pageSize)
        {

            var users = await _unitOfWork.Repository<User>().GetAll()
                .Include(u => u.Active)
                .OrderByDescending(u => u.Age)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }

        //public async Task<IEnumerable<User>> GetAverageUsers(User user)
        //{

        //    var users = await _unitOfWork.Repository<User>().GetAll()
        //        .Include(u => u.Gender)
        //        .Average(u => u.Credits)
        //        .ToString();


        //    return users;
        //}

    }
}

