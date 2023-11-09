//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.EntityFrameworkCore;
using SmartManager.Models.Groups;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Group> Groups { get; set; }

        public async ValueTask<Group> InsertGroupAsync(Group group)
        {
            await this.Groups.AddAsync(group);
            await this.SaveChangesAsync();

            return group;
        }

        public IQueryable<Group> SelectAllGroups() =>
            this.Groups.AsQueryable();

        public async ValueTask<Group> SelectGroupByIdAsync(Guid groupId) =>
            await this.Groups.FindAsync(groupId);

        public async ValueTask<Group> UpdateGroupAsync(Group group)
        {
            this.Groups.Update(group);
            await this.SaveChangesAsync();

            return group;
        }

        public async ValueTask<Group> DeleteGroupAsync(Group group)
        {
            this.Groups.Remove(group);
            await SaveChangesAsync();

            return group;
        }
    }
}
