using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalcompTwoCam
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            var ins_ico = new Bitmap(String.Format(@"{0}\Resources\checked.png", CommonParameters.projectDirectory));
            var ins_ico_new = new Bitmap(ins_ico, new Size(100, 100));
            var create_ico = new Bitmap(String.Format(@"{0}\Resources\create.png", CommonParameters.projectDirectory));
            var create_ico_new = new Bitmap(create_ico, new Size(100, 100));
            var edit_ico = new Bitmap(String.Format(@"{0}\Resources\edit.png", CommonParameters.projectDirectory));
            var edit_ico_new = new Bitmap(edit_ico, new Size(100, 100));
            var del_ico = new Bitmap(String.Format(@"{0}\Resources\delete.png", CommonParameters.projectDirectory));
            var del_ico_new = new Bitmap(del_ico, new Size(100, 100));
            buttonInspect.Image = ins_ico_new;
            buttonCreate.Image = create_ico_new;
            buttonEdit.Image = edit_ico_new;
            buttonDelModel.Image = del_ico_new;
        }

        

        private void buttonInspect_Click(object sender, EventArgs e)
        {
            if (Forms.inspectModel == null)
            {
                Forms.inspectModel = new InspectModel();
                Forms.inspectModel.Show();
            }
            else
            {
                Forms.inspectModel.BringToFront();
            }
            
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (Forms.registerModel == null)
            {
                Forms.registerModel = new RegisterModel();
                Forms.registerModel.Show();
            }
            else
            {
                Forms.registerModel.BringToFront();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (Forms.editModel == null)
            {
                Forms.editModel = new EditModel();
                Forms.editModel.Show();
            }
            else
            {
                Forms.editModel.BringToFront();
            }
        }

        private void buttonDelModel_Click(object sender, EventArgs e)
        {
            if (Forms.deleteModelPage == null)
            {
                Forms.deleteModelPage = new DeleteModelPage();
                Forms.deleteModelPage.Show();
            }
            else
            {
                Forms.deleteModelPage.BringToFront();
            }
        }
    }
}
