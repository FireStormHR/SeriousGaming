using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCalculatingGame
{
    class Calc
    {
        public Calc(int level)
        {
            Level = level;
            SomAnswer = Som();
        }

        private int SomAnswer { get; }
        private static Random random = new Random();
        private int Level { get; }

        public string StringSom { get; set; }

        public int Som()
        {
            string operator_ = "";
            int returnInt = 0;

            int maxAllowedNumber = 9999999;

            if (this.Level == 1 || this.Level == 3)
                maxAllowedNumber = 9;
            else if (this.Level == 2)
                maxAllowedNumber = 99;

            int firstNumber = random.Next(1, maxAllowedNumber);
            int secondNumber = 9999999;  // assigned based on operator

            double operatorInt = random.Next(0, 1); // 0(-) or 1(+)

            if (this.Level == 3)
                operatorInt = random.Next(0, 2); // can either be 0(-), 1(+), 2(*) or 3(:)

            if (operatorInt <= 1)
            {
                if (operatorInt == 0) // -
                {
                    operator_ = " - ";
                    secondNumber = random.Next(0, firstNumber);
                    returnInt = firstNumber - secondNumber;
                }
                else // +
                {
                    operator_ = " + ";
                    maxAllowedNumber = maxAllowedNumber - firstNumber;
                    secondNumber = random.Next(0, maxAllowedNumber);
                    returnInt = firstNumber + secondNumber;
                }

                StringSom = firstNumber.ToString() + operator_ + secondNumber.ToString() + " = ?"; // 9 - 7 = ? 
            }

            else
            {
                secondNumber = random.Next(0, 9);
                returnInt = secondNumber;

                if (operatorInt == 2) // x
                {
                    operator_ = " x ";
                    StringSom = firstNumber.ToString() + operator_ + "? = " + (firstNumber * secondNumber).ToString(); // 6 x ? = 24
                }
                else // :
                {
                    operator_ = " : ";
                    StringSom = (firstNumber * secondNumber).ToString() + operator_ + "? = " + firstNumber.ToString(); // 54 : ? = 6
                }
            }

            return returnInt;
        }
    }
}
