using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;

namespace FolheandoBooks.Usuario.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Login> Login { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<User> User { get; set; }
    }
}
