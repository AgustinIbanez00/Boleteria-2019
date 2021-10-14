namespace Sistema_final
{
    partial class frmLoading
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.cbFilas = new System.Windows.Forms.ComboBox();
            this.cbPagina = new System.Windows.Forms.ComboBox();
            this.lblNumeroFilas = new System.Windows.Forms.Label();
            this.cbMostrarTodo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargando... espera por favor.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseWaitCursor = true;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(113, 166);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(43, 13);
            this.lblPagina.TabIndex = 30;
            this.lblPagina.Text = "Página:";
            // 
            // cbFilas
            // 
            this.cbFilas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilas.FormattingEnabled = true;
            this.cbFilas.Items.AddRange(new object[] {
            "15",
            "30"});
            this.cbFilas.Location = new System.Drawing.Point(336, 162);
            this.cbFilas.Name = "cbFilas";
            this.cbFilas.Size = new System.Drawing.Size(49, 21);
            this.cbFilas.TabIndex = 29;
            // 
            // cbPagina
            // 
            this.cbPagina.BackColor = System.Drawing.Color.White;
            this.cbPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagina.FormattingEnabled = true;
            this.cbPagina.Items.AddRange(new object[] {
            "1"});
            this.cbPagina.Location = new System.Drawing.Point(170, 162);
            this.cbPagina.Name = "cbPagina";
            this.cbPagina.Size = new System.Drawing.Size(49, 21);
            this.cbPagina.TabIndex = 28;
            // 
            // lblNumeroFilas
            // 
            this.lblNumeroFilas.AutoSize = true;
            this.lblNumeroFilas.Location = new System.Drawing.Point(231, 166);
            this.lblNumeroFilas.Name = "lblNumeroFilas";
            this.lblNumeroFilas.Size = new System.Drawing.Size(83, 13);
            this.lblNumeroFilas.TabIndex = 27;
            this.lblNumeroFilas.Text = "Número de filas:";
            // 
            // cbMostrarTodo
            // 
            this.cbMostrarTodo.AutoSize = true;
            this.cbMostrarTodo.Location = new System.Drawing.Point(12, 166);
            this.cbMostrarTodo.Name = "cbMostrarTodo";
            this.cbMostrarTodo.Size = new System.Drawing.Size(85, 17);
            this.cbMostrarTodo.TabIndex = 26;
            this.cbMostrarTodo.Text = "Mostrar todo";
            this.cbMostrarTodo.UseVisualStyleBackColor = true;
            this.cbMostrarTodo.Visible = false;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(510, 195);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.cbFilas);
            this.Controls.Add(this.cbPagina);
            this.Controls.Add(this.lblNumeroFilas);
            this.Controls.Add(this.cbMostrarTodo);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLoading";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargando...";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmLoading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.ComboBox cbFilas;
        private System.Windows.Forms.ComboBox cbPagina;
        private System.Windows.Forms.Label lblNumeroFilas;
        private System.Windows.Forms.CheckBox cbMostrarTodo;
    }
}