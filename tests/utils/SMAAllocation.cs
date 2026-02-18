using System;
using System.Collections.Generic;
using System.Text;

namespace TrxUITest.src.tests.utils
{
    public class SMAAllocation
    {
        public string subclass;
        public string percentage;

        public SMAAllocation(string subclass, string percentage)
        {
            this.subclass = subclass;
            this.percentage = percentage;
        }
    }
}