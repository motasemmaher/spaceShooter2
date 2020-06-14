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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
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

        private void createbutton_Click(object sender, EventArgs e)
        {
            Player player = new Player();

            player.Name = name.Text;
            if (name.Text == "")
                player.Name = "Unnamed";
            player.Age = (int)age.Value;
            if (wizard.Checked)
                player.Gender = "Wizard";
            else
                player.Gender = "Witch";
            player.Character = character.Image;

            Form1.Players.Add(player);

            this.Dispose();
        }
    }
}
