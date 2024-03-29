﻿using System;
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
        public FrmScraper()
        {
            InitializeComponent();
            colorPanel();
            mostrarScrapers();
        }

        private void mostrarScrapers()
        {
            DirectoryInfo di;
            if (StaticScraper.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
            {
                di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
            }
            else
            {
                di = new DirectoryInfo(StaticScraper.rutaManual + "/");
                arrayDataGrid.Clear();
            }
            DataTable dt = new DataTable();

            foreach (var fi in di.GetFiles())
            {
                System.IO.Path.GetFullPath(Application.ExecutablePath);
                //monitores.Append(fi.Name);
                arrayDataGrid.Add(fi.Name);
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
                    string nombre;
                    foreach (DataGridViewRow row in dataListScraper.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            nombre = Convert.ToString(row.Cells[1].Value);

                            string ruta = "";
                            if (StaticScraper.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
                            {
                                DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    Console.WriteLine(fi.Name + "estamos dentro");
                                    ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Scrapers\\" + fi.Name;

                                    StaticScraper.monitor.Add((Process.Start(ruta), ruta));
                                    row.DefaultCellStyle.BackColor = Color.PaleGreen;

                                }
                            }
                            else
                            {
                                DirectoryInfo di = new DirectoryInfo(@StaticScraper.rutaManual);
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    ruta = @StaticScraper.rutaManual + "/" + fi.Name;
                                    StaticScraper.monitor.Add((Process.Start(ruta), ruta));
                                    row.DefaultCellStyle.BackColor = Color.PaleGreen;

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
                    string nombre;

                    foreach (DataGridViewRow row in dataListScraper.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            nombre = Convert.ToString(row.Cells[1].Value);

                            string ruta = "";
                            if (StaticScraper.rutaManual.Equals(""))//si no se pone ruta se pone esta por defecto
                            {

                                DirectoryInfo di = new DirectoryInfo(@"C:\Users\cromero\Desktop\Proyecto\WebScraping\Scrapers");
                                foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                {
                                    ruta = "C:\\Users\\cromero\\Desktop\\Proyecto\\WebScraping\\Scrapers\\" + fi.Name;

                                    for (int i = 0; i < StaticScraper.monitor.Count; i++)
                                    {
                                        if (StaticScraper.monitor[i].Item2.Equals(ruta))
                                        {
                                            StaticScraper.monitor[i].Item1.CloseMainWindow();
                                            row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                                        };
                                    }
                                }

                            }
                            else
                            {

                                nombre = Convert.ToString(row.Cells[1].Value);
                                ruta = "";
                                if (!StaticScraper.rutaManual.Equals("")) //se pone la especificada
                                {

                                    DirectoryInfo di = new DirectoryInfo(@StaticScraper.rutaManual);
                                    foreach (var fi in di.EnumerateFiles("*" + nombre + "*"))
                                    {
                                        ruta = @StaticScraper.rutaManual + "/" + fi.Name;

                                        for (int i = 0; i < StaticScraper.monitor.Count; i++)
                                        {
                                            if (StaticScraper.monitor[i].Item2.Equals(ruta))
                                            {
                                                StaticScraper.monitor[i].Item1.CloseMainWindow();
                                                row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            StaticScraper.rutaManual = txtBuscarProyecto.Text;
            mostrarScrapers();
        }
    }
}
