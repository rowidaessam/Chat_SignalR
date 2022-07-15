using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace signalrchatDay1.Model
{
    public partial class chatContext : DbContext
    {
        public chatContext()
            : base("name=chatContext")
        {
        }

        public virtual DbSet<message> messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
