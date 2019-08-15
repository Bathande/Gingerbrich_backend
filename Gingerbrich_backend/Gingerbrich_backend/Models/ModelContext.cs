using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gingerbrich_backend.Models;
namespace Gingerbrich_backend.Models
{
    public class ModelContext:DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options): base(options) { }
        public DbSet<Product> Articles { get; set; }
    }
}
