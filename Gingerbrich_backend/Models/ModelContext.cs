using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class ModelContext: DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {


        }
        public virtual DbSet<Person> Person { get; set; }
    }
}
