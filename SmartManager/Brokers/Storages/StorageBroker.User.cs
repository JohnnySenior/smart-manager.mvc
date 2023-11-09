//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.EntityFrameworkCore;
using SmartManager.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user)
        {
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            return user;
        }

        public IQueryable<User> SelectAllUsers() =>
            this.Users.AsQueryable();

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await this.Users.FindAsync(userId);

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            this.Users.Update(user);
            await this.SaveChangesAsync();

            return user;
        }

        public async ValueTask<User> DeleteUserAsync(User user)
        {
            this.Users.Remove(user);
            await SaveChangesAsync();

            return user;
        }

        public ValueTask<User> SelectUserByEmailAndPasswordAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
