using DotSpatial.Controls;
using DotSpatial.Projections;

namespace CadGenNet.MapNet
{
    partial class WinMapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();

            var legend = new Legend
            {
                Name = "Legend",
                Dock = DockStyle.Left,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            var map = new DotSpatial.Controls.Map
            {
                Name = "Map",
                Dock = DockStyle.Fill,
                FunctionMode = FunctionMode.Select,
                Legend = legend,
                BackColor = System.Drawing.Color.FromArgb(255, 206, 206, 206),
                TabStop = true,
            };
            var stereo70 = KnownCoordinateSystems.Projected.NationalGrids.Stereo1970;
            map.Projection = stereo70;
            Controls.Add(map);
            Controls.Add(legend);

            ResumeLayout(false);
        }

        public DotSpatial.Controls.Map GetMap()
        {
            return (DotSpatial.Controls.Map)Controls["Map"];
        }

        public Legend GetLegend()
        {
            return (Legend)Controls["Legend"];
        }

        #endregion
    }
}
