using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAssignment1.Model;

namespace RazorPagesAssignment1.Data
{
    public class RazorPagesAssignment1Context : DbContext
    {
        public RazorPagesAssignment1Context (DbContextOptions<RazorPagesAssignment1Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAssignment1.Model.Details> Details { get; set; }
    }
}
