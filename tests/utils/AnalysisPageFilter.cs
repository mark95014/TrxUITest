using System;
using System.Collections.Generic;
using System.Text;

namespace TrxUITest.src.tests.utils
{
    public class AnalysisPageFilter
    {
        public string selector;
        public string value;

        public AnalysisPageFilter(string selector, string value)
        {
            this.selector = selector;
            this.value = value;
        }
    }
}
