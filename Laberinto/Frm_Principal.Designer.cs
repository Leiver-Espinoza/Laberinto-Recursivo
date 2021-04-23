
namespace Laberinto
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.btn_Generar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Columnas = new System.Windows.Forms.Label();
            this.lbl_Filas = new System.Windows.Forms.Label();
            this.trb_Filas = new System.Windows.Forms.TrackBar();
            this.trb_Columnas = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.myPictureBox = new System.Windows.Forms.PictureBox();
            this.chk_Paticion50 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Filas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Columnas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Generar
            // 
            this.btn_Generar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Generar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generar.ForeColor = System.Drawing.Color.Black;
            this.btn_Generar.Location = new System.Drawing.Point(28, 672);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(189, 61);
            this.btn_Generar.TabIndex = 0;
            this.btn_Generar.Text = "Generar Laberinto";
            this.btn_Generar.UseVisualStyleBackColor = false;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generación y resolución de un laberinto";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 73);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deslice las barras hasta obtener los valores que desea para definir las dimension" +
    "es del laberinto.\r\n\r\nLo mínimo permitido es un laberingo to de 3 x 3 casillas y " +
    "lo máximo es de 200 x 200 casillas.";
            // 
            // lbl_Columnas
            // 
            this.lbl_Columnas.ForeColor = System.Drawing.Color.White;
            this.lbl_Columnas.Location = new System.Drawing.Point(25, 418);
            this.lbl_Columnas.Name = "lbl_Columnas";
            this.lbl_Columnas.Size = new System.Drawing.Size(150, 15);
            this.lbl_Columnas.TabIndex = 4;
            this.lbl_Columnas.Text = "COLUMNAS";
            // 
            // lbl_Filas
            // 
            this.lbl_Filas.ForeColor = System.Drawing.Color.White;
            this.lbl_Filas.Location = new System.Drawing.Point(25, 252);
            this.lbl_Filas.Name = "lbl_Filas";
            this.lbl_Filas.Size = new System.Drawing.Size(85, 15);
            this.lbl_Filas.TabIndex = 5;
            this.lbl_Filas.Text = "FILAS";
            // 
            // trb_Filas
            // 
            this.trb_Filas.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trb_Filas.Location = new System.Drawing.Point(18, 268);
            this.trb_Filas.Maximum = 200;
            this.trb_Filas.Minimum = 3;
            this.trb_Filas.Name = "trb_Filas";
            this.trb_Filas.Size = new System.Drawing.Size(178, 45);
            this.trb_Filas.TabIndex = 20;
            this.trb_Filas.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trb_Filas.Value = 5;
            this.trb_Filas.Scroll += new System.EventHandler(this.trb_Filas_Scroll);
            // 
            // trb_Columnas
            // 
            this.trb_Columnas.BackColor = System.Drawing.Color.Black;
            this.trb_Columnas.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trb_Columnas.Location = new System.Drawing.Point(18, 436);
            this.trb_Columnas.Maximum = 200;
            this.trb_Columnas.Minimum = 3;
            this.trb_Columnas.Name = "trb_Columnas";
            this.trb_Columnas.Size = new System.Drawing.Size(200, 45);
            this.trb_Columnas.TabIndex = 21;
            this.trb_Columnas.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trb_Columnas.Value = 5;
            this.trb_Columnas.Scroll += new System.EventHandler(this.trb_Columnas_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Paso 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Paso 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "Paso 3";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 30);
            this.label6.TabIndex = 27;
            this.label6.Text = "Seleccione la cantidad de filas que desea en el laberinto";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 30);
            this.label7.TabIndex = 28;
            this.label7.Text = "Seleccione la cantidad de columnas que desea en el laberinto";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 557);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 75);
            this.label8.TabIndex = 29;
            this.label8.Text = "Configure los parámetros de la manera que desee y presione el botón \"Generar Labe" +
    "rinto\" para obtener un diseño generado de forma aleatoria.";
            // 
            // myPictureBox
            // 
            this.myPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.myPictureBox.Location = new System.Drawing.Point(250, 182);
            this.myPictureBox.Name = "myPictureBox";
            this.myPictureBox.Size = new System.Drawing.Size(1642, 853);
            this.myPictureBox.TabIndex = 31;
            this.myPictureBox.TabStop = false;
            // 
            // chk_Paticion50
            // 
            this.chk_Paticion50.AutoSize = true;
            this.chk_Paticion50.Location = new System.Drawing.Point(29, 636);
            this.chk_Paticion50.Name = "chk_Paticion50";
            this.chk_Paticion50.Size = new System.Drawing.Size(152, 17);
            this.chk_Paticion50.TabIndex = 32;
            this.chk_Paticion50.Text = "Realizar particiones al 50%";
            this.chk_Paticion50.UseVisualStyleBackColor = true;
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.chk_Paticion50);
            this.Controls.Add(this.myPictureBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trb_Columnas);
            this.Controls.Add(this.trb_Filas);
            this.Controls.Add(this.lbl_Filas);
            this.Controls.Add(this.lbl_Columnas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Generar);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(773, 726);
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Resolución de laberinto";
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            this.Resize += new System.EventHandler(this.Frm_Principal_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trb_Filas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Columnas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Columnas;
        private System.Windows.Forms.Label lbl_Filas;
        private System.Windows.Forms.TrackBar trb_Filas;
        private System.Windows.Forms.TrackBar trb_Columnas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox myPictureBox;
        private System.Windows.Forms.CheckBox chk_Paticion50;
    }
}

