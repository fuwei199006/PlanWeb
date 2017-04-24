   using System.Data.Entity;
using  Plain.Model.Models.Model.Models.Model;
using   Plain.Model.Models.Model.Models.Mapping;
namespace  Plain.Model.Models.Model
{
    public partial class PlanDbContext : DbContext
    {
        static  PlanDbContext()
        {
            Database.SetInitializer< PlanDbContext>(null);
        }

        public  PlanDbContext(string connectionString):this()
        {
            this.Database.Connection.ConnectionString = connectionString;
        }

        public  PlanDbContext()
        {
           
        }
		public DbSet<Salary> Salary { get; set; }
		public DbSet<Basic_Dictionary> Basic_Dictionary { get; set; }
		public DbSet<Basic_Config> Basic_Config { get; set; }
		public DbSet<Basic_DbMonitorLog> Basic_DbMonitorLog { get; set; }
		public DbSet<Basic_Draft> Basic_Draft { get; set; }
		public DbSet<Basic_Log> Basic_Log { get; set; }
		public DbSet<Basic_LoginInfo> Basic_LoginInfo { get; set; }
		public DbSet<Basic_MainData> Basic_MainData { get; set; }
		public DbSet<Basic_Menu> Basic_Menu { get; set; }
		public DbSet<Basic_MessageBox> Basic_MessageBox { get; set; }
		public DbSet<Basic_Power> Basic_Power { get; set; }
		public DbSet<Basic_PowerMenu> Basic_PowerMenu { get; set; }
		public DbSet<Basic_PowerRole> Basic_PowerRole { get; set; }
		public DbSet<Basic_Register> Basic_Register { get; set; }
		public DbSet<Basic_Role> Basic_Role { get; set; }
		public DbSet<Basic_Task> Basic_Task { get; set; }
		public DbSet<Basic_UserInfo> Basic_UserInfo { get; set; }
		public DbSet<Basic_UserRole> Basic_UserRole { get; set; }
		public DbSet<Basice_ActionHistory> Basice_ActionHistory { get; set; }
		public DbSet<Basic_Commit> Basic_Commit { get; set; }
		public DbSet<Basic_Article> Basic_Article { get; set; }
		      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
		 modelBuilder.Configurations.Add(new SalaryMap());
		modelBuilder.Configurations.Add(new Basic_DictionaryMap());
		modelBuilder.Configurations.Add(new Basic_ConfigMap());
		modelBuilder.Configurations.Add(new Basic_DbMonitorLogMap());
		modelBuilder.Configurations.Add(new Basic_DraftMap());
		modelBuilder.Configurations.Add(new Basic_LogMap());
		modelBuilder.Configurations.Add(new Basic_LoginInfoMap());
		modelBuilder.Configurations.Add(new Basic_MainDataMap());
		modelBuilder.Configurations.Add(new Basic_MenuMap());
		modelBuilder.Configurations.Add(new Basic_MessageBoxMap());
		modelBuilder.Configurations.Add(new Basic_PowerMap());
		modelBuilder.Configurations.Add(new Basic_PowerMenuMap());
		modelBuilder.Configurations.Add(new Basic_PowerRoleMap());
		modelBuilder.Configurations.Add(new Basic_RegisterMap());
		modelBuilder.Configurations.Add(new Basic_RoleMap());
		modelBuilder.Configurations.Add(new Basic_TaskMap());
		modelBuilder.Configurations.Add(new Basic_UserInfoMap());
		modelBuilder.Configurations.Add(new Basic_UserRoleMap());
		modelBuilder.Configurations.Add(new Basice_ActionHistoryMap());
		modelBuilder.Configurations.Add(new Basic_CommitMap());
		modelBuilder.Configurations.Add(new Basic_ArticleMap());
		        }
    }
}
