using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestArea001
{
    public partial class Form1 : Form
    {
        TestDB _repo;

        public Form1()
        {
            InitializeComponent();
            _repo = new TestDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Save_Click(object sender, EventArgs e)
        {
            TestDataSet1TableAdapters.DateTimeTestAdapter DataSetAdapter = new TestDataSet1TableAdapters.DateTimeTestAdapter();

            //udfylder textboksen hvis ingen text - altså ved string.Empty
            
            dateTimePicker1.Text = dateTimePicker1.Text != string.Empty ? dateTimePicker1.Text : "2001/10/12";
            

            var p = new DatoKlasse() { Dato = (DateTime.Parse(dateTimePicker1.Text)) };

            //_repo.Mathias(p);

            int id = _repo.CreatePersonInDatoKlasse(p);
        }
    }
}
