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
    public partial class Form1 : Form
    {

        public static List<Game> Games = new List<Game>();
        public static List<Player> Players = new List<Player>();
        public static int playerindex;
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (Players.Count == 0)
            {
                MessageBox.Show("Create a profile first.");
                return;
            }
            create.Visible = false;
            update.Visible = false;
            statistics.Visible = false;
            history.Visible = false;
            listBox1.DataSource = Players;
            panel1.Visible = true;
        }

        private void profile_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!create.Visible)
            {
                create.Visible = true;
                update.Visible = true;
            }
            else
            {
                create.Visible = false;
                update.Visible = false;
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            create.Visible = false;
            update.Visible = false;
            new CreateForm().Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            create.Visible = false;
            update.Visible = false;
            if (Players.Count == 0)
            {
                MessageBox.Show("You haven't created any profiles to update.");
                return;
            }
            new UpdateForm().Show();
        }

        private void reporting_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!statistics.Visible)
            {
                statistics.Visible = true;
                history.Visible = true;
            }
            else
            {
                statistics.Visible = false;
                history.Visible = false;
            }
        }

        private void statistics_Click(object sender, EventArgs e)
        {
            statistics.Visible = false;
            history.Visible = false;
            new StatisticsForm().Show();
        }

        private void history_Click(object sender, EventArgs e)
        {
            statistics.Visible = false;
            history.Visible = false;
            new HistoryForm().Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerindex = listBox1.SelectedIndex;
            panel1.Visible = false;
            new GameForm().Show();
        }
    }
}
