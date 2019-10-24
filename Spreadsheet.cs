using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public partial class Spreadsheet : Form
    {
        //attributes
        private String[] cols = {"A","B","C","D","E","F","G","H","I","J","K","L",
                                "M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        private string txtbox2value;
        private string column_row_value;
        private string name;
        private string operationName;
        private List<double> values = new List<double>();
        //for making dynamic insertion of values
        private string final_value = "";
        private int lastColumnIndex = -1;
        private int lastRowIndex = -1;
        //calling other classes
        Grid g = new Grid();
        Formula_Implementation fi;
        Bar_Chart bc;
        //creating constructor and initalizing it
        public Spreadsheet()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
        //Customizing the datagrid when it gets opened
        private void Spreadsheet_Load(object sender, EventArgs e)
        {
            fi = new Formula_Implementation();
            try
            {
                //creating 26 by 26 grid boxes
                var columns = new DataGridViewColumn[g.Colums];
                for (int i = 0; i < g.Rows; i++)
                {
                    //assigning column index
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].Name += Convert.ToChar(i + (int)'A');
                }
                Array.ForEach(columns, item => dataGridView1.Columns.Add(item));
                for (int i = 0; i < g.Colums; i++)
                {
                    dataGridView1.Rows.Add(new string[i]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //assigning row index
                using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, 
                        b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //viewing particular cell 
                column_row_value = cols[e.ColumnIndex] + (dataGridView1.CurrentCell.RowIndex + 1).ToString();
                textBox1.Text = column_row_value;    
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (column_row_value == name)
                    {
                        //formula display
                        textBox2.Text = txtbox2value;
                    }
                    else
                    {
                        //entered value display
                        textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
                else
                {
                    //null value
                    textBox2.Text = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                //initializing object of datagridview
                DataGridView dv = (DataGridView)sender;                 string text = Convert.ToString(dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);                 if (text.Contains("=")||text.Contains("*"))
                {
                    lastColumnIndex = -1;
                    lastRowIndex = -1;
                    final_value = "";
                }                 else if(final_value!="")
                {
                    text = final_value;
                }                 if (text.StartsWith("="))                 {
                    if (final_value == "")
                    {
                        //for dynamic calculation
                        lastColumnIndex = e.ColumnIndex;
                        lastRowIndex = e.RowIndex;
                        final_value = text;
                    }
                    name = column_row_value;
                    txtbox2value = Convert.ToString(dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);                    // textBox2.Text = txtbox2value;                     if (text.Contains(":"))                     {                         values.Clear();                         //substring code for operations except multiplication                         operationName = text.Substring(1, (text.IndexOf(' ') - text.IndexOf('=')) - 1);                         //for a value                         string lowerValue = text.Substring(text.IndexOf(' ') + 1, (text.IndexOf(':') - text.IndexOf(' ')) - 1);                         string higherValue = text.Substring(text.IndexOf(':') + 1, (text.Length - 1) - text.IndexOf(':'));                         //for a letter                         char lowerLetter = Convert.ToChar(lowerValue.Substring(0, 1));                         char higherLetter = Convert.ToChar(higherValue.Substring(0, 1));                         //for a number                         string lowerNumber = lowerValue.Length < 3 ? lowerValue.Substring(1, 1) : lowerValue.Substring(1, 2);                         string higherNumber = higherValue.Length < 3 ? higherValue.Substring(1, 1) : higherValue.Substring(1, 2);                                              if (lowerLetter == higherLetter)                         {
                            //for a particular column
                            for (int row = Convert.ToInt32(lowerNumber); row <= Convert.ToInt32(higherNumber); row++)                             {                                 values.Add(Convert.ToDouble(dv.Rows[row - 1].Cells[e.ColumnIndex].Value));
                            }                             if (final_value != "")
                            {
                                dv.Rows[lastRowIndex].Cells[lastColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                            }
                            else
                            {
                                dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                            }
                        }                         else if (lowerNumber == higherNumber)                         {
                            //for a particular row
                            for (char c = lowerLetter; c <= higherLetter; c++)                             {                                 values.Add(Convert.ToDouble(dv.Rows[Convert.ToInt32(lowerNumber)-1].Cells[c.ToString()].Value));
                            }
                            if (final_value != "")
                            {
                                dv.Rows[lastRowIndex].Cells[lastColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                            }
                            else
                            {
                                dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                            }
                        }                     }                 }
                if(text.Contains("*"))
                {
                    values.Clear();
                    double firstnum;
                    double secondnum;
                    if (final_value == "")
                    {
                        //attributes for dynamic calculation 
                        lastColumnIndex = e.ColumnIndex;
                        lastRowIndex = e.RowIndex;
                        final_value = text;
                    }
                    //substring code for multiplication
                    operationName = "*";                  
                    //for a value
                    string lowerValue = text.Substring(0 , text.IndexOf('*'));
                    string higherValue = text.Substring(text.IndexOf('*') + 1, (text.Length - 1) - text.IndexOf('*'));
                    //for a letter
                    char lowerLetter = Convert.ToChar(lowerValue.Substring(0, 1));
                    char higherLetter = Convert.ToChar(higherValue.Substring(0, 1));
                    //for a number
                    string lowerNumber = lowerValue.Length < 3 ? lowerValue.Substring(1, 1) : lowerValue.Substring(1, 2);
                    string higherNumber = higherValue.Length < 3 ? higherValue.Substring(1, 1) : higherValue.Substring(1, 2);

                    if (lowerLetter == higherLetter)
                    {
                        //for a particular column
                        int row1 = Convert.ToInt32(lowerNumber);
                        firstnum=Convert.ToDouble(dv.Rows[row1-1].Cells[e.ColumnIndex].Value);
                        values.Add(firstnum);
                        int row2 = Convert.ToInt32(higherNumber);
                        secondnum = Convert.ToDouble(dv.Rows[row2-1].Cells[e.ColumnIndex].Value);
                        values.Add(secondnum);
                        if (final_value != "")
                        {
                            dv.Rows[lastRowIndex].Cells[lastColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                        }
                        else
                        {
                            dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                        }
                    }
                    else if(lowerNumber==higherNumber)
                    {
                        //for a particular row
                        char c = lowerLetter;
                        firstnum = Convert.ToDouble(dv.Rows[e.RowIndex].Cells[c.ToString()].Value);
                        values.Add(firstnum);
                        char d = higherLetter;
                        secondnum = Convert.ToDouble(dv.Rows[e.RowIndex].Cells[d.ToString()].Value);
                        values.Add(secondnum);
                        if (final_value != "")
                        {
                            dv.Rows[lastRowIndex].Cells[lastColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                        }
                        else
                        {
                            dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fi.GetCalculatedValue(operationName, values);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Button for generating the bar chart of the data
        private void Button1_Click(object sender, EventArgs e)
        {
            //Declaring arrays to store entered value for bar chart
            List<int> values = new List<int>();
            List<int> rowIndexes = new List<int>();
            List<int> columnIndexes = new List<int>();
            try
            {
                //adding entered values,rowindex and columnindex in the arrays declared above 
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    var value = dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value;
                    values.Add(Convert.ToInt32(value));
                    rowIndexes.Add(cell.RowIndex);
                    columnIndexes.Add(cell.ColumnIndex);
                }
                //creating new array list
                ArrayList chars = new ArrayList();
                List<int> uniqueValues = new List<int>();
                //identification of the rowindex and column index of the values
                int valueIndex = 0;
                foreach (int s in columnIndexes)
                {
                    int charIndex = 0;
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        if (charIndex == s)
                        {
                            if (!chars.Contains(c))
                            {
                                uniqueValues.Add(values[valueIndex]);
                                chars.Add(c);
                            }
                            else
                            {
                                uniqueValues[chars.IndexOf(c)] += values[valueIndex];
                            }
                        }
                        charIndex++;
                    }
                    valueIndex++;
                }
                //for x-axis
                string[] letters = new string[chars.Count];
                int index = 0;
                foreach (char c in chars)
                {
                    letters[index] = c.ToString();
                    index++;
                }
                //for y-axis 
                int[] dataValues = new int[uniqueValues.Count];
                int arrIndex = 0;
                foreach (int val in uniqueValues)
                {
                    dataValues[arrIndex] = val;
                    arrIndex++;
                }
                //Calling Barchart Class and its function through object
                bc = new Bar_Chart(letters, dataValues);
                bc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}