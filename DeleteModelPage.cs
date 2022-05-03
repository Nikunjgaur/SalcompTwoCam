using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalcompTwoCam
{
    public partial class DeleteModelPage : Form
    {
        public DeleteModelPage()
        {
            InitializeComponent();
        }
        void UpdateModelList()
        {
            dataGridViewModel.Rows.Clear();
            DirectoryInfo obj = new DirectoryInfo(string.Format(@"{0}\Models", CommonParameters.projectDirectory));
            DirectoryInfo[] folders = obj.GetDirectories();

            for (int i = 0; i < folders.Length; i++)
            {
                dataGridViewModel.Rows.Add((i + 1).ToString());
                dataGridViewModel.Rows[i].Cells[1].Value = folders[i].Name;

            }

            for (int i = 0; i < dataGridViewModel.Columns.Count; i++)
            {
                DataGridViewCellStyle column = dataGridViewModel.Columns[i].HeaderCell.Style;
                column.Font = new Font("Microsoft Sans Serif", 16);
                column.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        

        public static void DeleteDirectoryRecursively(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                File.Delete(file);
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteDirectoryRecursively(subDir);
            }

            Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
            Directory.Delete(target_dir);
        }

        

        private void buttonDelModel_Click(object sender, EventArgs e)
        {
            int cellIndex = dataGridViewModel.SelectedCells[0].RowIndex;

            string path = string.Format(@"{0}\Models\{1}", CommonParameters.projectDirectory, dataGridViewModel.Rows[cellIndex].Cells[1].Value.ToString());

            DialogResult dialogResult = MessageBox.Show("Delete model permanently ? All data related to model will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteDirectoryRecursively(path);
                UpdateModelList();

                //Directory.CreateDirectory(path);
            }
            else
            {
                return;
            }
        }

        private void DeleteModelPage_Load(object sender, EventArgs e)
        {
            UpdateModelList();

        }

        private void DeleteModelPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.deleteModelPage = null;
        }
    }
}
