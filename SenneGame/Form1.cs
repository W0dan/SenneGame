using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenneGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KeyDown += Form1_KeyDown;
        }

        private Point _ventje = new Point(10, 10);

        private void Form1_Load(object sender, EventArgs e)
        {
            Teken_ventje(pictureBox1);
        }

        private void Teken_ventje(PictureBox tekenblad)
        {
            var gfx = tekenblad.CreateGraphics();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: //op, boven
                    //achtergrondkleur wordt groen
                    BackColor = Color.Green;
                    break;
                case Keys.Down: //neer, beneden
                    //achtergrondkleur wordt rood
                    BackColor = Color.Red;
                    break;
                case Keys.Left: //links
                    //achtergrondkleur wordt geel
                    BackColor = Color.Yellow;
                    break;
                case Keys.Right: //rechts
                    //achtergrondkleur wordt oranje
                    BackColor = Color.Orange;
                    break;
            }
        }
    }
}
