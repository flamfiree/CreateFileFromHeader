using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void openHeaderButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "C:\\Users\\andrew\\ГУАП\\практика",
                Filter = "C/C++ Header | *.h"
            };


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                List<Structure> structs = ParseService.ParseFile(filename);

                ((ListBox)StructuresCheckedListBox).DataSource = structs;
                ((ListBox)StructuresCheckedListBox).DisplayMember = "Name";

                activate(filename);
            }
            //else
            //{
            //    MessageBox.Show("dick");
            //}
        }
        private void activate(string filename)
        {
            pathOfHeaderLabel.Text = filename;

            StructuresCheckedListBox.Visible = true;
            extensionsGroupBox.Visible = true;
            pathOfSaveFileButton.Visible = true;
            pathOfHeaderLabel.Visible = true;
            pathOfFileLabel.Visible = true;


        }
        //SaveFileDialog saveFileDialog1;
        string path;
        private void pathOfSaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = "C:\\Users\\andrew\\ГУАП\\практика",
            };
            if (docxRadioButton.Checked)
            {
                saveFileDialog1.Filter = "Word file | *.docx";
            }
            if (pdfRadioButton.Checked)
            {
                saveFileDialog1.Filter = "Pdf file | *.pdf";
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOfFileLabel.Text = saveFileDialog1.FileName;
                path = saveFileDialog1.FileName;
                createFileButton.Visible = true;
            };
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            List<Structure> ChosenStructures = new List<Structure>();

            foreach (var selectedItem in StructuresCheckedListBox.CheckedItems)
            {
                Structure structure = (Structure)selectedItem;
                ChosenStructures.Add(structure);
            }

            string ext = System.IO.Path.GetExtension(path);

            if(ext == ".docx")
            {
                FileService.DocxCreate(path, ChosenStructures);
            }
            if(ext == ".pdf")
            {
                FileService.PdfCreate(path, ChosenStructures);
            }
        }
    }
}
