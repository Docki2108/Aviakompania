/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace aviakompania
{
    

    public partial class db
    {
        static db _context;

        static public db getInstance()
        {
            if (_context == null)
            {
                _context = new db();
            }
            return _context;
        }

        private db()
            : base("name=db")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<ExitCauses> ExitCauses { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TrafficViewer> TrafficViewer { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
}

*/