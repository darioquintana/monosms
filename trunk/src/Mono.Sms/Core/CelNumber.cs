using System;

namespace Mono.Sms.Core
{
    public class CelNumber
    {
        private string codeArea;
        private string number;

        public CelNumber()
        {
        }

        public CelNumber(string codeArea,string number)
        {
            this.codeArea = codeArea;
            this.number = number;
        }

        public string CodeArea
        {
            get { return this.codeArea; }
            set { this.codeArea = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public override string ToString()
        {
            return string.Concat(codeArea, number);
        }
    }
}