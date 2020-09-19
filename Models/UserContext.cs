using Microsoft.EntityFrameworkCore;

namespace webAuth.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            string superAdminRoleName = "super";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            string superEmail = "super@mail.ru";
            string superPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 2, Name = adminRoleName };
            Role userRole = new Role { Id = 3, Name = userRoleName };
            Role superRole = new Role { Id = 1, Name = superAdminRoleName };

            //Добавляем пользователей
            User adminUser = new User { Id = 2, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User superUser = new User { Id = 1, Email = superEmail, Password = superPassword, RoleId = superRole.Id };
            
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole,superRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, superUser });
            base.OnModelCreating(modelBuilder);
        }

    }
}
