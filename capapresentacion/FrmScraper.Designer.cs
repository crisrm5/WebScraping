﻿
namespace capapresentacion
{
    partial class FrmScraper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScraper));
            this.label1 = new System.Windows.Forms.Label();
            this.label_añadir = new System.Windows.Forms.Label();
            this.panelRecuadro = new System.Windows.Forms.Panel();
            this.dataListScraper = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbCheckAll = new System.Windows.Forms.CheckBox();
            this.txtBuscarProyecto = new System.Windows.Forms.TextBox();
            this.botonApagar = new System.Windows.Forms.Button();
            this.botonIniciarMonitor = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelRecuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListScraper)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(133, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Iniciar";
            // 
            // label_añadir
            // 
            this.label_añadir.AutoSize = true;
            this.label_añadir.ForeColor = System.Drawing.SystemColors.Control;
            this.label_añadir.Location = new System.Drawing.Point(232, 147);
            this.label_añadir.Name = "label_añadir";
            this.label_añadir.Size = new System.Drawing.Size(45, 13);
            this.label_añadir.TabIndex = 35;
            this.label_añadir.Text = "Detener";
            // 
            // panelRecuadro
            // 
            this.panelRecuadro.BackColor = System.Drawing.Color.Gold;
            this.panelRecuadro.Controls.Add(this.dataListScraper);
            this.panelRecuadro.Location = new System.Drawing.Point(39, 179);
            this.panelRecuadro.Name = "panelRecuadro";
            this.panelRecuadro.Size = new System.Drawing.Size(663, 282);
            this.panelRecuadro.TabIndex = 34;
            // 
            // dataListScraper
            // 
            this.dataListScraper.AllowUserToAddRows = false;
            this.dataListScraper.AllowUserToDeleteRows = false;
            this.dataListScraper.AllowUserToOrderColumns = true;
            this.dataListScraper.BackgroundColor = System.Drawing.Color.White;
            this.dataListScraper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListScraper.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataListScraper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListScraper.Location = new System.Drawing.Point(0, 0);
            this.dataListScraper.Name = "dataListScraper";
            this.dataListScraper.ReadOnly = true;
            this.dataListScraper.RowHeadersVisible = false;
            this.dataListScraper.RowHeadersWidth = 51;
            this.dataListScraper.Size = new System.Drawing.Size(663, 282);
            this.dataListScraper.TabIndex = 4;
            this.dataListScraper.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListScraper_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 2;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cbCheckAll
            // 
            this.cbCheckAll.AutoSize = true;
            this.cbCheckAll.ForeColor = System.Drawing.SystemColors.Control;
            this.cbCheckAll.Location = new System.Drawing.Point(39, 147);
            this.cbCheckAll.Name = "cbCheckAll";
            this.cbCheckAll.Size = new System.Drawing.Size(70, 17);
            this.cbCheckAll.TabIndex = 32;
            this.cbCheckAll.Text = "Check all";
            this.cbCheckAll.UseVisualStyleBackColor = true;
            this.cbCheckAll.CheckedChanged += new System.EventHandler(this.cbCheckAll_CheckedChanged);
            // 
            // txtBuscarProyecto
            // 
            this.txtBuscarProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarProyecto.Location = new System.Drawing.Point(39, 54);
            this.txtBuscarProyecto.Name = "txtBuscarProyecto";
            this.txtBuscarProyecto.Size = new System.Drawing.Size(634, 20);
            this.txtBuscarProyecto.TabIndex = 31;
            // 
            // botonApagar
            // 
            this.botonApagar.BackColor = System.Drawing.Color.Transparent;
            this.botonApagar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonApagar.BackgroundImage")));
            this.botonApagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botonApagar.FlatAppearance.BorderSize = 0;
            this.botonApagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonApagar.Location = new System.Drawing.Point(283, 137);
            this.botonApagar.Name = "botonApagar";
            this.botonApagar.Size = new System.Drawing.Size(41, 32);
            this.botonApagar.TabIndex = 37;
            this.botonApagar.UseVisualStyleBackColor = false;
            this.botonApagar.Click += new System.EventHandler(this.botonApagar_Click);
            // 
            // botonIniciarMonitor
            // 
            this.botonIniciarMonitor.BackColor = System.Drawing.Color.Transparent;
            this.botonIniciarMonitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonIniciarMonitor.BackgroundImage")));
            this.botonIniciarMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botonIniciarMonitor.FlatAppearance.BorderSize = 0;
            this.botonIniciarMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonIniciarMonitor.Location = new System.Drawing.Point(174, 138);
            this.botonIniciarMonitor.Name = "botonIniciarMonitor";
            this.botonIniciarMonitor.Size = new System.Drawing.Size(34, 32);
            this.botonIniciarMonitor.TabIndex = 36;
            this.botonIniciarMonitor.UseVisualStyleBackColor = false;
            this.botonIniciarMonitor.Click += new System.EventHandler(this.botonIniciarMonitor_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = global::capapresentacion.Properties.Resources.addNew;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(676, 54);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(26, 20);
            this.btnNuevo.TabIndex = 33;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // FrmScraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonApagar);
            this.Controls.Add(this.botonIniciarMonitor);
            this.Controls.Add(this.label_añadir);
            this.Controls.Add(this.panelRecuadro);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbCheckAll);
            this.Controls.Add(this.txtBuscarProyecto);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FrmScraper";
            this.Text = "FrmScraper";
            this.panelRecuadro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListScraper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonApagar;
        private System.Windows.Forms.Button botonIniciarMonitor;
        private System.Windows.Forms.Label label_añadir;
        private System.Windows.Forms.Panel panelRecuadro;
        private System.Windows.Forms.DataGridView dataListScraper;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.CheckBox cbCheckAll;
        private System.Windows.Forms.TextBox txtBuscarProyecto;
    }
}