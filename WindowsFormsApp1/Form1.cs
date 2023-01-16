using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static object[] btns;
        private static int points = 0;
        private static int discovered = 0;
        public Form1()
        {
            InitializeComponent();
            Form1.btns = new object[16];
            int counter = 0;
            bool black = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn  = new Button();
                    
                    this.Controls.Add(btn);
                    btn.Location = new Point(150+i*100,150+j*100);
                    btn.Left = 100+i*50;
                    btn.Top = 100 + j * 50;
                    btn.Height = 50;
                    btn.Width = 50;
                    btn.Click += new EventHandler(game_button_click);
                    //btn.Size = new Size(100,100);
                    if (black)
                    {
                        btn.BackColor = Color.Black;
                        btn.Text = " ";
                    } 
                    else
                    {
                        btn.BackColor= Color.White;
                    }
                    btn.Visible = true;
                    black = !black;
                    Form1.btns[counter] = btn;
                    counter++;
                }
                black = !black;
            }
        }
        private void game_button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Gray && btn.Text == " ")
            {
                points++;
                discovered++;
                btn.BackColor = Color.Black;
            } else if (btn.BackColor == Color.Gray) {
                points--;
                btn.BackColor = Color.White;
            }


            if(discovered == 8)
            {
                bool black = false;
                for (int i = 0; i < btns.Length; i++)
                {
                    Button gbtn = (Button)btns[i];
                    if (i % 4 == 0) black = !black;
                    if (black)
                    {
                        gbtn.BackColor = Color.Black;
                    }
                    else
                    {
                        gbtn.BackColor = Color.White;
                    }
                    black = !black;
                }
            }
            
            /*
            
            if (black)
            {
                btn.BackColor = Color.Black;
                btn.Text = " ";
            }
            else
            {
                btn.BackColor = Color.White;
            }
            */
            label1.Text = "Punkti: " + points;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Text = "Mana forma";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            MessageBox.Show("Reinis Vārna");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            points = 0;
            discovered = 0;
            for(int i = 0; i < btns.Length; i++)
            {
                Button btn = (Button)btns[i];
                btn.BackColor = Color.Gray;
            }
        }
    }
}
