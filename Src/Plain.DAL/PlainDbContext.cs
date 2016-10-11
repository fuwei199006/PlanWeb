using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using Core.Config;
using Core.Encrypt;
using Core.Log;
using Core.Service;
using Framework.Contract;
using Framework.DbDrive.EntityFramework;
using Plain.Model.Models;
using Plain.Model.Models.Mapping;

namespace Plain.DAL
{
    public class PlainDbContext : DbContextBase
    {


        public PlainDbContext()
            : base(LocalCachedConfigContext.Current.DaoConfig.BussinessDaoConfig, new LogDbContext())
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PlainDbContext>(null);
            modelBuilder.Configurations.Add(new Basic_RoleMap());
            modelBuilder.Configurations.Add(new Basic_MenuMap());
            modelBuilder.Configurations.Add(new Basic_UserRoleMap());
            modelBuilder.Configurations.Add(new Basic_PowerMap());
            modelBuilder.Configurations.Add(new Basic_PowerRoleMap());
            modelBuilder.Configurations.Add(new Basic_MainDataMap());
            modelBuilder.Configurations.Add(new Basic_DictionaryMap());
            modelBuilder.Configurations.Add(new Basic_DraftMap());
            modelBuilder.Configurations.Add(new Basic_TaskMap());
            modelBuilder.Configurations.Add(new Basic_MessageBoxMap());
            modelBuilder.Configurations.Add(new Basic_ConfigMap());
            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new Log4netMap());
            modelBuilder.Configurations.Add(new Basic_LoginInfoMap());
            modelBuilder.Configurations.Add(new Basic_RegisterMap());
            modelBuilder.Configurations.Add(new Basic_UserInfoMap());
            modelBuilder.Configurations.Add(new Basic_ArticleMap());
            modelBuilder.Configurations.Add(new Basic_CommitMap());

            //这里添加Mapping信息
            base.OnModelCreating(modelBuilder);
        }

        //public static DbSet<Basic_LoginInfo> LoginInfos { get; set; }
        //public static DbSet<Basic_UserInfo> Users { get; set; }
        //public static DbSet<Basic_Role> Roles { get; set; }

    }
}