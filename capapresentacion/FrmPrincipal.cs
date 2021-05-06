using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace capapresentacion
{
    public partial class FrmPrincipal : Form
    {
        private IconButton botonActual;
        private Panel panelIzquierdo;




        public FrmPrincipal()
        {
            InitializeComponent();
            panelIzquierdo = new Panel();
            panelIzquierdo.Size = new Size(7, 60);
            panelMenu.Controls.Add(panelIzquierdo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = string.Empty;
            coloresPaneles();
        }

        private void coloresPaneles()
        {
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            Proyectos.BackColor= Color.FromArgb(31, 30, 68); 
            Tareas.BackColor= Color.FromArgb(31, 30, 68); 
            panelTitulo.BackColor = Color.FromArgb(26, 25, 62);
            iconoFormularioActual.BackColor = Color.FromArgb(26, 25, 62);
            panelFormulario.BackColor = Color.FromArgb(34, 33, 74);

        }

        public struct RGBColors
        {
            public static Color color1 = Color.White;
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

        }

        public void AbrirFormulario(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormulario.Controls.Add(childForm);
            panelFormulario.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        public void ActivaBoton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                botonActual = (IconButton)senderBtn;
                botonActual.BackColor = Color.FromArgb(37, 36, 81);
                botonActual.ForeColor = color;
                botonActual.TextAlign = ContentAlignment.MiddleCenter;
                botonActual.IconColor = color;
                botonActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                botonActual.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                panelIzquierdo.BackColor = color;
                panelIzquierdo.Location = new Point(0, botonActual.Location.Y);
                panelIzquierdo.Visible = true;
                panelIzquierdo.BringToFront();
                //Current Child Form Icon
                iconoFormularioActual.IconChar = botonActual.IconChar;
                iconoFormularioActual.IconColor = color;
                textoInicio.Text = botonActual.Text;
            }
        }

        private void DisableButton()
        {
            if (botonActual != null)
            {

                botonActual.BackColor = Color.FromArgb(31, 30, 68);
                botonActual.ForeColor = Color.Gainsboro;
                botonActual.TextAlign = ContentAlignment.MiddleLeft;
                botonActual.IconColor = Color.Gainsboro;
                botonActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                botonActual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }



        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //this.FormClosed += new FormClosedEventHandler(cerrarX);
        }






/*Utilizado para mover el panel atraves de la pantalla*/
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /*fin del drag*/



        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void miminizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void Monitor_Click(object sender, EventArgs e)
        {
            ActivaBoton(sender, RGBColors.color5);
            FrmMonitor monitor = new FrmMonitor();
            monitor.frmparent = this;
            AbrirFormulario(monitor);
        }

        private void Scraper_Click(object sender, EventArgs e)
        {
            ActivaBoton(sender, RGBColors.color6);
            FrmScraper scraper = new FrmScraper();
            AbrirFormulario(scraper);
        }
    }
}
