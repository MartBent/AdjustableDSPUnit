using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USART_Controller
{
    class Term
    {
        private int exponent;
        private double coeffecient;
        private bool isOutput;
        public Term(int exponent, double coeffecient, bool isOutput)
        {
            this.exponent = exponent;
            this.coeffecient = coeffecient;
            this.isOutput = isOutput;
        }
        public double getCoefficient()
        {
            return coeffecient;
        }
        public void setCoefficient(double coeffecient)
        {
            this.coeffecient = coeffecient;
        }
        public bool getIsOutput()
        {
            return isOutput;
        }
        public int getExponent()
        {
            return exponent;
        }
        public override string ToString()
        {
            double exp = Math.Round(coeffecient, 2);
            string result = "";
            if(coeffecient > 0)
            {
                result += "+ ";
            }
            if(coeffecient != 0)
            {
                result += exp.ToString();
            }
            char symb = isOutput ? 'Y' : 'X';
            result += symb + "^" + exponent + " ";
            return result;
        }
        
    }
}
