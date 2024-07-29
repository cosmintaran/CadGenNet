using CadGenNet.Map;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;
using NetTopologySuite.Geometries;
using System.Windows.Forms;

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
            mapControl.GetMap().MouseDown += new MouseEventHandler(Map_MouseDown);
            mapControl.GetMap().Focus();

            ResumeLayout(false);
            PerformLayout();
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }


        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var map = sender as DotSpatial.Controls.Map;
                System.Drawing.Point loc = new(e.X + ((Legend)map.Legend).ControlRectangle.X, e.Location.Y + ((Legend)map.Legend).ControlRectangle.Top);
                // Convert mouse coordinates to map coordinates
                Coordinate coord = map.PixelToProj(loc);
                var pp = map.ProjToPixel(coord);
                // Define a small tolerance for the selection
                double tolerance = 0.00001;

                // Create an extent around the clicked point
                var extent = new Extent(coord.X - tolerance, coord.Y - tolerance, coord.X + tolerance, coord.Y + tolerance);

                // Clear previous selections
                foreach (var layers in map.GetFeatureLayers())
                {
                    layers.ClearSelection();
                }

                // Select features within the extent
                IMapFeatureLayer selectedLayer = null;
                var layer = map.GetFeatureLayers().Where(s=>s.IsSelected == true && s.IsVisible == true).FirstOrDefault();

                if (layer != null)
                {
                    var features = layer.DataSet.Select(extent).FirstOrDefault();
                    if (features != null)
                    {
                        layer.Select(features);
                        selectedLayer = layer;


                        contextMenuStrip.Tag = selectedLayer;
                        contextMenuStrip.Show(map, e.Location);
                    }
                }

            }
        }

        private void OpenShapefile(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    IFeatureSet featureSet = FeatureSet.Open(filePath);
                    featureSet.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
                    appManager1.Map.Layers.Add(featureSet);
                }
            }
        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var featureLayer in mapControl.GetMap().GetFeatureLayers().Where(s => s.Selection.Count > 0))
            {

                featureLayer.ClearSelection(out var envelope, true);
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>



        #endregion

    }
}
