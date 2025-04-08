using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskApp
{
    class ClassGeneral
    {
        public ClassGeneral(string deadline, int priority, string category, string name) : base(deadline, priority, category, name)
        {
        }

        public ClassGeneral() : base() { }
    }
}
