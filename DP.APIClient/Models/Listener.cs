using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP.APIClient
{
    public class Listener
    {
        public string Name { get; private set; }
        public int TargetNumber { get; private set; }
        public int Counter { get; private set; }

        public Listener(string name, int targetNumber)
        {
            Name = name;
            TargetNumber = targetNumber;
            Counter = 0;
        }

        public void ProcessResult(int result)
        {
            if (result == TargetNumber)
            {
                Counter++;
            }
        }
    }
}
