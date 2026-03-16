using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wheat
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string path = openFileDialog.FileName;
            

            using (StreamReader reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] parts = line.Split('\t');

                    string country = parts[0];
                    List<string> values = new List<string>();

                    for (int i = 1; i < parts.Length; i++)
                    {
                        string val = parts[i];
                        values.Add(val);
                    }

                    data[country] = values;
                }
            }

            Showdata();
        }

        private void Showdata()
        {
            throw new NotImplementedException();
        }
    }
}
