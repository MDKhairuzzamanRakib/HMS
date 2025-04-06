using Hms.Domain.BasicSetup;
using Hms.Domain.BookingInfos;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.GuestInfos;
using Hms.Domain.HotelInfos;
using Hms.Domain.OrganogramSetup;
using Hms.Domain.PaymentInfos;
using Hms.Domain.RoomInfos;
using Hms.Domain.UserManage;
using Hms.Persistence.Configurations;
using Hms.Persistence.Configurations.BasicSetup;
using Hms.Persistence.Configurations.BookingInfos;
using Hms.Persistence.Configurations.EmployeeInfos;
using Hms.Persistence.Configurations.GuestInfos;
using Hms.Persistence.Configurations.HotelInfos;
using Hms.Persistence.Configurations.OrganogramSetup;
using Hms.Persistence.Configurations.PaymentInfos;
using Hms.Persistence.Configurations.RoomInfos;
using Hms.Persistence.Configurations.UserManage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence
{
    public class HmsDbContext : AuditableDbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region BasicSetup
            modelBuilder.ApplyConfiguration(new BloodGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EyesColorConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new HairColorConfiguration());
            modelBuilder.ApplyConfiguration(new HealthIssueStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MaritalStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RateTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RelationConfiguration());
            modelBuilder.ApplyConfiguration(new ReligionConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            #endregion

            #region BookingInfos
            modelBuilder.ApplyConfiguration(new BookingInfoConfiguration());
            #endregion

            #region EmployeeInfos
            modelBuilder.ApplyConfiguration(new EmpBasicInfoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpJobDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new EmpPersonalInfoConfiguration());
            #endregion

            #region GuestInfos
            modelBuilder.ApplyConfiguration(new GuestInfoConfiguration());
            #endregion

            #region HotelInfos
            modelBuilder.ApplyConfiguration(new HotelFacilityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelInfoConfiguration());
            #endregion

            #region OrganogramSetup
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new DesignationSetupConfiguration());
            modelBuilder.ApplyConfiguration(new DesignationConfiguration());
            #endregion

            #region PaymentInfos
            modelBuilder.ApplyConfiguration(new PaymentStatusConfiguration());
            #endregion

            #region RoomInfos
            modelBuilder.ApplyConfiguration(new RoomFacilityConfiguration());
            modelBuilder.ApplyConfiguration(new RoomInfoConfiguration());
            modelBuilder.ApplyConfiguration(new RoomPricingConfiguration());
            #endregion

            #region UserManage
            modelBuilder.ApplyConfiguration(new AspNetRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetUsersConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetUserRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetRoleClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetUserClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetUserLoginsConfiguration());
            modelBuilder.ApplyConfiguration(new AspNetUserTokensConfiguration());
            #endregion


            base.OnModelCreating(modelBuilder);
        }


        #region BasicSetup
        public virtual DbSet<BloodGroup> BloodGroup { get; set; } = null!;
        public virtual DbSet<CategoryType> CategoryType { get; set; } = null!;
        public virtual DbSet<City> City { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeType { get; set; } = null!;
        public virtual DbSet<EyesColor> EyesColor { get; set; } = null!;
        public virtual DbSet<Gender> Gender { get; set; } = null!;
        public virtual DbSet<HairColor> HairColor { get; set; } = null!;
        public virtual DbSet<HealthIssueStatus> HealthIssueStatus { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentType { get; set; } = null!;
        public virtual DbSet<RateType> RateType { get; set; } = null!;
        public virtual DbSet<Relation> Relation { get; set; } = null!;
        public virtual DbSet<Religion> Religion { get; set; } = null!;
        public virtual DbSet<RoomType> RoomType { get; set; } = null!;
        public virtual DbSet<UserType> UserType { get; set; } = null!;
        #endregion


        #region BookingInfos
        public virtual DbSet<BookingInfo> BookingInfo { get; set; } = null!;
        #endregion

        #region EmployeeInfos
        public virtual DbSet<EmpBasicInfo> EmpBasicInfo { get; set; } = null!;
        public virtual DbSet<EmpJobDetail> EmpJobDetail { get; set; } = null!;
        public virtual DbSet<EmpPersonalInfo> EmpPersonalInfo { get; set; } = null!;
        #endregion

        #region GuestInfos
        public virtual DbSet<GuestInfo> GuestInfo { get; set; } = null!;
        #endregion

        #region HotelInfos
        public virtual DbSet<HotelFacility> HotelFacility { get; set; } = null!;
        public virtual DbSet<HotelInfo> HotelInfo { get; set; } = null!;
        #endregion

        #region OrganogramSetup
        public virtual DbSet<Department> Department { get; set; } = null!;
        public virtual DbSet<Section> Section { get; set; } = null!;
        public virtual DbSet<DesignationSetup> DesignationSetup { get; set; } = null!;
        public virtual DbSet<Designation> Designation { get; set; } = null!;
        #endregion

        #region PaymentInfos
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; } = null!;
        #endregion

        #region RoomInfos
        public virtual DbSet<RoomFacility> RoomFacility { get; set; } = null!;
        public virtual DbSet<RoomInfo> RoomInfo { get; set; } = null!;
        public virtual DbSet<RoomPricing> RoomPricing { get; set; } = null!;
        #endregion

        #region UserManage
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; } = null!;
        #endregion

    }

}
