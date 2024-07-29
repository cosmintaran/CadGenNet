namespace CadGenNet.MapNet
{
    public partial class MenuToolbarControl : UserControl
    {
        public MenuToolbarControl()
        {
            InitializeComponent();
        }

        private void SaveProject(object? sender, EventArgs e)
        {
            SaveClicked?.Invoke(sender, e);
        }

        private void OpenShapefileMenuItem_Click(object sender, EventArgs e)
        {
            OpenShapefileClicked?.Invoke(sender, e);
        }

        private void OpenShapefileToolStripButton_Click(object sender, EventArgs e)
        {
            OpenShapefileClicked?.Invoke(sender, e);
        }
    }
}
