   using System.Data.Entity;
using Tool.T4Templent.RuntimePlates.Models.Model;
using  Tool.T4Templent.RuntimePlates.Models.Mapping;
namespace Tool.T4Templent.RuntimePlates
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
		public DbSet<Basic_Role> Basic_Role { get; set; }
		public DbSet<Basic_Menu> Basic_Menu { get; set; }
		public DbSet<Basic_UserRole> Basic_UserRole { get; set; }
		public DbSet<Basic_Power> Basic_Power { get; set; }
		public DbSet<Basic_PowerRole> Basic_PowerRole { get; set; }
		public DbSet<Basic_MainData> Basic_MainData { get; set; }
		public DbSet<Basic_Dictionary> Basic_Dictionary { get; set; }
		public DbSet<Basic_Draft> Basic_Draft { get; set; }
		public DbSet<Basic_Task> Basic_Task { get; set; }
		public DbSet<Basic_MessageBox> Basic_MessageBox { get; set; }
		public DbSet<Basic_Config> Basic_Config { get; set; }
		public DbSet<Log> Log { get; set; }
		public DbSet<Log4net> Log4net { get; set; }
		public DbSet<Basic_LoginInfo> Basic_LoginInfo { get; set; }
		public DbSet<Basic_Register> Basic_Register { get; set; }
		public DbSet<Basic_UserInfo> Basic_UserInfo { get; set; }
		public DbSet<Basic_Article> Basic_Article { get; set; }
		public DbSet<Basic_Commit> Basic_Commit { get; set; }
		      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
		        }
    }
}
