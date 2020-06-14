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
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            label11.Text = Form1.Games.Count.ToString();
            label12.Text = Form1.Players.Count.ToString();

            var byScore = from game in Form1.Games
                          orderby game.Score
                          select game;
            if (byScore.Count() != 0)
            {
                label13.Text = byScore.ElementAt(byScore.Count() - 1).Score.ToString();
                label14.Text = byScore.ElementAt(0).Score.ToString();
            }

            var duration = from game in Form1.Games
                           orderby game.Duration
                           select game.Duration;
            if (duration.Count() != 0)
            {
                label15.Text = duration.ElementAt(0).ToString();
                label16.Text = duration.ElementAt(duration.Count() - 1).ToString();
                label17.Text = duration.Sum().ToString();
            }
        }
    }
}
