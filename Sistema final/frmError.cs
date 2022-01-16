using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boleteria
{
    public partial class frmLoading : Form
    {

        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {

        }
        /*
                private void RecargarBoletos()
                {
                    Control.CheckForIllegalCrossThreadCalls = false;

                    if (cbPagina.Items.Contains("1")) cbPagina.SelectedIndex = 0;
                    /*
                    try
                    {
                        dgvBoletos.Rows.Clear();
                        using (EntityDataModel db = new EntityDataModel())
                        {
                            if (cbFilas.SelectedItem == null)
                                cbFilas.SelectedIndex = 0;
                            int cant_filas = Convert.ToInt32(cbFilas.SelectedItem?.ToString());

                            var boletos = (from b in db.Boletos orderby b.FechaEmision descending select b).Take(cant_filas).ToList();
                            Boletos_LoadReferences(ref boletos, db);

                            foreach (Boleto b in boletos) DibujarBoletoDataGridView(b);                   
                        }
                    }
                    catch(NullReferenceException)
                    {
                        MessageBox.Show("Hay datos que son inválidos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        //dgvBoletos.Rows.GetLastRow(DataGridViewElementStates.Visible);
                   */
        //}

        /*
                private void RefreshInfo()
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    if (!actualizando)
                    {
                        actualizando = true;
                        if (cbFilas.SelectedItem == null) cbFilas.SelectedIndex = 0;
                        else
                            cbFilas.SelectedIndex = cbFilas.SelectedIndex;
                        if (cbPagina.SelectedItem == null) cbPagina.SelectedItem = "1";

                        ActualizarInformacion((Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())) - Convert.ToInt32(cbFilas.SelectedItem?.ToString()), (Convert.ToInt32(cbFilas.SelectedItem?.ToString()) * Convert.ToInt32(cbPagina.SelectedItem?.ToString())));
                        actualizando = false;

                    }
                }

                private void cbFilas_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (cbPagina.Items.Contains("1"))
                    {
                        cbPagina.SelectedIndex = 0;
                    }
                }

                private void ActualizarInformacion(int start, int end)
                {
                    using (EntityDataModel db = new EntityDataModel())
                    {
                        if (!boletos_dibujados.SequenceEqual(ObtenerBoletosFiltrados(db)))
                        {
                            boletos_dibujados = ObtenerBoletosFiltrados(db);

                            RecargarPaginas();

                            dgvBoletos.Rows.Clear();

                            if (cbMostrarTodo.Checked)
                            {
                                foreach (var boleto in boletos_dibujados)
                                {
                                    DibujarBoletoDataGridView(boleto);
                                }
                            }
                            else
                            {
                                try
                                {

                                    int page = Convert.ToInt32(cbPagina.SelectedItem?.ToString());
                                    int rowsPerPage = Convert.ToInt32(cbFilas.SelectedItem?.ToString());

                                    var inicio = page * rowsPerPage;
                                    var boletos = boletos_dibujados.OrderByDescending(b => b.FechaEmision)
                                        .Skip(inicio)
                                        .Take(rowsPerPage)
                                        .ToList();

                                    foreach (var boleto in boletos)
                                    {
                                        DibujarBoletoDataGridView(boleto);
                                    }
                                }
                                catch (NullReferenceException)
                                {

                                }



        */
        /*
        for (int i = start; i < end; i++)
        {
            if (i < boletos_dibujados.Count)
            {
                if (boletos_dibujados[i] != null)
                {
                    DibujarBoletoDataGridView(boletos_dibujados[i]);
                }
            }
        }*/
        /*
            }
                        }
                    }
                }
        
        private void RecargarPaginas()
        {
            var paginas = new List<String>();

            string selectedItem = cbPagina.SelectedItem?.ToString();

            if (force_reload)
            {
                decimal f_cant_paginas = Decimal.Divide(boletos_dibujados.Count, Convert.ToInt32(cbFilas.SelectedItem?.ToString()));
                int t_cant_paginas = boletos_dibujados.Count / Convert.ToInt32(cbFilas.SelectedItem?.ToString());
                if (f_cant_paginas > t_cant_paginas)
                {
                    t_cant_paginas++;
                }

                for (int i = 1; i < t_cant_paginas; i++)
                {
                    paginas.Add((i + 1).ToString());
                }
                if (boletos_dibujados.Count < Convert.ToInt32(cbFilas.Items[0].ToString()))
                {
                    cbMostrarTodo.Visible = true;
                }
                else cbMostrarTodo.Visible = false;

                for (int i = cbPagina.Items.Count - 1; i > 0; i--)
                {
                    if (i != 0)
                    {
                        cbPagina.Items.RemoveAt(i);
                    }
                }

                cbPagina.Items.AddRange(paginas.ToArray());
                if (!cbPagina.Items.Contains(selectedItem) || cbPagina.SelectedItem == null)
                {
                    force_reload = false;
                    cbPagina.SelectedIndex = 0;
                }
                else
                {
                    force_reload = false;
                    cbPagina.SelectedItem = selectedItem;
                }

            }
            else
            {

            }
        }
        */



    }
}
