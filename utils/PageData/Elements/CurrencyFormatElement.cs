using System;
using System.Collections.Generic;
using System.Text;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class CurrencyFormatElement : TextElement
    {

        public CurrencyFormatElement(string selector): base(selector) {
            TextModifiers modifiers = new TextModifiers("(\\$[\\d,]*(\\.\\d{2})|—)");
        }
    }
}