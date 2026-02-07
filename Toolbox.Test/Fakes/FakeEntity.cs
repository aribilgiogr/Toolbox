using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Bases;

namespace Toolbox.Test.Fakes
{
    public class FakeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
