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

        private void Form1_Load(object sender, EventArgs e)
        {
            CategoryComboBox.Items.Add("Minden kategória...");
            CategoryComboBox.Items.Add("Törpe");
            CategoryComboBox.Items.Add("Kicsi");
            CategoryComboBox.Items.Add("Közepes");
            CategoryComboBox.Items.Add("Nagy");
            CategoryComboBox.Items.Add("Óriási");

            CategoryComboBox.SelectedIndex = 0;
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialog.FileName;
            countries.Clear();
            years.Clear();

            try
            {
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countries.Count == 0) return;

            string selectedCategory = CategoryComboBox.SelectedItem.ToString();

            if (selectedCategory == "Minden kategória...")
            {
                foreach (DataGridViewRow row in WheatDataGrid.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            double max2016 = countries
                .Where(c => !double.IsNaN(c.Data["2016"]))
                .Max(c => c.Data["2016"]);

            foreach (DataGridViewRow row in WheatDataGrid.Rows)
            {
                string countryName = row.HeaderCell.Value.ToString();
                Country c = countries.First(x => x.Name == countryName);

                double value2016 = c.Data["2016"];
                string category = "";
                if (double.IsNaN(value2016))
                {
                    row.Visible = false;
                }
                else
                {
                    double percent = value2016 / max2016;

                    if (percent >= 0 && percent < 0.10) category = "Törpe";
                    else if (percent >= 0.10 && percent < 0.20) category = "Kicsi";
                    else if (percent >= 0.20 && percent < 0.40) category = "Közepes";
                    else if (percent >= 0.40 && percent < 0.60) category = "Nagy";
                    else category = "Óriási";

                    row.Visible = (category == selectedCategory);
                }


            }

        }
            
            private void korToolStripMenu_Click(object sender, EventArgs e)
            {
                if (WheatDataGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nincs kijelölt ország!");
                    return;
                }

                Dictionary<string, double> averages = new Dictionary<string, double>();

               
                foreach (DataGridViewRow row in WheatDataGrid.SelectedRows)
                {
                    string countryName = row.HeaderCell.Value.ToString();
                    Country c = countries.First(x => x.Name == countryName);

                    var validValues = c.Data.Values.Where(v => !double.IsNaN(v));

                    if (validValues.Any())
                    {
                        averages[c.Name] = validValues.Average();
                    }
                }

                if (averages.Count == 0) return;

                double total = averages.Values.Sum();


                Dictionary<string, double> filtered = new Dictionary<string, double>();
                double otherSum = 0;

                foreach (var item in averages)
                {
                    double percent = item.Value / total;

                    if (percent < 0.02)
                    {
                        otherSum += item.Value;
                    }
                    else
                    {
                        filtered[item.Key] = item.Value;
                    }
                }

                if (otherSum > 0)
                {
                    filtered["Egyéb"] = otherSum;
                }

                
                ChartForm form = new ChartForm(filtered);
                form.Show();
        
            }
    }
    
}