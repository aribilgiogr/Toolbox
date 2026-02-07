using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Test.Fakes
{
    public class FakeDBContext : DbContext
    {
        public FakeDBContext(DbContextOptions<FakeDBContext> options) : base(options)
        {
        }

        public DbSet<FakeEntity> FakeEntities { get; set; }
    }
}
