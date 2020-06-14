using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter_Aya
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name.Text = ((Player)comboBox1.SelectedItem).Name;
            age.Value = ((Player)comboBox1.SelectedItem).Age;
            if (((Player)comboBox1.SelectedItem).Gender == "Wizard")
                wizard.Checked = true;
            else
                witch.Checked = true;
            character.Image = ((Player)comboBox1.SelectedItem).Character;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Form1.Players;
        }

        private void char1_Click(object sender, EventArgs e)
        {
            character.Image = char1.Image;
        }

        private void char2_Click(object sender, EventArgs e)
        {
            character.Image = char2.Image;
        }

        private void char3_Click(object sender, EventArgs e)
        {
            character.Image = char3.Image;
        }

        private void char4_Click(object sender, EventArgs e)
        {
            character.Image = char4.Image;
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            ((Player)comboBox1.SelectedItem).Name = name.Text;
            ((Player)comboBox1.SelectedItem).Age = (int)age.Value;
            if (wizard.Checked)
                ((Player)comboBox1.SelectedItem).Gender = "Wizard";
            else
                ((Player)comboBox1.SelectedItem).Gender = "Witch";
            ((Player)comboBox1.SelectedItem).Character = character.Image;

            this.Dispose();
        }
    }
}
