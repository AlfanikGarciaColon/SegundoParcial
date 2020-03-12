using Microsoft.EntityFrameworkCore;
using SegundoParcialAplicada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialAplicada.Data
{
    public class Contexto: DbContext
    {
        public DbSet<Calls> Calls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DataBase/LlamadaBD.db");
        }
    }
}
