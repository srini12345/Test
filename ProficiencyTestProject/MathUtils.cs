using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProficienyTestProject
{
        /// <summary>
        /// This class will have the MathUtils
        /// </summary>
        public class MathUtils
        {
            /// <summary>
            /// Static Method for finding the average of two number
            /// </summary>
            /// <param name="a">FirstNumber as Int</param>
            /// <param name="b">SecondNumber as Int</param>
            /// <returns>Average of two Integers as Double value</returns>
            public static double Average(int a, int b)
            {
                /*
                    * return a + b / 2; // commenting Existing code
                    * 
                    * This will not work as expected becaus of BODMAS rule. So we are First adding the integers,then divide it by 2
                    * To have a result in Double, we need atleast one argument as Double in an Expression
                    */


                return (double) (a + b) / 2; //then use the expression (a+b)/n, n is the number of integers as input
            }
        }
    
}
