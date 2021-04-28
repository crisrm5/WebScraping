using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capadatos;
using capanegocio;


namespace capapresentacion
{
    public partial class FrmProyecto : Form
    {
        public FrmPrincipal frmparent;
        public List<string> dataGridArrayMonitores = new List<string>();
        public FrmProyecto()
        {
            InitializeComponent();
            botonIniciarMonitor.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            //mostrarproyectos();
            mostrarMonitores();
            quitarBordes();
            colorPanel();
        }

        private void colorPanel()
        {
            this.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void mostrarMonitores()
        {
            DirectoryInfo di;
            if (StaticMonitor.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
            {
                di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Monitores");
            }
            else
            {
                di = new DirectoryInfo(StaticMonitor.rutaManual + "/");
                dataGridArrayMonitores.Clear();
            }
            DataTable dt = new DataTable();

            foreach (var fi in di.GetFiles())
            {
                System.IO.Path.GetFullPath(Application.ExecutablePath);
                //monitores.Append(fi.Name);
                dataGridArrayMonitores.Add(fi.Name);
            }



            var result = dataGridArrayMonitores.Select(s => new { value = s }).ToList();
            dataListProyectos.DataSource = result;
            dataListProyectos.Columns[1].HeaderText = "Monitor";
        }

        private void mensajeok(string mensaje)
        {
            MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mensajeerror(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cerrarX(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(cerrarX);
        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void mostrarproyectos()
        {
            this.dataListProyectos.DataSource = NProyecto.mostrarproyectos();
            this.ocultarcolumnas();
            this.botonIniciarMonitor.Visible = true;
            // this.lblTotal.Text = "Número de proyectos: " + Convert.ToString(dataListProyectos.Rows.Count);
        }

        private void ocultarcolumnas()
        {
            this.dataListProyectos.Columns[0].Visible = false;
            this.dataListProyectos.Columns[1].Visible = false;
            this.botonIniciarMonitor.Enabled = false;
            this.cbCheckAll.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            StaticMonitor.rutaManual = txtBuscarProyecto.Text;
            mostrarMonitores();
            //FrmDetalleProyecto detalleproyecto = new FrmDetalleProyecto();
            //frmparent.lanzarNuevoElemento(detalleproyecto);
            //detalleproyecto.setModo("CREACIÓN");
        }

        private void quitarBordes()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            TopMost = true;
            ShowInTaskbar = false;
            this.Text = String.Empty;
            this.ControlBox = false;

            //quita bordes del datagrid
            this.dataListProyectos.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            this.dataListProyectos.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            this.dataListProyectos.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            this.dataListProyectos.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        }
        /*Utilizado para mover el panel atraves de la pantalla*/
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        /*fin del drag*/



        private void dataListProyectos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListProyectos.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListProyectos.Rows[e.RowIndex].Cells["Seleccionar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void dataListProyectos_CellDoubleClick(object sender, EventArgs e)
        {/*
            try
            {
                FrmDetalleProyecto detalleProyecto = new FrmDetalleProyecto();

                DInformacionProyecto.dataListProyectos = dataListProyectos;
                DInformacionProyecto.index = this.dataListProyectos.CurrentRow.Index;
                DInformacionProyecto.detalleProyecto = detalleProyecto;

                detalleProyecto.visualizaDatos(
                    Convert.ToString(this.dataListProyectos.CurrentRow.Cells["id"].Value),                    
                    Convert.ToString(this.dataListProyectos.CurrentRow.Cells["titulo"].Value),
                    Convert.ToString(this.dataListProyectos.CurrentRow.Cells["descripcion"].Value),
                    Convert.ToString(this.dataListProyectos.CurrentRow.Cells["observaciones"].Value),
                    Convert.ToString(this.dataListProyectos.CurrentRow.Cells["fecha"].Value)
                    );

                //Console.WriteLine(this.dataListProyectos.SelectedRows[2].Cells["id"].Value);


                frmparent.lanzarNuevoElemento(detalleProyecto);

                detalleProyecto.setModo("LECTURA");
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el evento Double click ", "Error en el evento Double click ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        /*PROCEDURES*/


        private void buscarProyecto(string texto)
        {
            this.dataListProyectos.DataSource = NProyecto.buscarproyecto(texto);
            this.ocultarcolumnas();
        }

        private void txtBuscarProyecto_TextChanged(object sender, EventArgs e)
        {
            //this.buscarProyecto(this.txtBuscarProyecto.Text);


            BindingSource bs = new BindingSource();
            bs.DataSource = dataListProyectos.DataSource;
            bs.Filter = string.Format("CONVERT(" + dataListProyectos.Columns[1].DataPropertyName + ", System.String) like '%" + txtBuscarProyecto.Text.Replace("'", "''") + "%'");
            dataListProyectos.DataSource = bs;
            dataListProyectos.Refresh();
        }

        private void botonIniciarMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea continuar?", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    int aux = 0;
                    string nombre;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListProyectos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            aux = 1;

                            nombre = Convert.ToString(row.Cells[1].Value);

                            string ruta = "";
                            if (StaticMonitor.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
                            {
                                DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Monitores");
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    Console.WriteLine(fi.Name + "estamos dentro");
                                    ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Monitores\\" + fi.Name;

                                    StaticMonitor.monitor.Add((Process.Start(ruta), ruta));

                                }
                            }
                            else
                            {
                                DirectoryInfo di = new DirectoryInfo(@StaticMonitor.rutaManual);
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    ruta = @StaticMonitor.rutaManual + "/" + fi.Name;
                                    StaticMonitor.monitor.Add((Process.Start(ruta), ruta));

                                }
                            }

                        }
                    }

                }
                else
                {
                    this.botonIniciarMonitor.Enabled = false;
                    this.cbCheckAll.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void botonApagar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea continuar?", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    int aux = 0;
                    string nombre;

                    foreach (DataGridViewRow row in dataListProyectos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            aux = 1;

                            nombre = Convert.ToString(row.Cells[1].Value);

                            string ruta = "";
                            if (StaticMonitor.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
                            {

                                DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Monitores");
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Monitores\\" + fi.Name;

                                    for (int i = 0; i < StaticMonitor.monitor.Count; i++)
                                    {
                                        if (StaticMonitor.monitor[i].Item2.Equals(ruta))
                                        {
                                            StaticMonitor.monitor[i].Item1.CloseMainWindow();
                                        };
                                    }
                                }

                            }
                            else
                            {
                                aux = 1;

                                nombre = Convert.ToString(row.Cells[1].Value);
                                ruta = "";
                                if (!StaticMonitor.rutaManual.Equals("")) //se pone la especificada
                                {

                                    DirectoryInfo di = new DirectoryInfo(@StaticMonitor.rutaManual);
                                    foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                    {
                                        ruta = @StaticMonitor.rutaManual + "/" + fi.Name;

                                        for (int i = 0; i < StaticMonitor.monitor.Count; i++)
                                        {
                                            if (StaticMonitor.monitor[i].Item2.Equals(ruta))
                                            {
                                                StaticMonitor.monitor[i].Item1.CloseMainWindow();
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {

            if (this.cbCheckAll.Checked)
            {

                for (int i = 0; i < dataListProyectos.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListProyectos.Rows[i].Cells["Seleccionar"];
                    chkeliminar.Value = true;
                }

            }
            else
            {
                for (int i = 0; i < dataListProyectos.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListProyectos.Rows[i].Cells["Seleccionar"];
                    chkeliminar.Value = false;
                }

            }

        }
        /*PROCEDURES*/
    }
}
