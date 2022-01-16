namespace Boleteria
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separador = new System.Windows.Forms.ToolStripSeparator();
            this.venderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.tcHoraServer = new Controles.TimerControl();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpPasajes = new System.Windows.Forms.TabPage();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlPasajes = new System.Windows.Forms.Panel();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.dgvBoletos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trayecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emitido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.tbPagina = new System.Windows.Forms.TextBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.gbVuelta = new System.Windows.Forms.GroupBox();
            this.cbHoraSalidaVuelta = new System.Windows.Forms.ComboBox();
            this.dtpHoraLlegadVuelta = new System.Windows.Forms.DateTimePicker();
            this.tbAsientoVuelta = new System.Windows.Forms.TextBox();
            this.dtpFechaVuelta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVuelta = new System.Windows.Forms.Label();
            this.lblAsientoVuelta = new System.Windows.Forms.Label();
            this.btnMasAsientosVuelta = new System.Windows.Forms.Button();
            this.lblHoraLLegadaVuelta = new System.Windows.Forms.Label();
            this.lblHoraSalidaVuelta = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.gbIda = new System.Windows.Forms.GroupBox();
            this.cbHoraSalidaIda = new System.Windows.Forms.ComboBox();
            this.dtpHoraLlegadaIda = new System.Windows.Forms.DateTimePicker();
            this.tbAsientoIda = new System.Windows.Forms.TextBox();
            this.dtpFechaIda = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIda = new System.Windows.Forms.Label();
            this.lblAsientoIda = new System.Windows.Forms.Label();
            this.btnMasAsientosIda = new System.Windows.Forms.Button();
            this.lblHoraLlegadaIda = new System.Windows.Forms.Label();
            this.lblHoraSalidaIda = new System.Windows.Forms.Label();
            this.cbTrayecto = new System.Windows.Forms.ComboBox();
            this.lblTrayecto = new System.Windows.Forms.Label();
            this.gbBuscarPasaje = new System.Windows.Forms.GroupBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.rbFiltrosExpirados = new System.Windows.Forms.RadioButton();
            this.rbFiltrosRecorrido = new System.Windows.Forms.RadioButton();
            this.rbFiltrosVendidos = new System.Windows.Forms.RadioButton();
            this.rbFiltrosPendientes = new System.Windows.Forms.RadioButton();
            this.rbFiltrosDiaHoy = new System.Windows.Forms.RadioButton();
            this.rbFiltroTodos = new System.Windows.Forms.RadioButton();
            this.btnDistrCrear = new System.Windows.Forms.Button();
            this.dtpBusPasFecha = new System.Windows.Forms.DateTimePicker();
            this.cbBusPasDestino = new System.Windows.Forms.ComboBox();
            this.cbPasBusOrigen = new System.Windows.Forms.ComboBox();
            this.cbPasBusPasajeroDNI = new System.Windows.Forms.ComboBox();
            this.cbPasBusPasajeroNombre = new System.Windows.Forms.ComboBox();
            this.chbBusPasFecha = new System.Windows.Forms.CheckBox();
            this.chbBusPasDestino = new System.Windows.Forms.CheckBox();
            this.chbBusPasOrigen = new System.Windows.Forms.CheckBox();
            this.chbBusPasPasajeroDNI = new System.Windows.Forms.CheckBox();
            this.chbBusPasPasajeroNombre = new System.Windows.Forms.CheckBox();
            this.gbPasajeros = new System.Windows.Forms.GroupBox();
            this.cbPasDNI = new System.Windows.Forms.ComboBox();
            this.cbPasNombre = new System.Windows.Forms.ComboBox();
            this.btnBuscarPasajeros = new System.Windows.Forms.Button();
            this.btnMasPasajeros = new System.Windows.Forms.Button();
            this.lblPasDNI = new System.Windows.Forms.Label();
            this.lblPasNombre = new System.Windows.Forms.Label();
            this.btnVender = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbBoleto = new System.Windows.Forms.ComboBox();
            this.btnMasOrigen = new System.Windows.Forms.Button();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.tpViajes = new System.Windows.Forms.TabPage();
            this.gbViajesHorarios = new System.Windows.Forms.GroupBox();
            this.pnlViajeHorariosTodos = new System.Windows.Forms.Panel();
            this.cbViajesHorariosTodos = new System.Windows.Forms.CheckBox();
            this.rbViajesPrecios = new System.Windows.Forms.RadioButton();
            this.rbViajesHorarios = new System.Windows.Forms.RadioButton();
            this.dgvViajeTrayectos = new System.Windows.Forms.DataGridView();
            this.gbPBModEspacio = new System.Windows.Forms.GroupBox();
            this.rbPA = new System.Windows.Forms.RadioButton();
            this.rbPB = new System.Windows.Forms.RadioButton();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.C1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.C4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.C5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.C2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.C3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblViajeFrecuencia = new System.Windows.Forms.Label();
            this.clbViajeFrecuencia = new System.Windows.Forms.CheckedListBox();
            this.lblViajeHorario = new System.Windows.Forms.Label();
            this.lblViajeRecorrido = new System.Windows.Forms.Label();
            this.cbViajeHoraSalida = new System.Windows.Forms.ComboBox();
            this.cbViajeTrayecto = new System.Windows.Forms.ComboBox();
            this.tpReportes = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInformeRecorrido = new System.Windows.Forms.RadioButton();
            this.rbInformePasajero = new System.Windows.Forms.RadioButton();
            this.cbInformeTrayecto = new System.Windows.Forms.ComboBox();
            this.btnInforme = new System.Windows.Forms.Button();
            this.cbInformePasajero = new System.Windows.Forms.ComboBox();
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirFuenteDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apartadosAdministrativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boletosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorDeRecorridosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorDePasajerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDirectorioPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idaYVueltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verLaAyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.bsViajes = new System.Windows.Forms.BindingSource(this.components);
            this.cmsOpciones.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tcOpciones.SuspendLayout();
            this.tpPasajes.SuspendLayout();
            this.pnlPasajes.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletos)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.gbVuelta.SuspendLayout();
            this.gbIda.SuspendLayout();
            this.gbBuscarPasaje.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.gbPasajeros.SuspendLayout();
            this.tpViajes.SuspendLayout();
            this.gbViajesHorarios.SuspendLayout();
            this.pnlViajeHorariosTodos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeTrayectos)).BeginInit();
            this.gbPBModEspacio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.tpReportes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.msPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verInfoItem,
            this.separador,
            this.venderItem,
            this.cancelarItem});
            this.cmsOpciones.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(140, 76);
            // 
            // verInfoItem
            // 
            this.verInfoItem.Image = global::Boleteria.Properties.Resources.nuevo1;
            this.verInfoItem.Name = "verInfoItem";
            this.verInfoItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.verInfoItem.Size = new System.Drawing.Size(139, 22);
            this.verInfoItem.Text = "Imprimir";
            this.verInfoItem.Click += new System.EventHandler(this.verInfoItem_Click);
            // 
            // separador
            // 
            this.separador.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.separador.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(136, 6);
            // 
            // venderItem
            // 
            this.venderItem.Image = global::Boleteria.Properties.Resources.carrito;
            this.venderItem.Name = "venderItem";
            this.venderItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.venderItem.Size = new System.Drawing.Size(139, 22);
            this.venderItem.Text = "Vender";
            this.venderItem.Click += new System.EventHandler(this.venderToolStripMenuItem_Click);
            // 
            // cancelarItem
            // 
            this.cancelarItem.Image = global::Boleteria.Properties.Resources.borrar;
            this.cancelarItem.Name = "cancelarItem";
            this.cancelarItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.cancelarItem.Size = new System.Drawing.Size(139, 22);
            this.cancelarItem.Text = "Cancelar";
            this.cancelarItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrincipal.Controls.Add(this.tcHoraServer);
            this.pnlPrincipal.Controls.Add(this.btnPerfil);
            this.pnlPrincipal.Controls.Add(this.tcOpciones);
            this.pnlPrincipal.Controls.Add(this.msPrincipal);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1069, 601);
            this.pnlPrincipal.TabIndex = 4;
            // 
            // tcHoraServer
            // 
            this.tcHoraServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tcHoraServer.BackColor = System.Drawing.Color.Transparent;
            this.tcHoraServer.Date = new System.DateTime(1, 1, 1, 21, 8, 57, 0);
            this.tcHoraServer.Location = new System.Drawing.Point(812, 24);
            this.tcHoraServer.Name = "tcHoraServer";
            this.tcHoraServer.Size = new System.Drawing.Size(201, 24);
            this.tcHoraServer.TabIndex = 9;
            this.tcHoraServer.Load += new System.EventHandler(this.tcHoraServer_Load);
            // 
            // btnPerfil
            // 
            this.btnPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPerfil.AutoSize = true;
            this.btnPerfil.BackgroundImage = global::Boleteria.Properties.Resources.usuario_hombre;
            this.btnPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPerfil.FlatAppearance.BorderSize = 10;
            this.btnPerfil.Location = new System.Drawing.Point(1019, 12);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(38, 36);
            this.btnPerfil.TabIndex = 5;
            this.btnPerfil.UseVisualStyleBackColor = true;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // tcOpciones
            // 
            this.tcOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcOpciones.Controls.Add(this.tpPasajes);
            this.tcOpciones.Controls.Add(this.tpViajes);
            this.tcOpciones.Controls.Add(this.tpReportes);
            this.tcOpciones.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcOpciones.Location = new System.Drawing.Point(12, 34);
            this.tcOpciones.Multiline = true;
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(1045, 555);
            this.tcOpciones.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcOpciones.TabIndex = 7;
            // 
            // tpPasajes
            // 
            this.tpPasajes.AutoScroll = true;
            this.tpPasajes.Controls.Add(this.lblInfo);
            this.tpPasajes.Controls.Add(this.pnlPasajes);
            this.tpPasajes.Location = new System.Drawing.Point(4, 23);
            this.tpPasajes.Name = "tpPasajes";
            this.tpPasajes.Padding = new System.Windows.Forms.Padding(3);
            this.tpPasajes.Size = new System.Drawing.Size(1037, 528);
            this.tpPasajes.TabIndex = 1;
            this.tpPasajes.Text = "Pasajes";
            this.tpPasajes.UseVisualStyleBackColor = true;
            this.tpPasajes.Click += new System.EventHandler(this.tpPasajes_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Location = new System.Drawing.Point(3, 511);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(67, 14);
            this.lblInfo.TabIndex = 29;
            this.lblInfo.Text = "Destinos: 0";
            // 
            // pnlPasajes
            // 
            this.pnlPasajes.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlPasajes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlPasajes.Controls.Add(this.gbResultados);
            this.pnlPasajes.Controls.Add(this.gbVuelta);
            this.pnlPasajes.Controls.Add(this.lblPrecio);
            this.pnlPasajes.Controls.Add(this.gbIda);
            this.pnlPasajes.Controls.Add(this.cbTrayecto);
            this.pnlPasajes.Controls.Add(this.lblTrayecto);
            this.pnlPasajes.Controls.Add(this.gbBuscarPasaje);
            this.pnlPasajes.Controls.Add(this.gbPasajeros);
            this.pnlPasajes.Controls.Add(this.btnVender);
            this.pnlPasajes.Controls.Add(this.lblTipo);
            this.pnlPasajes.Controls.Add(this.cbBoleto);
            this.pnlPasajes.Controls.Add(this.btnMasOrigen);
            this.pnlPasajes.Controls.Add(this.lblOrigen);
            this.pnlPasajes.Controls.Add(this.cbOrigen);
            this.pnlPasajes.Controls.Add(this.lblDestino);
            this.pnlPasajes.Controls.Add(this.cbDestino);
            this.pnlPasajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPasajes.Location = new System.Drawing.Point(3, 3);
            this.pnlPasajes.Name = "pnlPasajes";
            this.pnlPasajes.Size = new System.Drawing.Size(1031, 522);
            this.pnlPasajes.TabIndex = 30;
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Controls.Add(this.dgvBoletos);
            this.gbResultados.Controls.Add(this.pnlBotones);
            this.gbResultados.Location = new System.Drawing.Point(23, 365);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(855, 157);
            this.gbResultados.TabIndex = 41;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados:";
            // 
            // dgvBoletos
            // 
            this.dgvBoletos.AllowUserToAddRows = false;
            this.dgvBoletos.AllowUserToDeleteRows = false;
            this.dgvBoletos.AllowUserToResizeColumns = false;
            this.dgvBoletos.AllowUserToResizeRows = false;
            this.dgvBoletos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBoletos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBoletos.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoletos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBoletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoletos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Trayecto,
            this.Pasajero,
            this.Vendedor,
            this.Emitido,
            this.Origen,
            this.Destino,
            this.Fecha,
            this.HoraSalida,
            this.Asiento,
            this.Estado,
            this.Pago});
            this.dgvBoletos.ContextMenuStrip = this.cmsOpciones;
            this.dgvBoletos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoletos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBoletos.EnableHeadersVisualStyles = false;
            this.dgvBoletos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvBoletos.Location = new System.Drawing.Point(3, 18);
            this.dgvBoletos.MultiSelect = false;
            this.dgvBoletos.Name = "dgvBoletos";
            this.dgvBoletos.ReadOnly = true;
            this.dgvBoletos.RowHeadersVisible = false;
            this.dgvBoletos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBoletos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoletos.Size = new System.Drawing.Size(849, 102);
            this.dgvBoletos.TabIndex = 43;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ID.FillWeight = 60.9137F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 44;
            // 
            // Trayecto
            // 
            this.Trayecto.FillWeight = 98.59884F;
            this.Trayecto.HeaderText = "Recorrido";
            this.Trayecto.Name = "Trayecto";
            this.Trayecto.ReadOnly = true;
            this.Trayecto.Width = 84;
            // 
            // Pasajero
            // 
            this.Pasajero.FillWeight = 238.5455F;
            this.Pasajero.HeaderText = "Pasajero";
            this.Pasajero.Name = "Pasajero";
            this.Pasajero.ReadOnly = true;
            this.Pasajero.Width = 79;
            // 
            // Vendedor
            // 
            this.Vendedor.FillWeight = 98.59884F;
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Width = 84;
            // 
            // Emitido
            // 
            this.Emitido.FillWeight = 98.59884F;
            this.Emitido.HeaderText = "Emitido";
            this.Emitido.Name = "Emitido";
            this.Emitido.ReadOnly = true;
            this.Emitido.Width = 73;
            // 
            // Origen
            // 
            this.Origen.FillWeight = 98.59884F;
            this.Origen.HeaderText = "Sale de";
            this.Origen.Name = "Origen";
            this.Origen.ReadOnly = true;
            this.Origen.Width = 73;
            // 
            // Destino
            // 
            this.Destino.FillWeight = 98.59884F;
            this.Destino.HeaderText = "Llega a";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            this.Destino.Width = 71;
            // 
            // Fecha
            // 
            this.Fecha.FillWeight = 98.59884F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 64;
            // 
            // HoraSalida
            // 
            this.HoraSalida.FillWeight = 73.96663F;
            this.HoraSalida.HeaderText = "Sale a la(s)";
            this.HoraSalida.Name = "HoraSalida";
            this.HoraSalida.ReadOnly = true;
            this.HoraSalida.Width = 94;
            // 
            // Asiento
            // 
            this.Asiento.FillWeight = 37.78306F;
            this.Asiento.HeaderText = "Butaca";
            this.Asiento.Name = "Asiento";
            this.Asiento.ReadOnly = true;
            this.Asiento.Width = 69;
            // 
            // Estado
            // 
            this.Estado.FillWeight = 98.59884F;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 69;
            // 
            // Pago
            // 
            this.Pago.FillWeight = 98.59884F;
            this.Pago.HeaderText = "Pagado con";
            this.Pago.Name = "Pago";
            this.Pago.ReadOnly = true;
            this.Pago.Width = 94;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnUltimo);
            this.pnlBotones.Controls.Add(this.btnSiguiente);
            this.pnlBotones.Controls.Add(this.tbPagina);
            this.pnlBotones.Controls.Add(this.btnAnterior);
            this.pnlBotones.Controls.Add(this.btnPrimero);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(3, 120);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(849, 34);
            this.pnlBotones.TabIndex = 42;
            // 
            // btnUltimo
            // 
            this.btnUltimo.AutoSize = true;
            this.btnUltimo.Location = new System.Drawing.Point(611, 3);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(75, 24);
            this.btnUltimo.TabIndex = 41;
            this.btnUltimo.Text = "Último";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.AutoSize = true;
            this.btnSiguiente.Location = new System.Drawing.Point(530, 3);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 24);
            this.btnSiguiente.TabIndex = 40;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // tbPagina
            // 
            this.tbPagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPagina.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbPagina.Enabled = false;
            this.tbPagina.Location = new System.Drawing.Point(424, 3);
            this.tbPagina.Name = "tbPagina";
            this.tbPagina.Size = new System.Drawing.Size(100, 22);
            this.tbPagina.TabIndex = 39;
            this.tbPagina.Text = "Pagina: 1/1";
            this.tbPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAnterior
            // 
            this.btnAnterior.AutoSize = true;
            this.btnAnterior.Location = new System.Drawing.Point(343, 3);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 24);
            this.btnAnterior.TabIndex = 38;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.AutoSize = true;
            this.btnPrimero.Location = new System.Drawing.Point(262, 3);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(75, 24);
            this.btnPrimero.TabIndex = 37;
            this.btnPrimero.Text = "Primero";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // gbVuelta
            // 
            this.gbVuelta.Controls.Add(this.cbHoraSalidaVuelta);
            this.gbVuelta.Controls.Add(this.dtpHoraLlegadVuelta);
            this.gbVuelta.Controls.Add(this.tbAsientoVuelta);
            this.gbVuelta.Controls.Add(this.dtpFechaVuelta);
            this.gbVuelta.Controls.Add(this.lblFechaVuelta);
            this.gbVuelta.Controls.Add(this.lblAsientoVuelta);
            this.gbVuelta.Controls.Add(this.btnMasAsientosVuelta);
            this.gbVuelta.Controls.Add(this.lblHoraLLegadaVuelta);
            this.gbVuelta.Controls.Add(this.lblHoraSalidaVuelta);
            this.gbVuelta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbVuelta.Location = new System.Drawing.Point(747, 159);
            this.gbVuelta.Name = "gbVuelta";
            this.gbVuelta.Size = new System.Drawing.Size(200, 136);
            this.gbVuelta.TabIndex = 40;
            this.gbVuelta.TabStop = false;
            this.gbVuelta.Text = "Vuelta";
            this.gbVuelta.Visible = false;
            // 
            // cbHoraSalidaVuelta
            // 
            this.cbHoraSalidaVuelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraSalidaVuelta.FormattingEnabled = true;
            this.cbHoraSalidaVuelta.Location = new System.Drawing.Point(91, 79);
            this.cbHoraSalidaVuelta.Name = "cbHoraSalidaVuelta";
            this.cbHoraSalidaVuelta.Size = new System.Drawing.Size(74, 22);
            this.cbHoraSalidaVuelta.TabIndex = 39;
            // 
            // dtpHoraLlegadVuelta
            // 
            this.dtpHoraLlegadVuelta.Enabled = false;
            this.dtpHoraLlegadVuelta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraLlegadVuelta.Location = new System.Drawing.Point(91, 109);
            this.dtpHoraLlegadVuelta.Name = "dtpHoraLlegadVuelta";
            this.dtpHoraLlegadVuelta.ShowUpDown = true;
            this.dtpHoraLlegadVuelta.Size = new System.Drawing.Size(74, 22);
            this.dtpHoraLlegadVuelta.TabIndex = 38;
            this.dtpHoraLlegadVuelta.Value = new System.DateTime(2018, 12, 11, 0, 0, 0, 0);
            // 
            // tbAsientoVuelta
            // 
            this.tbAsientoVuelta.Enabled = false;
            this.tbAsientoVuelta.Location = new System.Drawing.Point(91, 51);
            this.tbAsientoVuelta.Name = "tbAsientoVuelta";
            this.tbAsientoVuelta.Size = new System.Drawing.Size(35, 22);
            this.tbAsientoVuelta.TabIndex = 36;
            this.tbAsientoVuelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaVuelta
            // 
            this.dtpFechaVuelta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVuelta.Location = new System.Drawing.Point(91, 23);
            this.dtpFechaVuelta.Name = "dtpFechaVuelta";
            this.dtpFechaVuelta.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaVuelta.TabIndex = 28;
            // 
            // lblFechaVuelta
            // 
            this.lblFechaVuelta.AutoSize = true;
            this.lblFechaVuelta.Location = new System.Drawing.Point(6, 24);
            this.lblFechaVuelta.Name = "lblFechaVuelta";
            this.lblFechaVuelta.Size = new System.Drawing.Size(42, 14);
            this.lblFechaVuelta.TabIndex = 27;
            this.lblFechaVuelta.Text = "Fecha:";
            // 
            // lblAsientoVuelta
            // 
            this.lblAsientoVuelta.AutoSize = true;
            this.lblAsientoVuelta.Location = new System.Drawing.Point(6, 53);
            this.lblAsientoVuelta.Name = "lblAsientoVuelta";
            this.lblAsientoVuelta.Size = new System.Drawing.Size(52, 14);
            this.lblAsientoVuelta.TabIndex = 25;
            this.lblAsientoVuelta.Text = "Asiento:";
            // 
            // btnMasAsientosVuelta
            // 
            this.btnMasAsientosVuelta.AutoSize = true;
            this.btnMasAsientosVuelta.BackColor = System.Drawing.Color.Transparent;
            this.btnMasAsientosVuelta.BackgroundImage = global::Boleteria.Properties.Resources.agregar1;
            this.btnMasAsientosVuelta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMasAsientosVuelta.Location = new System.Drawing.Point(132, 51);
            this.btnMasAsientosVuelta.Name = "btnMasAsientosVuelta";
            this.btnMasAsientosVuelta.Size = new System.Drawing.Size(23, 23);
            this.btnMasAsientosVuelta.TabIndex = 26;
            this.btnMasAsientosVuelta.UseVisualStyleBackColor = false;
            // 
            // lblHoraLLegadaVuelta
            // 
            this.lblHoraLLegadaVuelta.AutoSize = true;
            this.lblHoraLLegadaVuelta.Location = new System.Drawing.Point(6, 111);
            this.lblHoraLLegadaVuelta.Name = "lblHoraLLegadaVuelta";
            this.lblHoraLLegadaVuelta.Size = new System.Drawing.Size(81, 14);
            this.lblHoraLLegadaVuelta.TabIndex = 35;
            this.lblHoraLLegadaVuelta.Text = "Hora llegada:";
            // 
            // lblHoraSalidaVuelta
            // 
            this.lblHoraSalidaVuelta.AutoSize = true;
            this.lblHoraSalidaVuelta.Location = new System.Drawing.Point(6, 82);
            this.lblHoraSalidaVuelta.Name = "lblHoraSalidaVuelta";
            this.lblHoraSalidaVuelta.Size = new System.Drawing.Size(74, 14);
            this.lblHoraSalidaVuelta.TabIndex = 34;
            this.lblHoraSalidaVuelta.Text = "Hora salida:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(547, 45);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(65, 17);
            this.lblPrecio.TabIndex = 24;
            this.lblPrecio.Text = "Precio: $0";
            // 
            // gbIda
            // 
            this.gbIda.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.gbIda.Controls.Add(this.cbHoraSalidaIda);
            this.gbIda.Controls.Add(this.dtpHoraLlegadaIda);
            this.gbIda.Controls.Add(this.tbAsientoIda);
            this.gbIda.Controls.Add(this.dtpFechaIda);
            this.gbIda.Controls.Add(this.lblFechaIda);
            this.gbIda.Controls.Add(this.lblAsientoIda);
            this.gbIda.Controls.Add(this.btnMasAsientosIda);
            this.gbIda.Controls.Add(this.lblHoraLlegadaIda);
            this.gbIda.Controls.Add(this.lblHoraSalidaIda);
            this.gbIda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbIda.Location = new System.Drawing.Point(541, 159);
            this.gbIda.Name = "gbIda";
            this.gbIda.Size = new System.Drawing.Size(200, 136);
            this.gbIda.TabIndex = 39;
            this.gbIda.TabStop = false;
            this.gbIda.Text = "Ida";
            // 
            // cbHoraSalidaIda
            // 
            this.cbHoraSalidaIda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraSalidaIda.FormattingEnabled = true;
            this.cbHoraSalidaIda.Location = new System.Drawing.Point(91, 79);
            this.cbHoraSalidaIda.Name = "cbHoraSalidaIda";
            this.cbHoraSalidaIda.Size = new System.Drawing.Size(74, 22);
            this.cbHoraSalidaIda.TabIndex = 39;
            this.cbHoraSalidaIda.SelectedIndexChanged += new System.EventHandler(this.cbHoraSalidaIda_SelectedIndexChanged);
            // 
            // dtpHoraLlegadaIda
            // 
            this.dtpHoraLlegadaIda.Enabled = false;
            this.dtpHoraLlegadaIda.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraLlegadaIda.Location = new System.Drawing.Point(91, 109);
            this.dtpHoraLlegadaIda.Name = "dtpHoraLlegadaIda";
            this.dtpHoraLlegadaIda.ShowUpDown = true;
            this.dtpHoraLlegadaIda.Size = new System.Drawing.Size(74, 22);
            this.dtpHoraLlegadaIda.TabIndex = 38;
            this.dtpHoraLlegadaIda.Value = new System.DateTime(2018, 12, 11, 0, 0, 0, 0);
            // 
            // tbAsientoIda
            // 
            this.tbAsientoIda.Enabled = false;
            this.tbAsientoIda.Location = new System.Drawing.Point(91, 51);
            this.tbAsientoIda.Name = "tbAsientoIda";
            this.tbAsientoIda.Size = new System.Drawing.Size(35, 22);
            this.tbAsientoIda.TabIndex = 36;
            this.tbAsientoIda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaIda
            // 
            this.dtpFechaIda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIda.Location = new System.Drawing.Point(91, 23);
            this.dtpFechaIda.Name = "dtpFechaIda";
            this.dtpFechaIda.Size = new System.Drawing.Size(103, 22);
            this.dtpFechaIda.TabIndex = 28;
            this.dtpFechaIda.ValueChanged += new System.EventHandler(this.dtpFechaIda_ValueChanged);
            // 
            // lblFechaIda
            // 
            this.lblFechaIda.AutoSize = true;
            this.lblFechaIda.Location = new System.Drawing.Point(6, 24);
            this.lblFechaIda.Name = "lblFechaIda";
            this.lblFechaIda.Size = new System.Drawing.Size(42, 14);
            this.lblFechaIda.TabIndex = 27;
            this.lblFechaIda.Text = "Fecha:";
            // 
            // lblAsientoIda
            // 
            this.lblAsientoIda.AutoSize = true;
            this.lblAsientoIda.Location = new System.Drawing.Point(6, 53);
            this.lblAsientoIda.Name = "lblAsientoIda";
            this.lblAsientoIda.Size = new System.Drawing.Size(52, 14);
            this.lblAsientoIda.TabIndex = 25;
            this.lblAsientoIda.Text = "Asiento:";
            // 
            // btnMasAsientosIda
            // 
            this.btnMasAsientosIda.AutoSize = true;
            this.btnMasAsientosIda.BackColor = System.Drawing.Color.Transparent;
            this.btnMasAsientosIda.BackgroundImage = global::Boleteria.Properties.Resources.agregar1;
            this.btnMasAsientosIda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMasAsientosIda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasAsientosIda.Location = new System.Drawing.Point(132, 51);
            this.btnMasAsientosIda.Name = "btnMasAsientosIda";
            this.btnMasAsientosIda.Size = new System.Drawing.Size(23, 23);
            this.btnMasAsientosIda.TabIndex = 26;
            this.btnMasAsientosIda.UseVisualStyleBackColor = false;
            this.btnMasAsientosIda.Click += new System.EventHandler(this.btnMasAsientos_Click);
            // 
            // lblHoraLlegadaIda
            // 
            this.lblHoraLlegadaIda.AutoSize = true;
            this.lblHoraLlegadaIda.Location = new System.Drawing.Point(6, 111);
            this.lblHoraLlegadaIda.Name = "lblHoraLlegadaIda";
            this.lblHoraLlegadaIda.Size = new System.Drawing.Size(81, 14);
            this.lblHoraLlegadaIda.TabIndex = 35;
            this.lblHoraLlegadaIda.Text = "Hora llegada:";
            // 
            // lblHoraSalidaIda
            // 
            this.lblHoraSalidaIda.AutoSize = true;
            this.lblHoraSalidaIda.Location = new System.Drawing.Point(6, 82);
            this.lblHoraSalidaIda.Name = "lblHoraSalidaIda";
            this.lblHoraSalidaIda.Size = new System.Drawing.Size(74, 14);
            this.lblHoraSalidaIda.TabIndex = 34;
            this.lblHoraSalidaIda.Text = "Hora salida:";
            // 
            // cbTrayecto
            // 
            this.cbTrayecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrayecto.FormattingEnabled = true;
            this.cbTrayecto.Location = new System.Drawing.Point(617, 72);
            this.cbTrayecto.Name = "cbTrayecto";
            this.cbTrayecto.Size = new System.Drawing.Size(324, 22);
            this.cbTrayecto.TabIndex = 38;
            this.cbTrayecto.Tag = "destinos";
            this.cbTrayecto.SelectedIndexChanged += new System.EventHandler(this.cbTrayecto_SelectedIndexChanged);
            // 
            // lblTrayecto
            // 
            this.lblTrayecto.AutoSize = true;
            this.lblTrayecto.Location = new System.Drawing.Point(547, 80);
            this.lblTrayecto.Name = "lblTrayecto";
            this.lblTrayecto.Size = new System.Drawing.Size(62, 14);
            this.lblTrayecto.TabIndex = 37;
            this.lblTrayecto.Text = "Recorrido:";
            // 
            // gbBuscarPasaje
            // 
            this.gbBuscarPasaje.AutoSize = true;
            this.gbBuscarPasaje.Controls.Add(this.gbFiltros);
            this.gbBuscarPasaje.Controls.Add(this.btnDistrCrear);
            this.gbBuscarPasaje.Controls.Add(this.dtpBusPasFecha);
            this.gbBuscarPasaje.Controls.Add(this.cbBusPasDestino);
            this.gbBuscarPasaje.Controls.Add(this.cbPasBusOrigen);
            this.gbBuscarPasaje.Controls.Add(this.cbPasBusPasajeroDNI);
            this.gbBuscarPasaje.Controls.Add(this.cbPasBusPasajeroNombre);
            this.gbBuscarPasaje.Controls.Add(this.chbBusPasFecha);
            this.gbBuscarPasaje.Controls.Add(this.chbBusPasDestino);
            this.gbBuscarPasaje.Controls.Add(this.chbBusPasOrigen);
            this.gbBuscarPasaje.Controls.Add(this.chbBusPasPasajeroDNI);
            this.gbBuscarPasaje.Controls.Add(this.chbBusPasPasajeroNombre);
            this.gbBuscarPasaje.Location = new System.Drawing.Point(23, 132);
            this.gbBuscarPasaje.Name = "gbBuscarPasaje";
            this.gbBuscarPasaje.Size = new System.Drawing.Size(508, 227);
            this.gbBuscarPasaje.TabIndex = 34;
            this.gbBuscarPasaje.TabStop = false;
            this.gbBuscarPasaje.Text = "Búsqueda de pasajes";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.rbFiltrosExpirados);
            this.gbFiltros.Controls.Add(this.rbFiltrosRecorrido);
            this.gbFiltros.Controls.Add(this.rbFiltrosVendidos);
            this.gbFiltros.Controls.Add(this.rbFiltrosPendientes);
            this.gbFiltros.Controls.Add(this.rbFiltrosDiaHoy);
            this.gbFiltros.Controls.Add(this.rbFiltroTodos);
            this.gbFiltros.Location = new System.Drawing.Point(12, 159);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(483, 47);
            this.gbFiltros.TabIndex = 42;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // rbFiltrosExpirados
            // 
            this.rbFiltrosExpirados.AutoSize = true;
            this.rbFiltrosExpirados.Location = new System.Drawing.Point(209, 20);
            this.rbFiltrosExpirados.Name = "rbFiltrosExpirados";
            this.rbFiltrosExpirados.Size = new System.Drawing.Size(78, 18);
            this.rbFiltrosExpirados.TabIndex = 5;
            this.rbFiltrosExpirados.TabStop = true;
            this.rbFiltrosExpirados.Text = "Expirados";
            this.rbFiltrosExpirados.UseVisualStyleBackColor = true;
            this.rbFiltrosExpirados.CheckedChanged += new System.EventHandler(this.rbFiltrosExpirados_CheckedChanged);
            // 
            // rbFiltrosRecorrido
            // 
            this.rbFiltrosRecorrido.AutoSize = true;
            this.rbFiltrosRecorrido.Location = new System.Drawing.Point(120, 20);
            this.rbFiltrosRecorrido.Name = "rbFiltrosRecorrido";
            this.rbFiltrosRecorrido.Size = new System.Drawing.Size(83, 18);
            this.rbFiltrosRecorrido.TabIndex = 4;
            this.rbFiltrosRecorrido.TabStop = true;
            this.rbFiltrosRecorrido.Text = "Recorridos";
            this.rbFiltrosRecorrido.UseVisualStyleBackColor = true;
            this.rbFiltrosRecorrido.CheckedChanged += new System.EventHandler(this.rbFiltrosRecorrido_CheckedChanged);
            // 
            // rbFiltrosVendidos
            // 
            this.rbFiltrosVendidos.AutoSize = true;
            this.rbFiltrosVendidos.Location = new System.Drawing.Point(386, 20);
            this.rbFiltrosVendidos.Name = "rbFiltrosVendidos";
            this.rbFiltrosVendidos.Size = new System.Drawing.Size(76, 18);
            this.rbFiltrosVendidos.TabIndex = 3;
            this.rbFiltrosVendidos.TabStop = true;
            this.rbFiltrosVendidos.Text = "Vendidos";
            this.rbFiltrosVendidos.UseVisualStyleBackColor = true;
            this.rbFiltrosVendidos.CheckedChanged += new System.EventHandler(this.rbFiltrosVendidos_CheckedChanged);
            // 
            // rbFiltrosPendientes
            // 
            this.rbFiltrosPendientes.AutoSize = true;
            this.rbFiltrosPendientes.Location = new System.Drawing.Point(293, 20);
            this.rbFiltrosPendientes.Name = "rbFiltrosPendientes";
            this.rbFiltrosPendientes.Size = new System.Drawing.Size(87, 18);
            this.rbFiltrosPendientes.TabIndex = 2;
            this.rbFiltrosPendientes.TabStop = true;
            this.rbFiltrosPendientes.Text = "Pendientes";
            this.rbFiltrosPendientes.UseVisualStyleBackColor = true;
            this.rbFiltrosPendientes.CheckedChanged += new System.EventHandler(this.rbFiltrosPendientes_CheckedChanged);
            // 
            // rbFiltrosDiaHoy
            // 
            this.rbFiltrosDiaHoy.AutoSize = true;
            this.rbFiltrosDiaHoy.Location = new System.Drawing.Point(69, 20);
            this.rbFiltrosDiaHoy.Name = "rbFiltrosDiaHoy";
            this.rbFiltrosDiaHoy.Size = new System.Drawing.Size(45, 18);
            this.rbFiltrosDiaHoy.TabIndex = 1;
            this.rbFiltrosDiaHoy.TabStop = true;
            this.rbFiltrosDiaHoy.Text = "Hoy";
            this.rbFiltrosDiaHoy.UseVisualStyleBackColor = true;
            this.rbFiltrosDiaHoy.CheckedChanged += new System.EventHandler(this.rbFiltrosDiaHoy_CheckedChanged);
            // 
            // rbFiltroTodos
            // 
            this.rbFiltroTodos.AutoSize = true;
            this.rbFiltroTodos.Location = new System.Drawing.Point(6, 20);
            this.rbFiltroTodos.Name = "rbFiltroTodos";
            this.rbFiltroTodos.Size = new System.Drawing.Size(57, 18);
            this.rbFiltroTodos.TabIndex = 0;
            this.rbFiltroTodos.TabStop = true;
            this.rbFiltroTodos.Text = "Todos";
            this.rbFiltroTodos.UseVisualStyleBackColor = true;
            this.rbFiltroTodos.CheckedChanged += new System.EventHandler(this.rbFiltroTodos_CheckedChanged);
            // 
            // btnDistrCrear
            // 
            this.btnDistrCrear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDistrCrear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDistrCrear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistrCrear.Location = new System.Drawing.Point(415, 130);
            this.btnDistrCrear.Name = "btnDistrCrear";
            this.btnDistrCrear.Size = new System.Drawing.Size(80, 29);
            this.btnDistrCrear.TabIndex = 56;
            this.btnDistrCrear.Text = "Buscar";
            this.btnDistrCrear.UseVisualStyleBackColor = true;
            this.btnDistrCrear.Click += new System.EventHandler(this.btnDistrCrear_Click);
            // 
            // dtpBusPasFecha
            // 
            this.dtpBusPasFecha.Enabled = false;
            this.dtpBusPasFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBusPasFecha.Location = new System.Drawing.Point(166, 131);
            this.dtpBusPasFecha.MaxDate = new System.DateTime(2019, 12, 25, 23, 59, 59, 0);
            this.dtpBusPasFecha.Name = "dtpBusPasFecha";
            this.dtpBusPasFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpBusPasFecha.Size = new System.Drawing.Size(243, 22);
            this.dtpBusPasFecha.TabIndex = 55;
            this.dtpBusPasFecha.Value = new System.DateTime(2019, 11, 17, 0, 0, 0, 0);
            // 
            // cbBusPasDestino
            // 
            this.cbBusPasDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbBusPasDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBusPasDestino.Enabled = false;
            this.cbBusPasDestino.FormattingEnabled = true;
            this.cbBusPasDestino.Location = new System.Drawing.Point(166, 103);
            this.cbBusPasDestino.Name = "cbBusPasDestino";
            this.cbBusPasDestino.Size = new System.Drawing.Size(243, 22);
            this.cbBusPasDestino.TabIndex = 54;
            // 
            // cbPasBusOrigen
            // 
            this.cbPasBusOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPasBusOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbPasBusOrigen.Enabled = false;
            this.cbPasBusOrigen.FormattingEnabled = true;
            this.cbPasBusOrigen.Location = new System.Drawing.Point(166, 75);
            this.cbPasBusOrigen.Name = "cbPasBusOrigen";
            this.cbPasBusOrigen.Size = new System.Drawing.Size(243, 22);
            this.cbPasBusOrigen.TabIndex = 53;
            // 
            // cbPasBusPasajeroDNI
            // 
            this.cbPasBusPasajeroDNI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPasBusPasajeroDNI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbPasBusPasajeroDNI.Enabled = false;
            this.cbPasBusPasajeroDNI.FormattingEnabled = true;
            this.cbPasBusPasajeroDNI.Location = new System.Drawing.Point(166, 47);
            this.cbPasBusPasajeroDNI.Name = "cbPasBusPasajeroDNI";
            this.cbPasBusPasajeroDNI.Size = new System.Drawing.Size(243, 22);
            this.cbPasBusPasajeroDNI.TabIndex = 52;
            // 
            // cbPasBusPasajeroNombre
            // 
            this.cbPasBusPasajeroNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPasBusPasajeroNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbPasBusPasajeroNombre.Enabled = false;
            this.cbPasBusPasajeroNombre.FormattingEnabled = true;
            this.cbPasBusPasajeroNombre.Location = new System.Drawing.Point(166, 19);
            this.cbPasBusPasajeroNombre.Name = "cbPasBusPasajeroNombre";
            this.cbPasBusPasajeroNombre.Size = new System.Drawing.Size(243, 22);
            this.cbPasBusPasajeroNombre.TabIndex = 51;
            // 
            // chbBusPasFecha
            // 
            this.chbBusPasFecha.AutoSize = true;
            this.chbBusPasFecha.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbBusPasFecha.Location = new System.Drawing.Point(12, 134);
            this.chbBusPasFecha.Name = "chbBusPasFecha";
            this.chbBusPasFecha.Size = new System.Drawing.Size(58, 18);
            this.chbBusPasFecha.TabIndex = 50;
            this.chbBusPasFecha.Text = "Fecha";
            this.chbBusPasFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBusPasFecha.UseVisualStyleBackColor = true;
            this.chbBusPasFecha.CheckedChanged += new System.EventHandler(this.chbBusPasFecha_CheckedChanged);
            // 
            // chbBusPasDestino
            // 
            this.chbBusPasDestino.AutoSize = true;
            this.chbBusPasDestino.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbBusPasDestino.Location = new System.Drawing.Point(12, 106);
            this.chbBusPasDestino.Name = "chbBusPasDestino";
            this.chbBusPasDestino.Size = new System.Drawing.Size(68, 18);
            this.chbBusPasDestino.TabIndex = 49;
            this.chbBusPasDestino.Text = "Destino";
            this.chbBusPasDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBusPasDestino.UseVisualStyleBackColor = true;
            this.chbBusPasDestino.CheckedChanged += new System.EventHandler(this.chbBusPasDestino_CheckedChanged);
            // 
            // chbBusPasOrigen
            // 
            this.chbBusPasOrigen.AutoSize = true;
            this.chbBusPasOrigen.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbBusPasOrigen.Location = new System.Drawing.Point(12, 78);
            this.chbBusPasOrigen.Name = "chbBusPasOrigen";
            this.chbBusPasOrigen.Size = new System.Drawing.Size(62, 18);
            this.chbBusPasOrigen.TabIndex = 48;
            this.chbBusPasOrigen.Text = "Origen";
            this.chbBusPasOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBusPasOrigen.UseVisualStyleBackColor = true;
            this.chbBusPasOrigen.CheckedChanged += new System.EventHandler(this.chbBusPasOrigen_CheckedChanged);
            // 
            // chbBusPasPasajeroDNI
            // 
            this.chbBusPasPasajeroDNI.AutoSize = true;
            this.chbBusPasPasajeroDNI.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbBusPasPasajeroDNI.Location = new System.Drawing.Point(12, 50);
            this.chbBusPasPasajeroDNI.Name = "chbBusPasPasajeroDNI";
            this.chbBusPasPasajeroDNI.Size = new System.Drawing.Size(114, 18);
            this.chbBusPasPasajeroDNI.TabIndex = 47;
            this.chbBusPasPasajeroDNI.Text = "DNI de pasajero";
            this.chbBusPasPasajeroDNI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBusPasPasajeroDNI.UseVisualStyleBackColor = true;
            this.chbBusPasPasajeroDNI.CheckedChanged += new System.EventHandler(this.chbBusPasPasajeroDNI_CheckedChanged);
            // 
            // chbBusPasPasajeroNombre
            // 
            this.chbBusPasPasajeroNombre.AutoSize = true;
            this.chbBusPasPasajeroNombre.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbBusPasPasajeroNombre.Location = new System.Drawing.Point(12, 22);
            this.chbBusPasPasajeroNombre.Name = "chbBusPasPasajeroNombre";
            this.chbBusPasPasajeroNombre.Size = new System.Drawing.Size(137, 18);
            this.chbBusPasPasajeroNombre.TabIndex = 46;
            this.chbBusPasPasajeroNombre.Text = "Nombre de pasajero";
            this.chbBusPasPasajeroNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBusPasPasajeroNombre.UseVisualStyleBackColor = true;
            this.chbBusPasPasajeroNombre.CheckedChanged += new System.EventHandler(this.chbBusPasPasajeroNombre_CheckedChanged);
            // 
            // gbPasajeros
            // 
            this.gbPasajeros.AutoSize = true;
            this.gbPasajeros.Controls.Add(this.cbPasDNI);
            this.gbPasajeros.Controls.Add(this.cbPasNombre);
            this.gbPasajeros.Controls.Add(this.btnBuscarPasajeros);
            this.gbPasajeros.Controls.Add(this.btnMasPasajeros);
            this.gbPasajeros.Controls.Add(this.lblPasDNI);
            this.gbPasajeros.Controls.Add(this.lblPasNombre);
            this.gbPasajeros.Location = new System.Drawing.Point(23, 35);
            this.gbPasajeros.Name = "gbPasajeros";
            this.gbPasajeros.Size = new System.Drawing.Size(508, 91);
            this.gbPasajeros.TabIndex = 33;
            this.gbPasajeros.TabStop = false;
            this.gbPasajeros.Text = "Pasajero";
            // 
            // cbPasDNI
            // 
            this.cbPasDNI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPasDNI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbPasDNI.FormattingEnabled = true;
            this.cbPasDNI.Location = new System.Drawing.Point(77, 48);
            this.cbPasDNI.MaxLength = 8;
            this.cbPasDNI.Name = "cbPasDNI";
            this.cbPasDNI.Size = new System.Drawing.Size(164, 22);
            this.cbPasDNI.TabIndex = 43;
            this.cbPasDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPasDNI_KeyDown);
            this.cbPasDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPasDNI_KeyPress);
            // 
            // cbPasNombre
            // 
            this.cbPasNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPasNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbPasNombre.FormattingEnabled = true;
            this.cbPasNombre.Location = new System.Drawing.Point(77, 19);
            this.cbPasNombre.Name = "cbPasNombre";
            this.cbPasNombre.Size = new System.Drawing.Size(360, 22);
            this.cbPasNombre.TabIndex = 42;
            this.cbPasNombre.SelectedIndexChanged += new System.EventHandler(this.cbPasNombre_SelectedIndexChanged);
            this.cbPasNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPasNombre_KeyDown);
            // 
            // btnBuscarPasajeros
            // 
            this.btnBuscarPasajeros.AutoSize = true;
            this.btnBuscarPasajeros.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPasajeros.BackgroundImage = global::Boleteria.Properties.Resources._698873_icon_136_document_edit_512;
            this.btnBuscarPasajeros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarPasajeros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPasajeros.Location = new System.Drawing.Point(443, 19);
            this.btnBuscarPasajeros.Name = "btnBuscarPasajeros";
            this.btnBuscarPasajeros.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarPasajeros.TabIndex = 41;
            this.ttInfo.SetToolTip(this.btnBuscarPasajeros, "Buscar pasajeros");
            this.btnBuscarPasajeros.UseVisualStyleBackColor = false;
            this.btnBuscarPasajeros.Click += new System.EventHandler(this.btnBuscarPasajeros_Click);
            // 
            // btnMasPasajeros
            // 
            this.btnMasPasajeros.AutoSize = true;
            this.btnMasPasajeros.BackColor = System.Drawing.Color.Transparent;
            this.btnMasPasajeros.BackgroundImage = global::Boleteria.Properties.Resources.agregar1;
            this.btnMasPasajeros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMasPasajeros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasPasajeros.Location = new System.Drawing.Point(472, 19);
            this.btnMasPasajeros.Name = "btnMasPasajeros";
            this.btnMasPasajeros.Size = new System.Drawing.Size(23, 23);
            this.btnMasPasajeros.TabIndex = 40;
            this.ttInfo.SetToolTip(this.btnMasPasajeros, "Registrar un nuevo pasajero");
            this.btnMasPasajeros.UseVisualStyleBackColor = false;
            this.btnMasPasajeros.Click += new System.EventHandler(this.btnMasPasajeros_Click);
            // 
            // lblPasDNI
            // 
            this.lblPasDNI.AutoSize = true;
            this.lblPasDNI.Location = new System.Drawing.Point(9, 51);
            this.lblPasDNI.Name = "lblPasDNI";
            this.lblPasDNI.Size = new System.Drawing.Size(30, 14);
            this.lblPasDNI.TabIndex = 32;
            this.lblPasDNI.Text = "DNI:";
            // 
            // lblPasNombre
            // 
            this.lblPasNombre.AutoSize = true;
            this.lblPasNombre.Location = new System.Drawing.Point(9, 22);
            this.lblPasNombre.Name = "lblPasNombre";
            this.lblPasNombre.Size = new System.Drawing.Size(53, 14);
            this.lblPasNombre.TabIndex = 31;
            this.lblPasNombre.Text = "Nombre:";
            // 
            // btnVender
            // 
            this.btnVender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVender.AutoSize = true;
            this.btnVender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(884, 455);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(139, 49);
            this.btnVender.TabIndex = 29;
            this.btnVender.Text = "Confirmar";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click_1);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(26, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(46, 14);
            this.lblTipo.TabIndex = 15;
            this.lblTipo.Text = "Boleto:";
            // 
            // cbBoleto
            // 
            this.cbBoleto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoleto.Enabled = false;
            this.cbBoleto.FormattingEnabled = true;
            this.cbBoleto.Items.AddRange(new object[] {
            "IDA",
            "IDA Y VUELTA"});
            this.cbBoleto.Location = new System.Drawing.Point(80, 7);
            this.cbBoleto.Name = "cbBoleto";
            this.cbBoleto.Size = new System.Drawing.Size(129, 22);
            this.cbBoleto.TabIndex = 16;
            // 
            // btnMasOrigen
            // 
            this.btnMasOrigen.AutoSize = true;
            this.btnMasOrigen.BackgroundImage = global::Boleteria.Properties.Resources.edit;
            this.btnMasOrigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMasOrigen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasOrigen.Location = new System.Drawing.Point(943, 45);
            this.btnMasOrigen.Name = "btnMasOrigen";
            this.btnMasOrigen.Size = new System.Drawing.Size(25, 25);
            this.btnMasOrigen.TabIndex = 17;
            this.ttInfo.SetToolTip(this.btnMasOrigen, "Editar todos los recorridos, sus horarios y destinos");
            this.btnMasOrigen.UseVisualStyleBackColor = true;
            this.btnMasOrigen.Visible = false;
            this.btnMasOrigen.Click += new System.EventHandler(this.btnMasOrigen_Click);
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(547, 108);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(46, 14);
            this.lblOrigen.TabIndex = 18;
            this.lblOrigen.Text = "Origen:";
            // 
            // cbOrigen
            // 
            this.cbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(617, 101);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(324, 22);
            this.cbOrigen.Sorted = true;
            this.cbOrigen.TabIndex = 19;
            this.cbOrigen.Tag = "destinos";
            this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cbOrigen_SelectedIndexChanged_1);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(547, 133);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(52, 14);
            this.lblDestino.TabIndex = 20;
            this.lblDestino.Text = "Destino:";
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(617, 130);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(324, 22);
            this.cbDestino.Sorted = true;
            this.cbDestino.TabIndex = 21;
            this.cbDestino.Tag = "destinos";
            this.cbDestino.SelectedIndexChanged += new System.EventHandler(this.cbDestino_SelectedIndexChanged_1);
            // 
            // tpViajes
            // 
            this.tpViajes.AutoScroll = true;
            this.tpViajes.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tpViajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpViajes.Controls.Add(this.gbViajesHorarios);
            this.tpViajes.Controls.Add(this.gbPBModEspacio);
            this.tpViajes.Controls.Add(this.lblViajeFrecuencia);
            this.tpViajes.Controls.Add(this.clbViajeFrecuencia);
            this.tpViajes.Controls.Add(this.lblViajeHorario);
            this.tpViajes.Controls.Add(this.lblViajeRecorrido);
            this.tpViajes.Controls.Add(this.cbViajeHoraSalida);
            this.tpViajes.Controls.Add(this.cbViajeTrayecto);
            this.tpViajes.Location = new System.Drawing.Point(4, 23);
            this.tpViajes.Name = "tpViajes";
            this.tpViajes.Padding = new System.Windows.Forms.Padding(3);
            this.tpViajes.Size = new System.Drawing.Size(1037, 528);
            this.tpViajes.TabIndex = 2;
            this.tpViajes.Text = "Viajes";
            // 
            // gbViajesHorarios
            // 
            this.gbViajesHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbViajesHorarios.AutoSize = true;
            this.gbViajesHorarios.Controls.Add(this.pnlViajeHorariosTodos);
            this.gbViajesHorarios.Controls.Add(this.rbViajesPrecios);
            this.gbViajesHorarios.Controls.Add(this.rbViajesHorarios);
            this.gbViajesHorarios.Controls.Add(this.dgvViajeTrayectos);
            this.gbViajesHorarios.Location = new System.Drawing.Point(6, 78);
            this.gbViajesHorarios.Name = "gbViajesHorarios";
            this.gbViajesHorarios.Size = new System.Drawing.Size(608, 358);
            this.gbViajesHorarios.TabIndex = 52;
            this.gbViajesHorarios.TabStop = false;
            this.gbViajesHorarios.Text = "Todos los horarios y tarifas";
            // 
            // pnlViajeHorariosTodos
            // 
            this.pnlViajeHorariosTodos.BackColor = System.Drawing.SystemColors.Control;
            this.pnlViajeHorariosTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViajeHorariosTodos.Controls.Add(this.cbViajesHorariosTodos);
            this.pnlViajeHorariosTodos.Location = new System.Drawing.Point(140, 20);
            this.pnlViajeHorariosTodos.Name = "pnlViajeHorariosTodos";
            this.pnlViajeHorariosTodos.Size = new System.Drawing.Size(72, 25);
            this.pnlViajeHorariosTodos.TabIndex = 56;
            // 
            // cbViajesHorariosTodos
            // 
            this.cbViajesHorariosTodos.AutoSize = true;
            this.cbViajesHorariosTodos.Location = new System.Drawing.Point(3, 4);
            this.cbViajesHorariosTodos.Name = "cbViajesHorariosTodos";
            this.cbViajesHorariosTodos.Size = new System.Drawing.Size(58, 18);
            this.cbViajesHorariosTodos.TabIndex = 57;
            this.cbViajesHorariosTodos.Text = "Todos";
            this.cbViajesHorariosTodos.UseVisualStyleBackColor = true;
            this.cbViajesHorariosTodos.CheckedChanged += new System.EventHandler(this.cbViajesHorariosTodos_CheckedChanged);
            // 
            // rbViajesPrecios
            // 
            this.rbViajesPrecios.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbViajesPrecios.AutoSize = true;
            this.rbViajesPrecios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbViajesPrecios.Location = new System.Drawing.Point(76, 20);
            this.rbViajesPrecios.Name = "rbViajesPrecios";
            this.rbViajesPrecios.Size = new System.Drawing.Size(56, 24);
            this.rbViajesPrecios.TabIndex = 54;
            this.rbViajesPrecios.Text = "Precios";
            this.rbViajesPrecios.UseVisualStyleBackColor = true;
            this.rbViajesPrecios.CheckedChanged += new System.EventHandler(this.rbViajesPrecios_CheckedChanged);
            // 
            // rbViajesHorarios
            // 
            this.rbViajesHorarios.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbViajesHorarios.AutoSize = true;
            this.rbViajesHorarios.Checked = true;
            this.rbViajesHorarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbViajesHorarios.Location = new System.Drawing.Point(6, 20);
            this.rbViajesHorarios.Name = "rbViajesHorarios";
            this.rbViajesHorarios.Size = new System.Drawing.Size(64, 24);
            this.rbViajesHorarios.TabIndex = 53;
            this.rbViajesHorarios.TabStop = true;
            this.rbViajesHorarios.Text = "Horarios";
            this.rbViajesHorarios.UseVisualStyleBackColor = true;
            this.rbViajesHorarios.CheckedChanged += new System.EventHandler(this.rbViajesHorarios_CheckedChanged);
            // 
            // dgvViajeTrayectos
            // 
            this.dgvViajeTrayectos.AllowUserToAddRows = false;
            this.dgvViajeTrayectos.AllowUserToDeleteRows = false;
            this.dgvViajeTrayectos.AllowUserToResizeColumns = false;
            this.dgvViajeTrayectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViajeTrayectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViajeTrayectos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViajeTrayectos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViajeTrayectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViajeTrayectos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViajeTrayectos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvViajeTrayectos.Location = new System.Drawing.Point(5, 52);
            this.dgvViajeTrayectos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViajeTrayectos.MultiSelect = false;
            this.dgvViajeTrayectos.Name = "dgvViajeTrayectos";
            this.dgvViajeTrayectos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViajeTrayectos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViajeTrayectos.RowHeadersVisible = false;
            this.dgvViajeTrayectos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvViajeTrayectos.RowTemplate.Height = 24;
            this.dgvViajeTrayectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvViajeTrayectos.Size = new System.Drawing.Size(594, 284);
            this.dgvViajeTrayectos.TabIndex = 40;
            // 
            // gbPBModEspacio
            // 
            this.gbPBModEspacio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPBModEspacio.AutoSize = true;
            this.gbPBModEspacio.Controls.Add(this.rbPA);
            this.gbPBModEspacio.Controls.Add(this.rbPB);
            this.gbPBModEspacio.Controls.Add(this.dgvAsientos);
            this.gbPBModEspacio.Location = new System.Drawing.Point(620, 78);
            this.gbPBModEspacio.Name = "gbPBModEspacio";
            this.gbPBModEspacio.Size = new System.Drawing.Size(244, 358);
            this.gbPBModEspacio.TabIndex = 51;
            this.gbPBModEspacio.TabStop = false;
            this.gbPBModEspacio.Text = "Distribución de asientos";
            // 
            // rbPA
            // 
            this.rbPA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPA.AutoSize = true;
            this.rbPA.Location = new System.Drawing.Point(97, 26);
            this.rbPA.Name = "rbPA";
            this.rbPA.Size = new System.Drawing.Size(85, 18);
            this.rbPA.TabIndex = 13;
            this.rbPA.Text = "Planta alta";
            this.rbPA.UseVisualStyleBackColor = true;
            this.rbPA.CheckedChanged += new System.EventHandler(this.rbPA_CheckedChanged);
            // 
            // rbPB
            // 
            this.rbPB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPB.AutoSize = true;
            this.rbPB.Checked = true;
            this.rbPB.Location = new System.Drawing.Point(6, 26);
            this.rbPB.Name = "rbPB";
            this.rbPB.Size = new System.Drawing.Size(87, 18);
            this.rbPB.TabIndex = 12;
            this.rbPB.TabStop = true;
            this.rbPB.Text = "Planta baja";
            this.rbPB.UseVisualStyleBackColor = true;
            this.rbPB.CheckedChanged += new System.EventHandler(this.rbPB_CheckedChanged);
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.AllowUserToResizeColumns = false;
            this.dgvAsientos.AllowUserToResizeRows = false;
            this.dgvAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAsientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAsientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientos.ColumnHeadersVisible = false;
            this.dgvAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C1,
            this.C4,
            this.C5,
            this.C2,
            this.C3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsientos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAsientos.GridColor = System.Drawing.Color.White;
            this.dgvAsientos.Location = new System.Drawing.Point(6, 77);
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsientos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAsientos.RowHeadersVisible = false;
            this.dgvAsientos.RowHeadersWidth = 60;
            this.dgvAsientos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Silver;
            this.dgvAsientos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAsientos.RowTemplate.Height = 50;
            this.dgvAsientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(229, 259);
            this.dgvAsientos.TabIndex = 0;
            // 
            // C1
            // 
            this.C1.HeaderText = "";
            this.C1.Name = "C1";
            this.C1.ReadOnly = true;
            // 
            // C4
            // 
            this.C4.HeaderText = "";
            this.C4.Name = "C4";
            this.C4.ReadOnly = true;
            // 
            // C5
            // 
            this.C5.HeaderText = "";
            this.C5.Name = "C5";
            this.C5.ReadOnly = true;
            // 
            // C2
            // 
            this.C2.HeaderText = "";
            this.C2.Name = "C2";
            this.C2.ReadOnly = true;
            // 
            // C3
            // 
            this.C3.HeaderText = "";
            this.C3.Name = "C3";
            this.C3.ReadOnly = true;
            // 
            // lblViajeFrecuencia
            // 
            this.lblViajeFrecuencia.AutoSize = true;
            this.lblViajeFrecuencia.Location = new System.Drawing.Point(402, 43);
            this.lblViajeFrecuencia.Name = "lblViajeFrecuencia";
            this.lblViajeFrecuencia.Size = new System.Drawing.Size(69, 14);
            this.lblViajeFrecuencia.TabIndex = 50;
            this.lblViajeFrecuencia.Text = "Frecuencia:";
            // 
            // clbViajeFrecuencia
            // 
            this.clbViajeFrecuencia.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.clbViajeFrecuencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbViajeFrecuencia.CheckOnClick = true;
            this.clbViajeFrecuencia.ColumnWidth = 80;
            this.clbViajeFrecuencia.FormattingEnabled = true;
            this.clbViajeFrecuencia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.clbViajeFrecuencia.Location = new System.Drawing.Point(488, 6);
            this.clbViajeFrecuencia.MultiColumn = true;
            this.clbViajeFrecuencia.Name = "clbViajeFrecuencia";
            this.clbViajeFrecuencia.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.clbViajeFrecuencia.Size = new System.Drawing.Size(225, 68);
            this.clbViajeFrecuencia.TabIndex = 49;
            // 
            // lblViajeHorario
            // 
            this.lblViajeHorario.AutoSize = true;
            this.lblViajeHorario.Location = new System.Drawing.Point(6, 43);
            this.lblViajeHorario.Name = "lblViajeHorario";
            this.lblViajeHorario.Size = new System.Drawing.Size(51, 14);
            this.lblViajeHorario.TabIndex = 43;
            this.lblViajeHorario.Text = "Horario:";
            // 
            // lblViajeRecorrido
            // 
            this.lblViajeRecorrido.AutoSize = true;
            this.lblViajeRecorrido.Location = new System.Drawing.Point(6, 14);
            this.lblViajeRecorrido.Name = "lblViajeRecorrido";
            this.lblViajeRecorrido.Size = new System.Drawing.Size(62, 14);
            this.lblViajeRecorrido.TabIndex = 42;
            this.lblViajeRecorrido.Text = "Recorrido:";
            // 
            // cbViajeHoraSalida
            // 
            this.cbViajeHoraSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViajeHoraSalida.FormattingEnabled = true;
            this.cbViajeHoraSalida.Location = new System.Drawing.Point(83, 40);
            this.cbViajeHoraSalida.Name = "cbViajeHoraSalida";
            this.cbViajeHoraSalida.Size = new System.Drawing.Size(74, 22);
            this.cbViajeHoraSalida.TabIndex = 41;
            this.cbViajeHoraSalida.SelectedIndexChanged += new System.EventHandler(this.cbViajeHoraSalida_SelectedIndexChanged);
            // 
            // cbViajeTrayecto
            // 
            this.cbViajeTrayecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViajeTrayecto.FormattingEnabled = true;
            this.cbViajeTrayecto.Location = new System.Drawing.Point(83, 11);
            this.cbViajeTrayecto.Name = "cbViajeTrayecto";
            this.cbViajeTrayecto.Size = new System.Drawing.Size(324, 22);
            this.cbViajeTrayecto.TabIndex = 39;
            this.cbViajeTrayecto.Tag = "destinos";
            this.cbViajeTrayecto.SelectedIndexChanged += new System.EventHandler(this.cbViajeTrayecto_SelectedIndexChanged);
            // 
            // tpReportes
            // 
            this.tpReportes.Controls.Add(this.groupBox1);
            this.tpReportes.Location = new System.Drawing.Point(4, 23);
            this.tpReportes.Name = "tpReportes";
            this.tpReportes.Size = new System.Drawing.Size(1037, 528);
            this.tpReportes.TabIndex = 3;
            this.tpReportes.Text = "Reportes";
            this.tpReportes.UseVisualStyleBackColor = true;
            this.tpReportes.Click += new System.EventHandler(this.tpReportes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInformeRecorrido);
            this.groupBox1.Controls.Add(this.rbInformePasajero);
            this.groupBox1.Controls.Add(this.cbInformeTrayecto);
            this.groupBox1.Controls.Add(this.btnInforme);
            this.groupBox1.Controls.Add(this.cbInformePasajero);
            this.groupBox1.Location = new System.Drawing.Point(14, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 131);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros disponibles";
            // 
            // rbInformeRecorrido
            // 
            this.rbInformeRecorrido.AutoSize = true;
            this.rbInformeRecorrido.Checked = true;
            this.rbInformeRecorrido.Location = new System.Drawing.Point(6, 21);
            this.rbInformeRecorrido.Name = "rbInformeRecorrido";
            this.rbInformeRecorrido.Size = new System.Drawing.Size(80, 18);
            this.rbInformeRecorrido.TabIndex = 44;
            this.rbInformeRecorrido.TabStop = true;
            this.rbInformeRecorrido.Text = "Recorrido:";
            this.rbInformeRecorrido.UseVisualStyleBackColor = true;
            // 
            // rbInformePasajero
            // 
            this.rbInformePasajero.AutoSize = true;
            this.rbInformePasajero.Location = new System.Drawing.Point(6, 56);
            this.rbInformePasajero.Name = "rbInformePasajero";
            this.rbInformePasajero.Size = new System.Drawing.Size(75, 18);
            this.rbInformePasajero.TabIndex = 45;
            this.rbInformePasajero.Text = "Pasajero:";
            this.rbInformePasajero.UseVisualStyleBackColor = true;
            // 
            // cbInformeTrayecto
            // 
            this.cbInformeTrayecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInformeTrayecto.FormattingEnabled = true;
            this.cbInformeTrayecto.Location = new System.Drawing.Point(108, 20);
            this.cbInformeTrayecto.Name = "cbInformeTrayecto";
            this.cbInformeTrayecto.Size = new System.Drawing.Size(324, 22);
            this.cbInformeTrayecto.TabIndex = 39;
            this.cbInformeTrayecto.Tag = "destinos";
            // 
            // btnInforme
            // 
            this.btnInforme.Location = new System.Drawing.Point(6, 92);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(112, 23);
            this.btnInforme.TabIndex = 40;
            this.btnInforme.Text = "Crear informe";
            this.btnInforme.UseVisualStyleBackColor = true;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // cbInformePasajero
            // 
            this.cbInformePasajero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbInformePasajero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbInformePasajero.FormattingEnabled = true;
            this.cbInformePasajero.Location = new System.Drawing.Point(108, 55);
            this.cbInformePasajero.Name = "cbInformePasajero";
            this.cbInformePasajero.Size = new System.Drawing.Size(360, 22);
            this.cbInformePasajero.TabIndex = 43;
            this.cbInformePasajero.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.configuracionesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(1069, 24);
            this.msPrincipal.TabIndex = 8;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirFuenteDeDatosToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Image = global::Boleteria.Properties.Resources.borrar1;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirFuenteDeDatosToolStripMenuItem
            // 
            this.abrirFuenteDeDatosToolStripMenuItem.Name = "abrirFuenteDeDatosToolStripMenuItem";
            this.abrirFuenteDeDatosToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.abrirFuenteDeDatosToolStripMenuItem.Text = "Abrir fuente de datos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apartadosAdministrativosToolStripMenuItem,
            this.boletosToolStripMenuItem});
            this.verToolStripMenuItem.Image = global::Boleteria.Properties.Resources.tarjeta;
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // apartadosAdministrativosToolStripMenuItem
            // 
            this.apartadosAdministrativosToolStripMenuItem.Name = "apartadosAdministrativosToolStripMenuItem";
            this.apartadosAdministrativosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.apartadosAdministrativosToolStripMenuItem.Text = "Apartados administrativos";
            this.apartadosAdministrativosToolStripMenuItem.Click += new System.EventHandler(this.apartadosAdministrativosToolStripMenuItem_Click);
            // 
            // boletosToolStripMenuItem
            // 
            this.boletosToolStripMenuItem.Checked = true;
            this.boletosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boletosToolStripMenuItem.Name = "boletosToolStripMenuItem";
            this.boletosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.boletosToolStripMenuItem.Text = "List<Boleto>";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorDeRecorridosToolStripMenuItem,
            this.editorDePasajerosToolStripMenuItem});
            this.herramientasToolStripMenuItem.Image = global::Boleteria.Properties.Resources.herramientas;
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // editorDeRecorridosToolStripMenuItem
            // 
            this.editorDeRecorridosToolStripMenuItem.Image = global::Boleteria.Properties.Resources.rango;
            this.editorDeRecorridosToolStripMenuItem.Name = "editorDeRecorridosToolStripMenuItem";
            this.editorDeRecorridosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.editorDeRecorridosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editorDeRecorridosToolStripMenuItem.Text = "Editor de viajes";
            this.editorDeRecorridosToolStripMenuItem.Click += new System.EventHandler(this.editorDeRecorridosToolStripMenuItem_Click);
            // 
            // editorDePasajerosToolStripMenuItem
            // 
            this.editorDePasajerosToolStripMenuItem.Image = global::Boleteria.Properties.Resources.inventario;
            this.editorDePasajerosToolStripMenuItem.Name = "editorDePasajerosToolStripMenuItem";
            this.editorDePasajerosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.editorDePasajerosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editorDePasajerosToolStripMenuItem.Text = "Editor de pasajeros";
            this.editorDePasajerosToolStripMenuItem.Click += new System.EventHandler(this.editorDePasajerosToolStripMenuItem_Click);
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarDirectorioPrincipalToolStripMenuItem,
            this.idaYVueltaToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Image = global::Boleteria.Properties.Resources.configuracion_16;
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // cambiarDirectorioPrincipalToolStripMenuItem
            // 
            this.cambiarDirectorioPrincipalToolStripMenuItem.Name = "cambiarDirectorioPrincipalToolStripMenuItem";
            this.cambiarDirectorioPrincipalToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.cambiarDirectorioPrincipalToolStripMenuItem.Text = "Cambiar directorios";
            // 
            // idaYVueltaToolStripMenuItem
            // 
            this.idaYVueltaToolStripMenuItem.Checked = true;
            this.idaYVueltaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.idaYVueltaToolStripMenuItem.Name = "idaYVueltaToolStripMenuItem";
            this.idaYVueltaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.idaYVueltaToolStripMenuItem.Text = "Ida y vuelta";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verLaAyudaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Image = global::Boleteria.Properties.Resources.info;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // verLaAyudaToolStripMenuItem
            // 
            this.verLaAyudaToolStripMenuItem.Image = global::Boleteria.Properties.Resources.assist;
            this.verLaAyudaToolStripMenuItem.Name = "verLaAyudaToolStripMenuItem";
            this.verLaAyudaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.verLaAyudaToolStripMenuItem.Text = "Ver la ayuda";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1069, 601);
            this.Controls.Add(this.pnlPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleteria - BETA";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.cmsOpciones.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.tcOpciones.ResumeLayout(false);
            this.tpPasajes.ResumeLayout(false);
            this.tpPasajes.PerformLayout();
            this.pnlPasajes.ResumeLayout(false);
            this.pnlPasajes.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletos)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.gbVuelta.ResumeLayout(false);
            this.gbVuelta.PerformLayout();
            this.gbIda.ResumeLayout(false);
            this.gbIda.PerformLayout();
            this.gbBuscarPasaje.ResumeLayout(false);
            this.gbBuscarPasaje.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbPasajeros.ResumeLayout(false);
            this.gbPasajeros.PerformLayout();
            this.tpViajes.ResumeLayout(false);
            this.tpViajes.PerformLayout();
            this.gbViajesHorarios.ResumeLayout(false);
            this.gbViajesHorarios.PerformLayout();
            this.pnlViajeHorariosTodos.ResumeLayout(false);
            this.pnlViajeHorariosTodos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeTrayectos)).EndInit();
            this.gbPBModEspacio.ResumeLayout(false);
            this.gbPBModEspacio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.tpReportes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsViajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpPasajes;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlPasajes;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DateTimePicker dtpFechaIda;
        private System.Windows.Forms.ComboBox cbBoleto;
        private System.Windows.Forms.Label lblFechaIda;
        private System.Windows.Forms.Button btnMasOrigen;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblAsientoIda;
        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.GroupBox gbPasajeros;
        private System.Windows.Forms.Label lblPasDNI;
        private System.Windows.Forms.Label lblPasNombre;
        private System.Windows.Forms.Label lblHoraLlegadaIda;
        private System.Windows.Forms.Label lblHoraSalidaIda;
        private System.Windows.Forms.GroupBox gbBuscarPasaje;
        private System.Windows.Forms.ComboBox cbTrayecto;
        private System.Windows.Forms.Label lblTrayecto;
        private System.Windows.Forms.GroupBox gbIda;
        private System.Windows.Forms.Button btnMasAsientosIda;
        private System.Windows.Forms.TextBox tbAsientoIda;
        private System.Windows.Forms.GroupBox gbVuelta;
        private System.Windows.Forms.ComboBox cbHoraSalidaVuelta;
        private System.Windows.Forms.DateTimePicker dtpHoraLlegadVuelta;
        private System.Windows.Forms.TextBox tbAsientoVuelta;
        private System.Windows.Forms.DateTimePicker dtpFechaVuelta;
        private System.Windows.Forms.Label lblFechaVuelta;
        private System.Windows.Forms.Label lblAsientoVuelta;
        private System.Windows.Forms.Label lblHoraLLegadaVuelta;
        private System.Windows.Forms.Label lblHoraSalidaVuelta;
        private System.Windows.Forms.ComboBox cbHoraSalidaIda;
        private System.Windows.Forms.DateTimePicker dtpHoraLlegadaIda;
        private System.Windows.Forms.Button btnMasPasajeros;
        private System.Windows.Forms.TabPage tpViajes;
        private System.Windows.Forms.Button btnMasAsientosVuelta;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.RadioButton rbFiltrosVendidos;
        private System.Windows.Forms.RadioButton rbFiltrosPendientes;
        private System.Windows.Forms.RadioButton rbFiltrosDiaHoy;
        private System.Windows.Forms.RadioButton rbFiltroTodos;
        private System.Windows.Forms.RadioButton rbFiltrosExpirados;
        private System.Windows.Forms.RadioButton rbFiltrosRecorrido;
        private System.Windows.Forms.ToolStripMenuItem venderItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarItem;
        private System.Windows.Forms.Button btnBuscarPasajeros;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.ComboBox cbPasNombre;
        private System.Windows.Forms.ComboBox cbPasDNI;
        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ComboBox cbViajeTrayecto;
        private System.Windows.Forms.DataGridView dgvViajeTrayectos;
        private System.Windows.Forms.ComboBox cbViajeHoraSalida;
        private System.Windows.Forms.Label lblViajeHorario;
        private System.Windows.Forms.Label lblViajeRecorrido;
        private System.Windows.Forms.Label lblViajeFrecuencia;
        private System.Windows.Forms.CheckedListBox clbViajeFrecuencia;
        private System.Windows.Forms.GroupBox gbViajesHorarios;
        private System.Windows.Forms.GroupBox gbPBModEspacio;
        private System.Windows.Forms.RadioButton rbPA;
        private System.Windows.Forms.RadioButton rbPB;
        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.DataGridViewButtonColumn C1;
        private System.Windows.Forms.DataGridViewButtonColumn C4;
        private System.Windows.Forms.DataGridViewButtonColumn C5;
        private System.Windows.Forms.DataGridViewButtonColumn C2;
        private System.Windows.Forms.DataGridViewButtonColumn C3;
        private System.Windows.Forms.RadioButton rbViajesPrecios;
        private System.Windows.Forms.RadioButton rbViajesHorarios;
        private System.Windows.Forms.ToolStripSeparator separador;
        private System.Windows.Forms.Panel pnlViajeHorariosTodos;
        private System.Windows.Forms.CheckBox cbViajesHorariosTodos;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirFuenteDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apartadosAdministrativosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boletosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorDeRecorridosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorDePasajerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarDirectorioPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idaYVueltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verLaAyudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verInfoItem;
        private Controles.TimerControl tcHoraServer;
        private System.Windows.Forms.DateTimePicker dtpBusPasFecha;
        private System.Windows.Forms.ComboBox cbBusPasDestino;
        private System.Windows.Forms.ComboBox cbPasBusOrigen;
        private System.Windows.Forms.ComboBox cbPasBusPasajeroDNI;
        private System.Windows.Forms.ComboBox cbPasBusPasajeroNombre;
        private System.Windows.Forms.CheckBox chbBusPasFecha;
        private System.Windows.Forms.CheckBox chbBusPasDestino;
        private System.Windows.Forms.CheckBox chbBusPasOrigen;
        private System.Windows.Forms.CheckBox chbBusPasPasajeroDNI;
        private System.Windows.Forms.CheckBox chbBusPasPasajeroNombre;
        private System.Windows.Forms.Button btnDistrCrear;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox tbPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
        public System.Windows.Forms.DataGridView dgvBoletos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trayecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.TabPage tpReportes;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.ComboBox cbInformeTrayecto;
        private System.Windows.Forms.RadioButton rbInformePasajero;
        private System.Windows.Forms.RadioButton rbInformeRecorrido;
        private System.Windows.Forms.ComboBox cbInformePasajero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bsViajes;
    }
}

