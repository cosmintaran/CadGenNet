using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;
using NetTopologySuite.Geometries;
using System.Windows.Forms;
using CadGenNet.MapNet;

namespace CadGenNet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private AppManager appManager1;
        private ProgressBar progressBar1;
        private WinMapControl mapControl;
        private MenuToolbarControl menuToolbarControl;
        private ContextMenuStrip contextMenuStrip;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SuspendLayout();

            mapControl = new WinMapControl
            {
                Dock = DockStyle.Fill
            };

            menuToolbarControl = new MenuToolbarControl
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            menuToolbarControl.OpenShapefileClicked += OpenShapefile;
            menuToolbarControl.SaveClicked += MenuToolbarControl_SaveClicked;

            progressBar1 = new ProgressBar
            {
                Name = "progressBar1",
                Dock = DockStyle.Bottom,
                Minimum = 0,
                Maximum = 100,
                Height = 20
            };

            Controls.Add(mapControl);
            Controls.Add(menuToolbarControl);
            Controls.Add(progressBar1);

            // Initialize AppManager
            appManager1 = new AppManager();
            appManager1.Map = mapControl.GetMap();
            appManager1.Legend = mapControl.GetLegend();
            appManager1.Directories = (List<string>)resources.GetObject("appManager1.Directories");

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Name = "CadGenNet";
            Text = "CadGenNet Map";

            contextMenuStrip = new ContextMenuStrip();
            var menuItem1 = new ToolStripMenuItem("Option 1", null, MenuItem1_Click);
            var menuItem2 = new ToolStripMenuItem("Option 2", null, MenuItem2_Click);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { menuItem1, menuItem2 });


            mapControl.GetMap().KeyDown += new KeyEventHandler(Map_KeyDown);
            mapControl.GetMap().MouseUp += new MouseEventHandler(Map_MouseUp);
            mapControl.GetMap().Focus();

            ResumeLayout(false);
            PerformLayout();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>



        #endregion

    }
}
