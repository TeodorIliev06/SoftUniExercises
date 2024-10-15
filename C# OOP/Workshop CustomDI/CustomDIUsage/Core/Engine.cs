using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomDIUsage.Modules.Contracts;

namespace CustomDIUsage.Core
{
    public class Engine
    {
        private IRandomGenerator randomGenerator;

        public Engine(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public void Something()
        {

        }
    }
}
