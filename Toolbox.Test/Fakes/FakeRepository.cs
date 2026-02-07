using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Toolbox.Test.Fakes
{
    public class FakeRepository : Repository<FakeEntity>
    {
        public FakeRepository(FakeDBContext context) : base(context)
        {
        }
    }
}
