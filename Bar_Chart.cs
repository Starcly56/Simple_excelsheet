using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DDOOCP_Assignment
{
    public partial class Bar_Chart : Form
    {
        //declaring attributes
        private string[] characters;
        private int[] values;
        //creating constructor and initalizing values
        public Bar_Chart(string[] chars, int[] values)
        {
            this.characters = chars;
            this.values = values;
            InitializeComponent();
        }
        //creating an example
        public void BarExample()
        {
            try
            {
                barchart.Series.Clear();
                //declaring arrays to store data
                string[] seriesArray = characters; // { "A", "B", "C", "D" };
                int[] pointsArray = values;//{ 2, 1, 7, 5 };
                // Setting palette
                barchart.Palette = ChartColorPalette.EarthTones;
                // Setting title
                barchart.Titles.Add("Spread Sheet");
                // Adding series
                for (int i = 0; i < seriesArray.Length; i++)
                {
                    Series series = barchart.Series.Add(seriesArray[i]);
                    series.Points.Add(pointsArray[i]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Bar_Chart_Load(object sender, EventArgs e)
        {
            //calling example
            BarExample();
        }
    }
}
