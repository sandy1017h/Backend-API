﻿using server.Data;
using server.Entities;
using Microsoft.EntityFrameworkCore;
using server.Interface.Repository;

namespace server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContex contex;

        public UserRepository(DataContex contex) 
        {
            this.contex = contex;
        }

        public async Task<bool> AddUser(User user)
        {
            await this.contex.users.AddAsync(user);
            return await this.contex.SaveChangesAsync() > 0 ? true:false;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.contex.users.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await this.contex.users
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            this.contex.users.Attach(user);
            return await this.contex.SaveChangesAsync() > 0 ? true:false;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await this.contex.users.FindAsync(id);
        }

    }
}
