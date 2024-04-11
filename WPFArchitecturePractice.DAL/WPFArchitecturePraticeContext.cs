using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.DAL
{
    public class WPFArchitecturePraticeContext : DbContext
    {
        // ! 如果更新了表结构，在 程序包管理控制台 里面使用以下语句来更新表：
        //1. 使用 Add-Migration <Description> 去编译生成迁移脚本，脚本会生成从上次的数据库到本次数据库改变所需的语句。
        //2. 使用 update-database 去把运行脚本，把更改正式执行到数据库上。
        //
        // ! 注意，以下操作应被禁止或严格限制：
        //1. 在数据库中调整表结构。因采用 codefirst 开发，所有关于数据库结构的调整都应由代码生成，对数据库的直接操作可能会导致改动无法持久化保存，甚至导致数据库的损坏。
        //2. 手动对 Migrations 文件夹进行任何操作。 Migrations 文件夹作为开发过程的记录和 efcore 脚本执行的重要依据，不应手动修改其中的脚本等内容，如果需要改动，应在 程序包管理控制台 里面使用命令语句进行操作。
        //
        // ! 其他可能会用到的命令：
        //1. 使用 Remove-Migration 从 migration 文件夹的栈中pop最新的一条 migration 记录。
        //2. 使用 update-database <Description> 可以把数据库回滚到指定的某一状态，而迁移脚本不会发生变化。
        //3. 使用 Script-Migration (optional)<Description1> (optional)<Description2> 可以得到一串从 Description1 状态的数据库变更到 Description2 状态的数据库的sql语句。如果没有 Description，则是从0开始到最新版本，只有一个 Description 是从 Description 到最新版本。

        // 声明本数据库中全部的表格
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // 读取配置文件，获取数据库连接字符串，由于使用的是sqlite本地数据库，这里的连接是本地文件路径的选择
            var SqlConnectionStrings = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("SqlConnectionStrings");
            // 获取默认连接字符串，即默认数据库路径
            string DefaultConnectionString = SqlConnectionStrings["DefaultConnectionString"]!;
            // 获取定制化后的连接字符串，即修改过的字符串位置
            string? CustomerConnectionString = SqlConnectionStrings["CustomerConnectionString"];

            // 如果定制化的连接字符串不存在或为空，说明使用默认连接字符串，否则采用自定义路径
            string connectionString= string.IsNullOrEmpty(CustomerConnectionString) ? DefaultConnectionString: CustomerConnectionString;
            // 使用连接字符串连接数据库
            optionsBuilder.UseSqlite(connectionString);
            // 实现关联对象的懒加载，即加载对象的时候不主动加载对象所依赖的对象
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 把所有的的关联外键的默认删除模式设置为 限制删除
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //从当前程序集加载所有的 IEntityTypeConfiguration ，即应用所有对实体类/表的配置（如：是否可为空，外键关系等）
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
