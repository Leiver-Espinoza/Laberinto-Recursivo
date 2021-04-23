using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberinto
{
    public partial class Frm_Principal : Form
    {
        public Bitmap dibujo;
        public int dimensionCelda;
        public Pen myPenMatriz = new Pen(Color.DarkGray, 1);
        private int filas;
        private int columnas;
        private Laberinto laberinto = new Laberinto();
        

        public Frm_Principal()
        {
            InitializeComponent();
            dibujo = new Bitmap(this.myPictureBox.Size.Width, this.myPictureBox.Size.Height);
            myPictureBox.Image = dibujo;
        }

        private void trb_Filas_Scroll(object sender, EventArgs e)
        {
            this.lbl_Filas.Text = "FILAS: " + this.trb_Filas.Value.ToString();
            this.filas = this.trb_Filas.Value;
            laberinto.Generado = false;
            ImprimirTablero();
            
        }

        private void trb_Columnas_Scroll(object sender, EventArgs e)
        {
            this.lbl_Columnas.Text = "COLUMNAS: " + this.trb_Columnas.Value.ToString();
            this.columnas = this.trb_Columnas.Value;
            laberinto.Generado = false;
            ImprimirTablero();
        }

        private void DibujarMatriz(int filas, int columnas)
        {
            Graphics g;
            g = Graphics.FromImage(this.dibujo);
            g.Clear(this.BackColor);

            this.filas = filas;
            this.columnas = columnas;

            dimensionCelda =
                    Math.Min(
                        (int)(this.myPictureBox.Width / columnas),
                        (int)(this.myPictureBox.Height / filas)
                    );
            g.DrawRectangle(
                myPenMatriz,
                0,
                0,
                columnas * dimensionCelda,
                filas * dimensionCelda);

            for (int y = 1; y < filas; y++)
            {
                g.DrawLine(
                    myPenMatriz,
                    0,
                    (y * dimensionCelda),
                    columnas * dimensionCelda,
                    (y * dimensionCelda)
                );
            }

            for (int x = 1; x < columnas; x++)
            {
                g.DrawLine(
                    myPenMatriz,
                    (x * dimensionCelda),
                    0,
                    (x * dimensionCelda),
                    filas * dimensionCelda
                );
            }
            this.myPictureBox.Image = dibujo;
            g.Dispose();

        }

        private void Frm_Principal_Resize(object sender, EventArgs e)
        {
            ImprimirTablero();
        }

        private void ImprimirTablero()
        {
            if (this.laberinto.Generado)
            {
                this.laberinto.DibujarLaberinto();
            }
            else
            {
                dibujo = new Bitmap(this.myPictureBox.Size.Width, this.myPictureBox.Size.Height);
                myPictureBox.Image = dibujo;
                this.DibujarMatriz(this.trb_Filas.Value, this.trb_Columnas.Value);
            }
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromImage(this.dibujo);
            g.Clear(Color.Black);
            this.laberinto = new Laberinto(
                this.filas, 
                this.columnas, 
                ref dibujo,
                ref myPictureBox,
                this.chk_Paticion50.Checked
            );
            this.myPictureBox.Image = dibujo;
            g.Dispose();
            this.laberinto.DibujarLaberinto();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            ImprimirTablero();
        }
    }
}
