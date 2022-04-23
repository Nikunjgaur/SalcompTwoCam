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
using Newtonsoft.Json;

namespace SalcompTwoCam
{
    public partial class RegisterModel : Form
    {
        public RegisterModel()
        {
            InitializeComponent();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (textBoxModelName.Text != "")
            {
                Model.ModelName = textBoxModelName.Text;
                CommonParameters.camSrNum = "02J53804511";
                CommonParameters.camCode = "FirstCam";


                string path = string.Format(@"{0}\Models\{1}\{2}", CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Directory.CreateDirectory(path + @"\Images");

                    Model model = new Model();
                    //model.CheckEdges.Add(new Tools.CheckEdge());
                    //model.CheckTemplates.Add(new Tools.CheckTemplate());
                    string modelResult = JsonConvert.SerializeObject(model);
                    File.WriteAllText(path + @"\ModelData.json", modelResult);

                    CreateModel createModel = new CreateModel();
                    createModel.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Model already exists. Overwrite model data and delete model Images ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        DeleteDirectoryRecursively(path);
                        Directory.CreateDirectory(path);
                        Directory.CreateDirectory(path + @"\Images");

                        Model model = new Model();
                        //model.CheckTemplates.Add(new Tools.CheckTemplate());
                        //model.CheckEdges.Add(new Tools.CheckEdge());
                        string modelResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                        File.WriteAllText(path + @"\ModelData.json", modelResult);
                        Cursor.Current = Cursors.Default;
                        CreateModel createModel = new CreateModel();
                        createModel.Show();
                        this.Hide();

                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please enter Model Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void RegisterModel_Load(object sender, EventArgs e)
        {
            textBoxModelName.Text = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
        }
    }
}
