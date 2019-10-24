using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment
{
    public class Formula_Implementation
    {
        //calling Formula class by creating object
        Formula f=new Formula();   
        //function declaration for desired calculation
        public double GetCalculatedValue(string operationName, List<double> values)
        {
            try
            {
                double result = 0;
                //calling the array of sorted values for calculation of median
                List<double> Sorted_values = f.Sort_values(values);
                switch (operationName.ToUpper())
                {
                    case "SUM":
                        f = new Formula();
                        result = (f.Sum(values));//calculation of sum
                        break;
                    case "AVERAGE":
                        f = new Formula();
                        result = (f.Mean(values));//calculation of average
                        break;
                    case "MEAN":
                        f = new Formula();
                        result = (f.Mean(values));//calculation of mean
                        break;
                    case "MEDIAN":
                        f = new Formula();
                        result = (f.Median(Sorted_values));//calculation of median of sorted values
                        break;
                    case "MODE":
                        f = new Formula();
                        result = (f.Mode(values));//calculation of mode
                        break;
                    case "*":
                        f = new Formula();
                        result = (f.Multiply(values));//calculation of multiplication
                        break;
                }
                return result;//returning the final calculated value in the cell of Spreadsheet 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
