using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exp1.Models
{
    public class DataContext : System.Data.Entity.DbContext
    {
        public DataContext() : base("Data Source=DESKTOP-Q383BPG;Initial Catalog=yogesh;Persist Security Info=True;User ID=sa;Password=mohananuj93;MultipleActiveResultSets=True;Application Name=EntityFramework")
            {
            
            }
            public System.Data.Entity.DbSet<Register> Registers {get;set;}
            
    } 
}