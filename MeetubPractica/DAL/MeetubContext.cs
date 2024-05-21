using MeetubPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetubPractica.DAL
{
    public class MeetubContext : DbContext
    {
        public MeetubContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Speakers>  Speakers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=CA-R214-PC04\\SQLEXPRESS;Database=MeetubDb;Trusted_Connection= True;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}

