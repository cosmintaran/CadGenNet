using DotSpatial.Controls;
using DotSpatial.Symbology;
using System.Drawing;
using System.Windows.Forms;

namespace CadGenNet.Map
{
    public class CustomMapFunction : MapFunction
    {
        private readonly IMapFeatureLayer _targetLayer;

        public CustomMapFunction(IMap map, IMapFeatureLayer targetLayer)
            : base(map)
        {
            _targetLayer = targetLayer;
        }

        protected override void OnMouseDown(GeoMouseArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Perform selection
            //    var drawn = _targetLayer.DataSet.Select(e.);
            //    _targetLayer.Selection.AddRange(drawn);
            //    _targetLayer.;
            //    Map.Invalidate();
            //}

            base.OnMouseDown(e);
        }
    }
}
