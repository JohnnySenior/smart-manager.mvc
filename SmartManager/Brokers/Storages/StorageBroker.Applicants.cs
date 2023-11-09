//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.EntityFrameworkCore;
using SmartManager.Models.Applicants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async ValueTask<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            await this.Applicants.AddAsync(applicant);
            await this.SaveChangesAsync();

            return applicant;
        }

        public IQueryable<Applicant> SelectAllApplicants() =>
            this.Applicants.AsQueryable();

        public async ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId) =>
            await this.Applicants.FindAsync(applicantId);

        public async ValueTask<Applicant> UpdateApplicantAsync(Applicant applicant)
        {
            this.Applicants.Update(applicant);
            await this.SaveChangesAsync();

            return applicant;
        }

        public async ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant)
        {
            this.Applicants.Remove(applicant);
            await SaveChangesAsync();

            return applicant;
        }
    }
}

