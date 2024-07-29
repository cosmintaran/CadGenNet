using System.Diagnostics;
using DotSpatial.Data;

namespace CadGenNet.MapNet
{
    public class CustomMapProgressHandler : IProgressHandler
    {
        private readonly ProgressBar _progressBar;

        public CustomMapProgressHandler(ProgressBar progressBar)
        {
            _progressBar = progressBar;
        }

        public void Progress(string key, int percent, string message)
        {
            _progressBar.Value = percent;
            _progressBar.Refresh();
        }

        public void Progress(int percent, string message)
        {
            Debug.WriteLine(message);
        }

        public void Reset()
        {
            Debug.WriteLine("Progress reset.");
        }
    }

}
