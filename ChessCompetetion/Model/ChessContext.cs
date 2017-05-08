using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessCompetetion.Model
{
    public class ChessContext : DbContext
    {
        public ChessContext()
        {

        }
        public ChessContext(DbContextOptions<ChessContext> options)
            : base(options)
        { }
        public DbSet<Player> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=CURSISTE02\SQLEXPRESS;database=ChessCompetetion;trusted_connection=true;");
        }
    }
}
