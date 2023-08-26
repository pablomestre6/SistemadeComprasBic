using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeComprasBic.Models;

    public class SistemadeComprasBicContext : DbContext
    {
        public SistemadeComprasBicContext (DbContextOptions<SistemadeComprasBicContext> options)
            : base(options)
        {
        }

        public DbSet<SistemadeComprasBic.Models.DepartamentModel> DepartamentModel { get; set; } = default!;

        public DbSet<SistemadeComprasBic.Models.ReceiptNF> ReceiptNF { get; set; } = default!;

        public DbSet<SistemadeComprasBic.Models.SuppliersRegistration> SuppliersRegistration { get; set; } = default!;

        public DbSet<SistemadeComprasBic.Models.RequestModel> RequestModel { get; set; } = default!;
    }
