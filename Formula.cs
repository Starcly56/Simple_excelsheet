using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment
{
    public class Formula
    {
        public Formula()         {

        }
        //formula for Sum
        public double Sum(List<double> values)
        {
            try
            {
                double sum = 0;
                foreach (var v in values)
                {
                    sum += v;
                }
                return sum;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //formula for Mean
        public double Mean(List<double> values)
        {
            try
            {
                double mean = 0;
                foreach (var v in values)
                {
                    mean += v;
                }
                mean = mean / values.Count;
                return mean;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //formula for Mode
        public int Mode(List<double> values)
        {
            try
            {
                var groups = values.GroupBy(x => x);
                var largest = groups.OrderByDescending(x => x.Count()).First();
                return Convert.ToInt32(largest.Key);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //formula for Multiply
        public double Multiply(List<double> values)
        {
            try
            {
                double multiply = 1;
                foreach (var v in values)
                {
                    multiply *= v;
                }
                return multiply;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //sorting the entered values for median 
        public List<double> Sort_values(List<double> values)
        {
            try
            {
                bool flag;
                double tempvalue;
                do
                {
                    flag = false;
                    for (int i = 0; i < values.Count - 1; i++)
                    {
                        if (values[i] > values[i + 1])
                        {
                            tempvalue = values[i];
                            values[i] = values[i + 1];
                            values[i + 1] = tempvalue;
                            flag = true;
                        }
                    }
                }
                while (flag == true);
                List<double> list = values.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //formula for Median
        public double Median(List<double> values)
        {
            try
            {
                double median;
                int firstitem;//gets the first value for median
                int seconditem;//gets the second value for median
                if (values.Count % 2 == 1)
                {
                    firstitem = (values.Count + 1) / 2;
                    median = values[firstitem - 1];
                }
                else
                {
                    firstitem = values.Count / 2;
                    seconditem = (values.Count / 2) + 1;
                    median = (values[firstitem - 1] + values[seconditem - 1]) / 2;
                }
                return median;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
