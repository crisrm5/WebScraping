using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capapresentacion
{
    public partial class FrmScraper : Form
    {
        public List<string> arrayDataGrid = new List<string>();
        List<(Process, string)> monitor = new List<(Process, string)>();
        public FrmScraper()
        {
            InitializeComponent();
            colorPanel();
            mostrarScrapers();
        }

        private void mostrarScrapers()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
            //Console.WriteLine("No search pattern returns:");
            DataTable dt = new DataTable();

            foreach (var fi in di.GetFiles())
            {
                System.IO.Path.GetFullPath(Application.ExecutablePath);
                //monitores.Append(fi.Name);
                arrayDataGrid.Add(fi.Name);
                Console.WriteLine(fi.Name);
            }



            var result = arrayDataGrid.Select(s => new { value = s }).ToList();
            dataListScraper.DataSource = result;
            dataListScraper.Columns[1].HeaderText = "Scraper";
        }

        private void colorPanel()
        {
            this.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void dataListScraper_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListScraper.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListScraper.Rows[e.RowIndex].Cells["Seleccionar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbCheckAll.Checked)
            {

                for (int i = 0; i < dataListScraper.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListScraper.Rows[i].Cells["Seleccionar"];
                    chkeliminar.Value = true;
                }

            }
            else
            {
                for (int i = 0; i < dataListScraper.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListScraper.Rows[i].Cells["Seleccionar"];
                    chkeliminar.Value = false;
                }

            }
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
                    foreach (DataGridViewRow row in dataListScraper.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            aux = 1;

                            nombre = Convert.ToString(row.Cells[1].Value);
                            //rpta = NProyecto.eliminarproyecto(id);
                            // Console.WriteLine(nombre);
                            string ruta = "";
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
                            foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                            {
                                Console.WriteLine(fi.Name + "estamos dentro");
                                ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Scrapers\\" + fi.Name;
                                //System.IO.Path.GetFullPath(Application.pru);
                                //Process.Start("C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Monitores\\hola.txt");
                                //monitor = new Monitores(Process.Start(ruta), ruta);
                                monitor.Add((Process.Start(ruta), ruta));
                                // monitor.Add();

                                //monitor.MonitorEjecutandose.Append<Process>(Process.Start(ruta));
                                //monitor.Ruta.Append<String>(ruta);
                                //monitor = new Monitores(Process.Start(pru),pru);

                                //myProcess = Process.Start(pru);
                                //System.Diagnostics.Process.Start(pru);
                            }
                            //System.IO.File.Open("");







                            if (rpta.Equals("OK"))
                            {
                               // this.mensajeok("Registro eliminado");
                            }
                            else
                            {
                                //  this.mensajeerror("¡Ups!, Al parecer tienes tareas asignadas a este proyecto...");
                                //  this.mensajeerror(rpta);
                            }
                        }
                    }
                    if (aux < 1)
                    {
                        // MessageBox.Show("No haz seleccionado ningún proyecto", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    //this.mostrarproyectos();
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
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListScraper.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            aux = 1;

                            nombre = Convert.ToString(row.Cells[1].Value);
                            //rpta = NProyecto.eliminarproyecto(id);
                            Console.WriteLine(nombre);
                            string ruta = "";
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
                            foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                            {
                                Console.WriteLine(fi.Name + "estamos dentro");
                                ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Scrapers\\" + fi.Name;
                                //System.IO.Path.GetFullPath(Application.pru);
                                //Process.Start("C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Monitores\\hola.txt");
                                //System.Diagnostics.Process.Start(pru);
                                //Console.WriteLine(monitor.MonitorEjecutandose.Length);
                                //monitor[0].Item1.CloseMainWindow();




                                for (int i = 0; i < monitor.Count; i++)
                                {
                                    if (monitor[i].Item2.Equals(ruta))
                                    {
                                        monitor[i].Item1.CloseMainWindow();
                                    };
                                }
                                //Console.WriteLine(monitor.Ruta[i]);
                                //Console.WriteLine(monitor.Ruta[0]+" esta es la ruta antes del if");
                                //if (monitor.Ruta.Equals(pru))
                                // {
                                //     Console.WriteLine(pru + " estamos dentro del if");
                                // };
                                //monitor.MonitorEjecutandose[i].CloseMainWindow();
                                //}

                                /* if (monitor.Ruta.Equals(pru))
                                 {
                                     monitor.MonitorEjecutandose.CloseMainWindow();
                                 }*/

                                // myProcess.Close();
                            }
                            //System.IO.File.Open("");







                            if (rpta.Equals("OK"))
                            {
                                //this.mensajeok("Registro eliminado");
                            }
                            else
                            {
                                //  this.mensajeerror("¡Ups!, Al parecer tienes tareas asignadas a este proyecto...");
                                //  this.mensajeerror(rpta);
                            }
                        }
                    }
                    if (aux < 1)
                    {
                        // MessageBox.Show("No haz seleccionado ningún proyecto", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    //this.mostrarproyectos();
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
    }
}
