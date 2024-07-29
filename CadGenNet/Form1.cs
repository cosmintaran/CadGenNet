using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;
using NetTopologySuite.Geometries;
using Point = System.Drawing.Point;


namespace CadGenNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuToolbarControl_SaveClicked(object sender, EventArgs e)
        {
            try
            {
                mapControl.GetMap()?.SaveLayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (sender is not Map map) return;

            Point loc = new(e.X + ((Legend)map.Legend).ControlRectangle.X, e.Location.Y + ((Legend)map.Legend).ControlRectangle.Top);

            // Clear previous selections
            foreach (var layers in map.GetFeatureLayers())
            {
                layers.ClearSelection();
            }
 
            Envelope env = new(e.X, e.X, e.Y, e.Y);
            Envelope tolerant = env;

            double tol = map.MapFrame.ViewExtents.Width / 10000;
            env.ExpandBy(tol);

            Coordinate c1 = map.PixelToProj(new Point(e.X - 4, e.Y - 4));
            Coordinate c2 = map.PixelToProj(new Point(e.X + 4, e.Y + 4));
            var strict = new Envelope(c1, c2);

            if (!map.MapFrame.GetAllLayers().Any(static l => l.SelectionEnabled && l.IsVisible))
            {
                MessageBox.Show(Resources.MapFunctionSelect_NoSelectableLayer);
            }
            else
            {

                map.Select(tolerant, strict, ClearStates.False);
            }
            contextMenuStrip.Show(map, loc);
        }

        private void OpenShapefile(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Resources.ShapefileFilter;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            string filePath = openFileDialog.FileName;
            IFeatureSet featureSet = FeatureSet.Open(filePath);
            featureSet.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            appManager1.Map.Layers.Add(featureSet);
        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var featureLayer in mapControl.GetMap().GetFeatureLayers().Where(static s => s.Selection.Count > 0))
            {

                featureLayer.ClearSelection(out var envelope, true);
            }
        }
    }
}
