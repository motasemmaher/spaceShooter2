using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter_Aya
{
    public partial class GameForm : Form
    {
        SoundPlayer sp = new SoundPlayer("sound1.wav");
        public GameForm()
        {
            InitializeComponent();
            player.Image = Form1.Players[Form1.playerindex].Character;
            pictureBox2.Image = Form1.Players[Form1.playerindex].Character;
            label4.Text = Form1.Players[Form1.playerindex].Name;
            label9.Text = DateTime.Now.ToString("dd/mm/yyyy");

            placeenemies();
        }

        List<PictureBox> enemylist = new List<PictureBox>();
        List<PictureBox> coinlist = new List<PictureBox>();
        List<string> steps = new List<string>();

        bool canfire = true;

        DateTime dateobj = DateTime.Now;
        int time = 0;
        int score = 0;
        int level = 1;
        int coins = 50;
        int enemydead = 0;

        private void placeenemies()
        {
            foreach (PictureBox enemy in enemylist)
            {
                enemy.Dispose();
            }
            enemylist.Clear();

            for (int i = 1; i <= 6; ++i)
            {
                PictureBox enemy = new PictureBox();
                enemy.Image = Properties.Resources.m2;
                enemy.SizeMode = PictureBoxSizeMode.Zoom;
                enemy.Location = new Point(i * 140, 10);
                enemy.Size = new Size(80, 125);

                gamepanel.Controls.Add(enemy);
                enemylist.Add(enemy);
            }
            fireballtimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label10.Text = ++time + "s";
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                if (player.Location.X > 20)
                {
                    player.Location = new Point(player.Location.X - 20, player.Location.Y);
                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (player.Location.X + player.Width < gamepanel.Width - 20)
                {
                    player.Location = new Point(player.Location.X + 20, player.Location.Y);
                }
            }
            if (e.KeyCode == Keys.W)
            {
                if (canfire)
                {
                    fireball.Location = new Point(player.Location.X + 30, player.Location.Y - fireball.Height);
                    fireball.Visible = true;
                    canfire = false;
                }
            }
        }
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                steps.Add("Left");
            }
            if (e.KeyCode == Keys.D)
            {
                steps.Add("Right");
            }
            if (e.KeyCode == Keys.W)
            {
                steps.Add("Shoot");
            }
        }

        private void fireballtimer_Tick(object sender, EventArgs e)
        {
            fireball.Location = new Point(fireball.Location.X, fireball.Location.Y - 20);
            if (fireball.Location.Y + fireball.Height < 0)
            {
                canfire = true;
            }
            if (fireball.Visible)
            {
                foreach (PictureBox enemy in enemylist)
                {
                    if (!enemy.Visible)
                        continue;

                    if (fireball.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        sp.Play();
                        fireball.Visible = false;
                        enemy.Visible = false;

                        PictureBox newcoin = new PictureBox();
                        newcoin.Image = Properties.Resources.coin;
                        newcoin.SizeMode = PictureBoxSizeMode.Zoom;
                        newcoin.Size = new Size(50, 50);
                        newcoin.Location = new Point(enemy.Location.X + 20, enemy.Location.Y);
                        gamepanel.Controls.Add(newcoin);
                        coinlist.Add(newcoin);

                        score += 100;
                        enemydead++;
                        label5.Text = "Score: " + score;
                        canfire = true;

                        if (enemydead == 6 && level == 1)
                        {
                            level += 1;
                            label12.Text = "Level: " + level;
                            fireballtimer.Stop();
                            placeenemies();
                            enemytimer.Start();
                            
                            return;
                        }
                        else if (enemydead == 12 && level == 2)
                        {
                            level += 1;
                            label12.Text = "Level: " + level;
                            fireballtimer.Stop();
                            placeenemies();
                            enemyshoot.Start();
                            meteortimer.Start();
                            
                            return;
                        }
                        else if (enemydead == 18 && level == 3)
                        {
                            //win
                            score -= time * 10;
                            label5.Text = "Score: " + score;
                            Game g = new Game();
                            g.Name = label4.Text;
                            g.Score = score;
                            g.Duration = time;
                            g.Coin = coins;
                            g.Date = dateobj;
                            g.Steps = steps;
                            Form1.Games.Add(g);

                            timer.Stop();
                            enemytimer.Stop();
                            enemyshoot.Stop();
                            meteortimer.Stop();
                            cointimer1.Stop();

                            result.Text = "You won!";
                            finalscore.Text = label5.Text;
                            scorechange.Text = "Time: -(" + time + "s x 10) points";

                            panel2.Visible = true;
                        }
                    }

                    
                }
            }
        }

        int eee = 6;
        bool enemymovedir = false;
        private void enemytimer_Tick(object sender, EventArgs e)
        {
            if (eee%12 == 0)
                enemymovedir = !enemymovedir;

            if (enemymovedir)
            {
                foreach (PictureBox enemy in enemylist)
                {
                    enemy.Location = new Point(enemy.Location.X + 13, enemy.Location.Y);
                }
            }
            else
            {
                foreach (PictureBox enemy in enemylist)
                {
                    enemy.Location = new Point(enemy.Location.X - 13, enemy.Location.Y);
                }
            }

            eee++;
        }

        private void meteortimer_Tick(object sender, EventArgs e)
        {
            meteor.Location = new Point(meteor.Location.X, meteor.Location.Y + 20);
            if (meteor.Visible && meteor.Bounds.IntersectsWith(player.Bounds))
            {
                label3.Text = "x" + (int.Parse(label3.Text[1].ToString()) - 1);
                meteor.Visible = false;
                if (label3.Text[1] == '0')
                {
                    //lose
                    score -= 500;
                    score -= time * 10;
                    label5.Text = "Score: " + score;
                    Game g = new Game();
                    g.Name = label4.Text;
                    g.Score = score;
                    g.Duration = time;
                    g.Coin = coins;
                    g.Date = dateobj;
                    g.Steps = steps;
                    Form1.Games.Add(g);

                    timer.Stop();
                    enemytimer.Stop();
                    enemyshoot.Stop();
                    meteortimer.Stop();
                    cointimer1.Stop();

                    result.Text = "You lost.";
                    finalscore.Text = label5.Text;
                    scorechange.Text = "Death: -500 points\nTime: -(" + time + "s x 10) points";

                    panel2.Visible = true;
                }
            }
        }

        private void buy1_Click(object sender, EventArgs e)
        {
            if (coins >= 100)
            {
                sp.SoundLocation = "sound2.wav";
                fireballtimer.Interval = 20;
                fireball.Image = pictureBox3.Image;
                coins -= 100;
                label6.Text = coins + " $";
            }
        }

        private void buy2_Click(object sender, EventArgs e)
        {
            if (coins >= 100)
            {
                sp.SoundLocation = "sound2.wav";
                fireballtimer.Interval = 15;
                fireball.Image = pictureBox4.Image;
                coins -= 200;
                label6.Text = coins + " $";
            }
        }

        private void buy3_Click(object sender, EventArgs e)
        {
            if (coins >= 100)
            {
                sp.SoundLocation = "sound2.wav";
                fireballtimer.Interval = 5;
                fireball.Image = pictureBox5.Image;
                coins -= 300;
                label6.Text = coins + " $";
            }
        }

        Random random = new Random();
        int choose;
        private void enemyshoot_Tick(object sender, EventArgs e)
        {
            bool exit = true;
            foreach (PictureBox enemy in enemylist)
            {
                if (enemy.Visible == true)
                    exit = false;
            }
            if (exit)
                return;

            do
            {
                choose = random.Next(6);
            }
            while (enemylist[choose].Visible == false); ;
            meteor.Location = new Point(enemylist[choose].Location.X + 20, enemylist[choose].Location.Y + enemylist[choose].Height);
            meteor.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new GameForm().Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new CreateForm().Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new UpdateForm().Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new StatisticsForm().Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new HistoryForm().Show();
        }

        private void cointimer1_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox coin in coinlist)
            {
                if (coin.Visible)
                {
                    coin.Location = new Point(coin.Location.X, coin.Location.Y + 15);
                    if (coin.Bounds.IntersectsWith(player.Bounds))
                    {
                        coin.Visible = false;
                        coins += 30;
                        label6.Text = coins + " $";
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
