using System.Data.Common;
using Abp.Zero.EntityFramework;
using EM.Authorization.Roles;
using EM.MultiTenancy;
using EM.Users;
using System.Data.Entity;
using EM.Entities;

namespace EM.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EMDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        
        //系统管理
        public virtual IDbSet<InfStation> InfStation { set; get; }
        public virtual IDbSet<InfEmployer> InfEmployer { set; get; }
        public virtual IDbSet<InfStationType> InfStationType { set; get; }
        public virtual IDbSet<InfZone> InfZone { set; get; }

        //车辆管理
        public virtual IDbSet<VehVehicle> VehVehicle { set; get; }
        public virtual IDbSet<VehUseRecord> VehUseRecord { set; get; }
        public virtual IDbSet<VehMaintenance> VehMaintenance { set; get; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EMDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in EMDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of EMDbContext since ABP automatically handles it.
         */
        public EMDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public EMDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
