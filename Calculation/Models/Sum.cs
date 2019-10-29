using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
# branch test
# added on web
namespace Calculation.Models
{
    public class Sum
    {
        private int _num1 = 0;
        private int _num2 = 0;
        private int _result = 0;
        private string _operator = "+";

        public Sum(int number1, int number2)
        {
            this._num1 = number1;
            this._num2 = number2;
            this.Calulate();
        }

        public int Num1
        {
            get
            {
                return this._num1;
            }
            set
            {
                this._num1 = value;
                this.Calulate();
            }
        }
        public string Num1Display
        {
            get
            {
                return this._num1.ToString();
            }
        }

        public int Num2
        {
            get
            {
                return this._num2;
            }
            set
            {
                this._num2 = value;
                this.Calulate();
            }
        }
        public string Num2Display
        {
            get
            {
                return this._num2.ToString();
            }
        }

        public int Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
        public string ResultDisplay
        {
            get
            {
                return this._result.ToString();
            }
        }

        public string Operator
        {
            get
            {
                return this._operator;
            }
        }

        private void Calulate()
        {
            this._result = this._num1 + this._num2;
        }
    }
}
