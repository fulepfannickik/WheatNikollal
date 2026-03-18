using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Wheat
{
    public partial class Form1 : Form
    {
        List<Country> countries = new List<Country>();
        List<string> years = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialog.FileName;
            countries.Clear();
            years.Clear();

            using (StreamReader reader = new StreamReader(path))
            {
               
                if (!reader.EndOfStream)
                {
                    string headerLine = reader.ReadLine();
                    string[] headerParts = headerLine.Split(';');

                    for (int i = 1; i < headerParts.Length; i++)
                    {
                        years.Add(headerParts[i]);
                    }
                }

                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');


                    Dictionary<string, double> d = new Dictionary<string, double>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (parts[i] == ":")
                        {
                           d.Add(years[i - 1], double.NaN);
                        }
                        else
                        {
                            d.Add(years[i - 1], double.Parse(parts[i]));
                        }
                    }

                    Country country = new Country(parts[0], d);
                    countries.Add(country);
                }
            }

            Showdata();
        }

        private void Showdata()
        {
            WheatDataGrid.Rows.Clear();
            WheatDataGrid.Columns.Clear();

            WheatDataGrid.ColumnCount = years.Count;
            WheatDataGrid.RowCount = countries.Count;


            if (years.Count == 0) return;


            for (int i = 0; i < years.Count; i++)
            {
                WheatDataGrid.Columns[i].Name = years[i];
            }


            for (int i = 0; i < countries.Count; i++)
            {
                WheatDataGrid.Rows[i].HeaderCell.Value = countries[i].Name;
                for (int j = 0; j < countries[i].Data.Keys.Count; j++)
                {
                
                    string year = years[j];
                   
                    WheatDataGrid.Rows[i].Cells[j].Value = countries[i].Data[year];
                }
            }

            foreach (DataGridViewColumn col in WheatDataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}