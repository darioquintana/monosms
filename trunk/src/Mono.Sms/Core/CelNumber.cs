using System;

namespace Mono.Sms.Core
{
    public class CelNumber
    {
        public CelNumber()
        {
        }

        public CelNumber(int codeArea, int number)
        {
            this.codeArea = codeArea;
            this.number = number;
        }

        private int codeArea;
        private int number;

        public int CodeArea
        {
            get { return this.codeArea; }
            set { this.codeArea = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public override string ToString()
        {
            return string.Concat(codeArea.ToString(), number.ToString());
        }
    }
}