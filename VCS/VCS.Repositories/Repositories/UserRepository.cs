﻿using Microsoft.EntityFrameworkCore;
using VCS.Entities.Context;
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCS.Repositories.Repositories {
    public class UserRepository(VCSDbContext cIDbContext) : IUserRepository {
        private readonly VCSDbContext _cIDbContext = cIDbContext;

        public async Task<string> DeleteUser(int id) {
            var user = await _cIDbContext.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) throw new Exception("User not exist");

            user.IsDeleted = true;
            user.ModifiedDate = DateTime.UtcNow;
            _cIDbContext.User.Update(user);
            await _cIDbContext.SaveChangesAsync();
            return "User deleted!";
        }

        public async Task<UserResponseModel> GetUserById(int id) {
            var user = await _cIDbContext.User.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

            if (user == null) throw new Exception("User not exist");

            return new UserResponseModel() {
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
            };
        }

        public async Task<List<UserResponseModel>> GetAllUsers() {
            return await _cIDbContext.User.Where(u => !u.IsDeleted)
                .Select(user => new UserResponseModel() {
                    EmailAddress = user.EmailAddress,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    UserType = user.UserType
                }).ToListAsync();
        }
    }
}
