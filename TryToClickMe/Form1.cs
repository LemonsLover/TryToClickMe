using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace TryToClickMe
{
    public partial class Form1 : Form
    {
        private int lives { get; set; } = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("kak ti eto sdelal ? Suka !");
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            var rnd = new Random();
            var thisButton = sender as Button;

            int newX = rnd.Next(this.Width - thisButton.Width);
            int newY = rnd.Next(this.Height - thisButton.Height);

            thisButton.Location = new Point(newX, newY);
            thisButton.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (lives > 0)
                this.Text = "Try to click me! " + $"Lives left: {--lives}";
            else
            {
                MessageBox.Show("You loose !", "Obidna", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Try to click me! " + $"Lives left: {lives}";
            await Task.Run(() => ButtonSpawner());
        }

        private void ButtonSpawner()
        {
            var rnd = new Random();
            int a = 10;
            while (true)
            {
                var button = new Button();
                button.Size = new Size(100, 50);

                int newX = rnd.Next(this.Width - button.Width);
                int newY = rnd.Next(this.Height - button.Height);

                button.Location = new Point(newX, newY);

                this.Invoke(new MethodInvoker(() => { this.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)); }));
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
