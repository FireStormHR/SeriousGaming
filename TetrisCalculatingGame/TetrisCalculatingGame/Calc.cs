using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCalculatingGame
{
    public class Calc
    {
        public Calc(int level)
        {
            Level = level;
            SomAnswer = Som();
        }

        public int SomAnswer { get; }
        private static Random random = new Random();
        private int Level { get; }

        public string StringSom { get; set; }

        private int Som()
        {
            string operator_ = "";
            int returnInt = 0;
            int maxAllowedNumber = 9999999;

            if (this.Level == 1 || this.Level == 3)
                maxAllowedNumber = 10; //will result in max 9 in the random generator
            else if (this.Level == 2)
                maxAllowedNumber = 100; //will result in max 100 in the random generator

            int firstNumber = random.Next(1, maxAllowedNumber);
            int secondNumber = 9999999;  // assigned based on operator

            double operatorInt = random.Next(0, 2); // 0(-) or 1(+)

            if (this.Level == 3)
                operatorInt = random.Next(2, 4); // 2(*) or 3(:)

            if (operatorInt <= 1)
            {
                if (operatorInt == 0) // -
                {
                    operator_ = " - ";
                    if (Level == 1)
                    {
                        secondNumber = random.Next(0, firstNumber);
                        StringSom = firstNumber + operator_ + secondNumber + " = ?"; // 9 - 7 = ?                    
                    }                
                    else
                    {
                        secondNumber = random.Next(firstNumber - 9, firstNumber);
                        StringSom = firstNumber + operator_ + "? = " + secondNumber; // 67 + ? = 73
                    }
                    returnInt = firstNumber - secondNumber;
                }
                else // +
                {
                    operator_ = " + ";
                    if (Level == 1)
                    {
                        secondNumber = random.Next(0, 10 - firstNumber);
                        StringSom = firstNumber + operator_ + secondNumber + " = ?"; // 9 - 7 = ?
                        returnInt = firstNumber + secondNumber;
                    }
                    else
                    {
                        maxAllowedNumber = firstNumber + 10;
                        secondNumber = random.Next(firstNumber, maxAllowedNumber);
                        returnInt = secondNumber - firstNumber;
                        StringSom = firstNumber + operator_ + "? = " + secondNumber; // 56 - ? = 52
                    }
                  
                }        
            }

            else
            {
                secondNumber = random.Next(1, 10);
                returnInt = secondNumber;

                if (operatorInt == 2) // x
                {
                    operator_ = " x ";
                    StringSom = firstNumber+ operator_ + "? = " + (firstNumber * secondNumber); // 6 x ? = 24
                }
                else // :
                {
                    operator_ = " : ";
                    StringSom = (firstNumber * secondNumber) + operator_ + "? = " + firstNumber; // 54 : ? = 6
                }
            }

            return returnInt;
        }
    }
}
