using KariyerNet.Data.Domain;
using KariyerNet.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data
{
    public class KariyerNetDbContext : IdentityDbContext<User, Role, int>
    {
        public KariyerNetDbContext() : base()
        {

        }
        public KariyerNetDbContext(DbContextOptions<KariyerNetDbContext> options) : base(options)
        {

        }

        public DbSet<AdvertisementApply> AdvertisementApplies { get; set; }
        public DbSet<AdvertisementViewCount> AdvertisementViewCounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        public DbSet<CompanyFollower> CompanyFollowers { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<JobAdvertisement> JobAdvertisements { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<UserCurriculumVitae> UserCurriculumVitae { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<WorkType> WorkType { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AdvertisementApplyMapping());
            builder.ApplyConfiguration(new AdvertisementViewCountMapping());
            builder.ApplyConfiguration(new CityMapping());
            builder.ApplyConfiguration(new CompanyDetailMapping());
            builder.ApplyConfiguration(new CompanyFollowerMapping());
            builder.ApplyConfiguration(new DepartmantMapping());
            builder.ApplyConfiguration(new DrivingLicenseMapping());
            builder.ApplyConfiguration(new EducationLevelMapping());
            builder.ApplyConfiguration(new JobAdvertisementMapping());
            builder.ApplyConfiguration(new NationalityMapping());
            builder.ApplyConfiguration(new PositionMapping());
            builder.ApplyConfiguration(new SectorMapping());
            builder.ApplyConfiguration(new UserCurriculumVitaeMapping());
            builder.ApplyConfiguration(new UserDetailMapping());
            builder.ApplyConfiguration(new WorkTypeMapping());
            builder.ApplyConfiguration(new MessageMapping());
        }
    }
}
