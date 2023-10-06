namespace Lab_2_Sz
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Subtitulo = new System.Windows.Forms.Label();
            this.opcion = new System.Windows.Forms.ComboBox();
            this.fRecta1 = new System.Windows.Forms.TextBox();
            this.fRecta2 = new System.Windows.Forms.TextBox();
            this.fPuntoPend1 = new System.Windows.Forms.TextBox();
            this.fPuntoPend2 = new System.Windows.Forms.TextBox();
            this.btnObtener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Subtitulo
            // 
            this.Subtitulo.AutoSize = true;
            this.Subtitulo.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitulo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Subtitulo.Location = new System.Drawing.Point(103, 32);
            this.Subtitulo.Name = "Subtitulo";
            this.Subtitulo.Size = new System.Drawing.Size(502, 34);
            this.Subtitulo.TabIndex = 0;
            this.Subtitulo.Text = "Selecciona la forma en la que quieres escribir tus rectas";
            // 
            // opcion
            // 
            this.opcion.FormattingEnabled = true;
            this.opcion.Items.AddRange(new object[] {
            "y = mx+b",
            "y-yo = m(x-xo)"});
            this.opcion.Location = new System.Drawing.Point(293, 69);
            this.opcion.Name = "opcion";
            this.opcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.opcion.Size = new System.Drawing.Size(121, 21);
            this.opcion.TabIndex = 1;
            this.opcion.Text = "Ecuacion";
            this.opcion.SelectedIndexChanged += new System.EventHandler(this.opcionEleg);
            // 
            // fRecta1
            // 
            this.fRecta1.Location = new System.Drawing.Point(107, 110);
            this.fRecta1.Name = "fRecta1";
            this.fRecta1.Size = new System.Drawing.Size(148, 20);
            this.fRecta1.TabIndex = 2;
            this.fRecta1.Text = "Ingresa tu primera recta";
            this.fRecta1.Visible = false;
            this.fRecta1.ForeColorChanged += new System.EventHandler(this.fRecta1_Textcolor);
            this.fRecta1.TextChanged += new System.EventHandler(this.fRecta1_TextChanged_1);
            this.fRecta1.Enter += new System.EventHandler(this.fRecta1_Enter);
            this.fRecta1.Leave += new System.EventHandler(this.fRecta1_Leave);
            // 
            // fRecta2
            // 
            this.fRecta2.Location = new System.Drawing.Point(107, 136);
            this.fRecta2.Name = "fRecta2";
            this.fRecta2.Size = new System.Drawing.Size(148, 20);
            this.fRecta2.TabIndex = 3;
            this.fRecta2.Text = "Ingresa tu segunda recta";
            this.fRecta2.Visible = false;
            this.fRecta2.Click += new System.EventHandler(this.fRecta2_TextChanged);
            this.fRecta2.Enter += new System.EventHandler(this.fRecta2_Enter);
            this.fRecta2.Leave += new System.EventHandler(this.fRecta2_Leave);
            // 
            // fPuntoPend1
            // 
            this.fPuntoPend1.Location = new System.Drawing.Point(107, 162);
            this.fPuntoPend1.Name = "fPuntoPend1";
            this.fPuntoPend1.Size = new System.Drawing.Size(148, 20);
            this.fPuntoPend1.TabIndex = 4;
            this.fPuntoPend1.Text = "Ingresa tu primera recta";
            this.fPuntoPend1.Visible = false;
            this.fPuntoPend1.Enter += new System.EventHandler(this.fPuntoPend1_Enter);
            this.fPuntoPend1.Leave += new System.EventHandler(this.fPuntoPend1_Leave);
            // 
            // fPuntoPend2
            // 
            this.fPuntoPend2.Location = new System.Drawing.Point(107, 188);
            this.fPuntoPend2.Name = "fPuntoPend2";
            this.fPuntoPend2.Size = new System.Drawing.Size(148, 20);
            this.fPuntoPend2.TabIndex = 5;
            this.fPuntoPend2.Text = "Ingresa tu segunda recta";
            this.fPuntoPend2.Visible = false;
            this.fPuntoPend2.Enter += new System.EventHandler(this.fPuntoPend2_Enter);
            this.fPuntoPend2.Leave += new System.EventHandler(this.fPuntoPend2_Leave);
            // 
            // btnObtener
            // 
            this.btnObtener.BackColor = System.Drawing.Color.LightGray;
            this.btnObtener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtener.Location = new System.Drawing.Point(350, 124);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(75, 23);
            this.btnObtener.TabIndex = 6;
            this.btnObtener.Text = "Obtener";
            this.btnObtener.UseVisualStyleBackColor = false;
            this.btnObtener.Visible = false;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Esperando que hagas algo...\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 65);
            this.label2.TabIndex = 8;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObtener);
            this.Controls.Add(this.fPuntoPend2);
            this.Controls.Add(this.fPuntoPend1);
            this.Controls.Add(this.fRecta2);
            this.Controls.Add(this.fRecta1);
            this.Controls.Add(this.opcion);
            this.Controls.Add(this.Subtitulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Subtitulo;
        private System.Windows.Forms.ComboBox opcion;
        private System.Windows.Forms.TextBox fRecta1;
        private System.Windows.Forms.TextBox fRecta2;
        private System.Windows.Forms.TextBox fPuntoPend1;
        private System.Windows.Forms.TextBox fPuntoPend2;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

