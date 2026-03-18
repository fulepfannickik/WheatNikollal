using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Wheat
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
        List<string> headers = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialog.FileName;

            using (StreamReader reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();

                headers = headerLine.Split(';').Skip(1).ToList();

                data.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');

                    string country = parts[0];

                    List<string> values = new List<string>();

                    for (int i = 1; i < parts.Length; i++)
                    {
                        values.Add(parts[i]);
                    }

                    data[country] = values;
                }
            }

            Showdata();
        }

        private void Showdata()
        {
            WheatDataGrid.Rows.Clear();
            WheatDataGrid.Columns.Clear();

            if (headers == null || headers.Count == 0) return;



            for (int i = 0; i < headers.Count; i++)
            {
                WheatDataGrid.Columns.Add(i.ToString(), headers[i]);
            }


            foreach (var kvp in data)
            {
                List<string> row = new List<string>();
                row.Add(kvp.Key);
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    kvp.Value[i] = kvp.Value[i].Replace(":", "-");
                }

                row.AddRange(kvp.Value).Skip(1);

          
                WheatDataGrid.Rows.Add(row.ToArray());
            }

            WheatDataGrid.AllowUserToAddRows = false;
            WheatDataGrid.AutoResizeColumns();
        }
    }
}