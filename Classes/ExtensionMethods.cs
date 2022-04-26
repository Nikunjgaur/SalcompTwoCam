using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomExtensions
{
    public static class DataGridViewExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
       
       

        /// <summary>
        ///  Exports datagrid view data into CSV format at given path<br/>
        /// </summary>
        /// 
        public static void SaveToCSV(this DataGridView dataGridView)
        {
            if (dataGridView.Rows != null && dataGridView.Rows.Count != 0)
            {
                string filename = "";
                // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
                dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                // Select all the cells
                dataGridView.SelectAll();
                // Copy selected cells to DataObject
                DataObject dataObject = dataGridView.GetClipboardContent();
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Save Report",

                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    FileName = "Report" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm"),
                    FilterIndex = 2,
                    RestoreDirectory = true,

                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                    File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
                    dataGridView.ClearSelection();
                }
                else
                {
                    dataGridView.ClearSelection();
                }
                // Get the text of the DataObject, and serialize it to a file
            }
            else
            {
                MessageBox.Show("Can not save empty report.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
