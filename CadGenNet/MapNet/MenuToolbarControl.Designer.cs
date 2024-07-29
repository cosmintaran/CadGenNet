
namespace CadGenNet.MapNet
{
    partial class MenuToolbarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public event EventHandler OpenShapefileClicked;
        public event EventHandler SaveClicked;
        public ComboBox LayerComboBox { get; private set; }

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

            // Create and configure MenuStrip
            var menuStrip1 = new MenuStrip();
            var fileMenuItem = new ToolStripMenuItem("File");
            var openMenuItem = new ToolStripMenuItem("Open Shapefile", null, OpenShapefileMenuItem_Click);
            var saveMenuItem = new ToolStripMenuItem("Save", null, SaveProject);
            fileMenuItem.DropDownItems.Add(openMenuItem);
            fileMenuItem.DropDownItems.Add(saveMenuItem);
            menuStrip1.Items.Add(fileMenuItem);

            // Create and configure ToolStrip
            var toolStrip1 = new ToolStrip();
            var openToolStripButton = new ToolStripButton("Open Shapefile", null, OpenShapefileToolStripButton_Click);
            toolStrip1.Items.Add(openToolStripButton);

            // Add MenuStrip and ToolStrip to a ToolStripContainer
            var toolStripContainer = new ToolStripContainer() 
            {
                Dock = DockStyle.Fill,
            };

            LayerComboBox = new ComboBox
            {
                Name = "LayerComboBox",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 200
            };
            var layerToolStripComboBox = new ToolStripControlHost(LayerComboBox);
            toolStrip1.Items.Add(layerToolStripComboBox);

            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip1);
            toolStripContainer.TopToolStripPanel.Controls.Add(menuStrip1);

            Controls.Add(toolStripContainer);

            ResumeLayout(false);
        }
        #endregion
    }
}
