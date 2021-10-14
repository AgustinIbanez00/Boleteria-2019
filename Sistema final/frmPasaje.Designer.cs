namespace Sistema_final
{
    partial class frmPasaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasaje));
            this.dgvPasajeros = new System.Windows.Forms.DataGridView();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRegistrar = new System.Windows.Forms.GroupBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.cbNacionalidad = new System.Windows.Forms.ComboBox();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblPagina = new System.Windows.Forms.Label();
            this.cbFilas = new System.Windows.Forms.ComboBox();
            this.cbPagina = new System.Windows.Forms.ComboBox();
            this.lblNumeroFilas = new System.Windows.Forms.Label();
            this.cbMostrarTodo = new System.Windows.Forms.CheckBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.cbDNI = new System.Windows.Forms.ComboBox();
            this.cbNombre = new System.Windows.Forms.ComboBox();
            this.rbEliminar = new System.Windows.Forms.RadioButton();
            this.rbEditar = new System.Windows.Forms.RadioButton();
            this.rbRegistrar = new System.Windows.Forms.RadioButton();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.lblRegFechaNac = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.rbBuscar = new System.Windows.Forms.RadioButton();
            this.chbDNI = new ReadOnlyCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).BeginInit();
            this.gbRegistrar.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPasajeros
            // 
            this.dgvPasajeros.AllowUserToAddRows = false;
            this.dgvPasajeros.AllowUserToDeleteRows = false;
            this.dgvPasajeros.AllowUserToResizeColumns = false;
            this.dgvPasajeros.AllowUserToResizeRows = false;
            this.dgvPasajeros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPasajeros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPasajeros.BackgroundColor = System.Drawing.Color.White;
            this.dgvPasajeros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPasajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajeros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fila,
            this.Nombre,
            this.DNI,
            this.Nacionalidad,
            this.Genero,
            this.FechaNac});
            this.dgvPasajeros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPasajeros.EnableHeadersVisualStyles = false;
            this.dgvPasajeros.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPasajeros.Location = new System.Drawing.Point(5, 292);
            this.dgvPasajeros.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPasajeros.MultiSelect = false;
            this.dgvPasajeros.Name = "dgvPasajeros";
            this.dgvPasajeros.ReadOnly = true;
            this.dgvPasajeros.RowHeadersVisible = false;
            this.dgvPasajeros.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPasajeros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasajeros.Size = new System.Drawing.Size(860, 207);
            this.dgvPasajeros.TabIndex = 10;
            this.dgvPasajeros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasajeros_CellContentClick);
            this.dgvPasajeros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasajeros_CellDoubleClick);
            this.dgvPasajeros.SelectionChanged += new System.EventHandler(this.dgvPasajeros_SelectionChanged);
            // 
            // Fila
            // 
            this.Fila.FillWeight = 30.45685F;
            this.Fila.HeaderText = "#";
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 123.181F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.FillWeight = 123.181F;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.HeaderText = "Nacionalidad";
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.ReadOnly = true;
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Género";
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            // 
            // FechaNac
            // 
            this.FechaNac.FillWeight = 123.181F;
            this.FechaNac.HeaderText = "Fecha de nacimiento";
            this.FechaNac.Name = "FechaNac";
            this.FechaNac.ReadOnly = true;
            // 
            // gbRegistrar
            // 
            this.gbRegistrar.AutoSize = true;
            this.gbRegistrar.Controls.Add(this.rbBuscar);
            this.gbRegistrar.Controls.Add(this.cbGenero);
            this.gbRegistrar.Controls.Add(this.lblGenero);
            this.gbRegistrar.Controls.Add(this.lblEdad);
            this.gbRegistrar.Controls.Add(this.cbNacionalidad);
            this.gbRegistrar.Controls.Add(this.lblNacionalidad);
            this.gbRegistrar.Controls.Add(this.gbFiltros);
            this.gbRegistrar.Controls.Add(this.cbDNI);
            this.gbRegistrar.Controls.Add(this.cbNombre);
            this.gbRegistrar.Controls.Add(this.rbEliminar);
            this.gbRegistrar.Controls.Add(this.rbEditar);
            this.gbRegistrar.Controls.Add(this.rbRegistrar);
            this.gbRegistrar.Controls.Add(this.dtpFechaNac);
            this.gbRegistrar.Controls.Add(this.lblRegFechaNac);
            this.gbRegistrar.Controls.Add(this.label1);
            this.gbRegistrar.Controls.Add(this.chbDNI);
            this.gbRegistrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRegistrar.Location = new System.Drawing.Point(5, 5);
            this.gbRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.gbRegistrar.Name = "gbRegistrar";
            this.gbRegistrar.Padding = new System.Windows.Forms.Padding(4);
            this.gbRegistrar.Size = new System.Drawing.Size(860, 271);
            this.gbRegistrar.TabIndex = 9;
            this.gbRegistrar.TabStop = false;
            this.gbRegistrar.Text = "Control de pasajeros";
            // 
            // cbGenero
            // 
            this.cbGenero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbGenero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Items.AddRange(new object[] {
            "Sin especificar",
            "Complicado",
            "Femenino",
            "Masculino"});
            this.cbGenero.Location = new System.Drawing.Point(166, 164);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(136, 22);
            this.cbGenero.TabIndex = 19;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(34, 167);
            this.lblGenero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(50, 14);
            this.lblGenero.TabIndex = 18;
            this.lblGenero.Text = "Género:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(313, 113);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(37, 14);
            this.lblEdad.TabIndex = 17;
            this.lblEdad.Text = "Edad:";
            // 
            // cbNacionalidad
            // 
            this.cbNacionalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNacionalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNacionalidad.FormattingEnabled = true;
            this.cbNacionalidad.Items.AddRange(new object[] {
            "Afganistán",
            "Alemania",
            "Arabia Saudita",
            "Argentina",
            "Australia",
            "Bélgica",
            "Bolivia",
            "Brasil",
            "Camboya",
            "Canadá",
            "Chile",
            "China",
            "Colombia",
            "Corea",
            "Costa Rica",
            "Cuba",
            "Dinamarca",
            "Ecuador",
            "Egipto",
            "El Salvador",
            "Escocia",
            "España",
            "Estados Unidos",
            "Estonia",
            "Etiopia",
            "Filipinas",
            "Finlandia",
            "Francia",
            "Gales",
            "Grecia",
            "Guatemala",
            "Haití",
            "Holanda",
            "Honduras",
            "Indonesia",
            "Inglaterra",
            "Irak",
            "Irán",
            "Irlanda",
            "Israel",
            "Italia",
            "Japón",
            "Jordania",
            "Laos",
            "Letonia",
            "Lituania",
            "Malasia",
            "Marruecos",
            "México",
            "Nicaragua",
            "Noruega",
            "Nueva Zelanda",
            "Nueva Zelandia",
            "Panamá",
            "Paraguay",
            "Perú",
            "Polonia",
            "Portugal",
            "Puerto Rico",
            "Republica Dominicana",
            "Rumania",
            "Rusia",
            "Suecia",
            "Suiza",
            "Tailandia",
            "Taiwán",
            "Turquía",
            "Ucrania",
            "Uruguay",
            "Venezuela",
            "Vietnam"});
            this.cbNacionalidad.Location = new System.Drawing.Point(166, 136);
            this.cbNacionalidad.Name = "cbNacionalidad";
            this.cbNacionalidad.Size = new System.Drawing.Size(136, 22);
            this.cbNacionalidad.Sorted = true;
            this.cbNacionalidad.TabIndex = 16;
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Location = new System.Drawing.Point(34, 139);
            this.lblNacionalidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(84, 14);
            this.lblNacionalidad.TabIndex = 15;
            this.lblNacionalidad.Text = "Nacionalidad:";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.lblPagina);
            this.gbFiltros.Controls.Add(this.cbFilas);
            this.gbFiltros.Controls.Add(this.cbPagina);
            this.gbFiltros.Controls.Add(this.lblNumeroFilas);
            this.gbFiltros.Controls.Add(this.cbMostrarTodo);
            this.gbFiltros.Controls.Add(this.btnOperar);
            this.gbFiltros.Location = new System.Drawing.Point(7, 200);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(849, 49);
            this.gbFiltros.TabIndex = 14;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de búsqueda";
            this.gbFiltros.Enter += new System.EventHandler(this.gbFiltros_Enter);
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(108, 22);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(47, 14);
            this.lblPagina.TabIndex = 20;
            this.lblPagina.Text = "Página:";
            // 
            // cbFilas
            // 
            this.cbFilas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilas.FormattingEnabled = true;
            this.cbFilas.Items.AddRange(new object[] {
            "25",
            "50",
            "100",
            "250",
            "500"});
            this.cbFilas.Location = new System.Drawing.Point(331, 18);
            this.cbFilas.Name = "cbFilas";
            this.cbFilas.Size = new System.Drawing.Size(49, 22);
            this.cbFilas.TabIndex = 19;
            this.cbFilas.SelectedIndexChanged += new System.EventHandler(this.cbFilas_SelectedIndexChanged);
            // 
            // cbPagina
            // 
            this.cbPagina.BackColor = System.Drawing.Color.White;
            this.cbPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagina.FormattingEnabled = true;
            this.cbPagina.Location = new System.Drawing.Point(165, 18);
            this.cbPagina.Name = "cbPagina";
            this.cbPagina.Size = new System.Drawing.Size(49, 22);
            this.cbPagina.TabIndex = 18;
            this.cbPagina.SelectedIndexChanged += new System.EventHandler(this.cbPagina_SelectedIndexChanged);
            // 
            // lblNumeroFilas
            // 
            this.lblNumeroFilas.AutoSize = true;
            this.lblNumeroFilas.Location = new System.Drawing.Point(226, 22);
            this.lblNumeroFilas.Name = "lblNumeroFilas";
            this.lblNumeroFilas.Size = new System.Drawing.Size(96, 14);
            this.lblNumeroFilas.TabIndex = 15;
            this.lblNumeroFilas.Text = "Número de filas:";
            // 
            // cbMostrarTodo
            // 
            this.cbMostrarTodo.AutoSize = true;
            this.cbMostrarTodo.Location = new System.Drawing.Point(7, 22);
            this.cbMostrarTodo.Name = "cbMostrarTodo";
            this.cbMostrarTodo.Size = new System.Drawing.Size(96, 18);
            this.cbMostrarTodo.TabIndex = 13;
            this.cbMostrarTodo.Text = "Mostrar todo";
            this.cbMostrarTodo.UseVisualStyleBackColor = true;
            this.cbMostrarTodo.Visible = false;
            this.cbMostrarTodo.CheckedChanged += new System.EventHandler(this.cbMostrarTodo_CheckedChanged);
            // 
            // btnOperar
            // 
            this.btnOperar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOperar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperar.Location = new System.Drawing.Point(723, 12);
            this.btnOperar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(119, 30);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "Registrar";
            this.btnOperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // cbDNI
            // 
            this.cbDNI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDNI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDNI.FormatString = "N0";
            this.cbDNI.FormattingEnabled = true;
            this.cbDNI.Location = new System.Drawing.Point(166, 80);
            this.cbDNI.MaxLength = 8;
            this.cbDNI.Name = "cbDNI";
            this.cbDNI.Size = new System.Drawing.Size(136, 22);
            this.cbDNI.TabIndex = 12;
            this.cbDNI.TextChanged += new System.EventHandler(this.cbDNI_TextChanged);
            this.cbDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDNI_KeyPress_1);
            // 
            // cbNombre
            // 
            this.cbNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbNombre.FormattingEnabled = true;
            this.cbNombre.Location = new System.Drawing.Point(166, 53);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(253, 22);
            this.cbNombre.TabIndex = 11;
            this.cbNombre.TextChanged += new System.EventHandler(this.cbNombre_TextChanged);
            this.cbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbNombre_KeyPress);
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(224, 22);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(71, 18);
            this.rbEliminar.TabIndex = 10;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            this.rbEliminar.CheckedChanged += new System.EventHandler(this.rbEliminar_CheckedChanged);
            // 
            // rbEditar
            // 
            this.rbEditar.AutoSize = true;
            this.rbEditar.Location = new System.Drawing.Point(161, 22);
            this.rbEditar.Name = "rbEditar";
            this.rbEditar.Size = new System.Drawing.Size(57, 18);
            this.rbEditar.TabIndex = 9;
            this.rbEditar.Text = "Editar";
            this.rbEditar.UseVisualStyleBackColor = true;
            this.rbEditar.CheckedChanged += new System.EventHandler(this.rbEditar_CheckedChanged);
            // 
            // rbRegistrar
            // 
            this.rbRegistrar.AutoSize = true;
            this.rbRegistrar.Checked = true;
            this.rbRegistrar.Location = new System.Drawing.Point(81, 22);
            this.rbRegistrar.Name = "rbRegistrar";
            this.rbRegistrar.Size = new System.Drawing.Size(74, 18);
            this.rbRegistrar.TabIndex = 8;
            this.rbRegistrar.Text = "Registrar";
            this.rbRegistrar.UseVisualStyleBackColor = true;
            this.rbRegistrar.CheckedChanged += new System.EventHandler(this.rbRegistrar_CheckedChanged);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(166, 107);
            this.dtpFechaNac.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(136, 22);
            this.dtpFechaNac.TabIndex = 7;
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // lblRegFechaNac
            // 
            this.lblRegFechaNac.AutoSize = true;
            this.lblRegFechaNac.Location = new System.Drawing.Point(34, 113);
            this.lblRegFechaNac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegFechaNac.Name = "lblRegFechaNac";
            this.lblRegFechaNac.Size = new System.Drawing.Size(124, 14);
            this.lblRegFechaNac.TabIndex = 6;
            this.lblRegFechaNac.Text = "Fecha de nacimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "DNI:";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSeleccionar.Location = new System.Drawing.Point(768, 8);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 26);
            this.btnSeleccionar.TabIndex = 11;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnSeleccionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 499);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 39);
            this.panel1.TabIndex = 12;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(672, 8);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 26);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // rbBuscar
            // 
            this.rbBuscar.AutoSize = true;
            this.rbBuscar.Location = new System.Drawing.Point(14, 22);
            this.rbBuscar.Name = "rbBuscar";
            this.rbBuscar.Size = new System.Drawing.Size(61, 18);
            this.rbBuscar.TabIndex = 20;
            this.rbBuscar.Text = "Buscar";
            this.rbBuscar.UseVisualStyleBackColor = true;
            //
            // chbDNI
            //
            this.chbDNI.AutoSize = true;
            this.chbDNI.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbDNI.Checked = true;
            this.chbDNI.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbDNI.Location = new System.Drawing.Point(14, 55);
            this.chbDNI.Name = "chbNombre";
            this.chbDNI.Size = new System.Drawing.Size(72, 18);
            this.chbDNI.TabIndex = 21;
            this.chbDNI.Text = "Nombre:";
            this.chbDNI.UseVisualStyleBackColor = true;
            this.chbDNI.ReadOnly = true;
            this.chbDNI.CheckedChanged += new System.EventHandler(this.chbNombre_CheckedChanged);
            // 
            // frmPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 543);
            this.Controls.Add(this.gbRegistrar);
            this.Controls.Add(this.dgvPasajeros);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPasaje";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de pasajeros";
            this.Load += new System.EventHandler(this.frmPasajeros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).EndInit();
            this.gbRegistrar.ResumeLayout(false);
            this.gbRegistrar.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion
        private System.Windows.Forms.GroupBox gbRegistrar;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label lblRegFechaNac;
        private System.Windows.Forms.Button btnSeleccionar;
        public System.Windows.Forms.DataGridView dgvPasajeros;
        private System.Windows.Forms.RadioButton rbEliminar;
        private System.Windows.Forms.RadioButton rbEditar;
        private System.Windows.Forms.RadioButton rbRegistrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cbDNI;
        private System.Windows.Forms.ComboBox cbNombre;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.CheckBox cbMostrarTodo;
        private System.Windows.Forms.Label lblNumeroFilas;
        private System.Windows.Forms.ComboBox cbPagina;
        private System.Windows.Forms.ComboBox cbFilas;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.ComboBox cbNacionalidad;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNac;
        private System.Windows.Forms.RadioButton rbBuscar;
        private frmPasaje.ReadOnlyCheckBox chbDNI;
    }
}