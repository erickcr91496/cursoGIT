namespace NavigationDrawerPopUpMenu2
{
    partial class FrmTransicion
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
            this.button1 = new System.Windows.Forms.Button();
            this.tblTransicion = new System.Windows.Forms.DataGridView();
            this.btnAbrirArchivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblTransicion)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tblTransicion
            // 
            this.tblTransicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTransicion.Location = new System.Drawing.Point(23, 70);
            this.tblTransicion.Name = "tblTransicion";
            this.tblTransicion.RowHeadersWidth = 51;
            this.tblTransicion.RowTemplate.Height = 24;
            this.tblTransicion.Size = new System.Drawing.Size(1002, 457);
            this.tblTransicion.TabIndex = 1;
            // 
            // btnAbrirArchivo
            // 
            this.btnAbrirArchivo.Location = new System.Drawing.Point(130, 12);
            this.btnAbrirArchivo.Name = "btnAbrirArchivo";
            this.btnAbrirArchivo.Size = new System.Drawing.Size(97, 43);
            this.btnAbrirArchivo.TabIndex = 2;
            this.btnAbrirArchivo.Text = "Abrir";
            this.btnAbrirArchivo.UseVisualStyleBackColor = true;
            this.btnAbrirArchivo.Click += new System.EventHandler(this.butto_Click);
            // 
            // FrmTransicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 651);
            this.ControlBox = false;
            this.Controls.Add(this.btnAbrirArchivo);
            this.Controls.Add(this.tblTransicion);
            this.Controls.Add(this.button1);
            this.Name = "FrmTransicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTransicion";
            ((System.ComponentModel.ISupportInitialize)(this.tblTransicion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tblTransicion;
        private System.Windows.Forms.Button btnAbrirArchivo;
    }
}