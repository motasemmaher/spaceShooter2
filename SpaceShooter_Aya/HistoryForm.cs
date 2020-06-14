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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            l1 = label4;
            l2 = label8;
        }

        Label l1;
        Label l2;

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;

            foreach (Game game in Form1.Games)
            {
                Label name = new Label();
                name.Text = game.Name;
                name.Font = refText.Font;
                name.BackColor = refText.BackColor;
                name.Anchor = refText.Anchor;
                name.Cursor = Cursors.Hand;
                name.Tag = game;
                name.Click += new EventHandler(nameclick);
                tableLayoutPanel1.Controls.Add(name);

                Label date = new Label();
                date.Text = game.Date.ToString("dd/mm/yyyy");
                date.Font = refText.Font;
                date.BackColor = refText.BackColor;
                date.Anchor = refText.Anchor;
                tableLayoutPanel1.Controls.Add(date);

                Label dur = new Label();
                dur.Text = game.Duration.ToString();
                dur.Font = refText.Font;
                dur.BackColor = refText.BackColor;
                dur.Anchor = refText.Anchor;
                tableLayoutPanel1.Controls.Add(dur);

                Label score = new Label();
                score.Text = game.Score.ToString();
                score.Font = refText.Font;
                score.Anchor = refText.Anchor;
                score.BackColor = refText.BackColor;
                tableLayoutPanel1.Controls.Add(score);

                Label coins = new Label();
                coins.Text = game.Coin.ToString();
                coins.Font = refText.Font;
                coins.BackColor = refText.BackColor;
                coins.Anchor = refText.Anchor;
                tableLayoutPanel1.Controls.Add(coins);
            }
            tableLayoutPanel1.Visible = true;
        }
        private void nameclick(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.Controls.Add(l1);
            tableLayoutPanel2.Controls.Add(l2);
            int stepcount = 0;
            foreach (string step in ((Game)((Label)sender).Tag).Steps)
            {
                Label stepnumber = new Label();
                stepnumber.Text = (++stepcount).ToString();
                stepnumber.Font = refText.Font;
                stepnumber.Anchor = refText.Anchor;

                Label steplabel = new Label();
                steplabel.Text = step;
                steplabel.Font = refText.Font;
                steplabel.Anchor = refText.Anchor;

                tableLayoutPanel2.Controls.Add(stepnumber);
                tableLayoutPanel2.Controls.Add(steplabel);
            }
            tableLayoutPanel2.Visible = true;
        }
    }
}
