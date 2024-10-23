
namespace MMSDomaci
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxAndMinCanalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egdeEnhanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossDomainColorizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downsampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downsamplingChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCanals = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.pictureB = new System.Windows.Forms.PictureBox();
            this.pictureG = new System.Windows.Forms.PictureBox();
            this.pictureR = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbRed = new System.Windows.Forms.RadioButton();
            this.rbGreen = new System.Windows.Forms.RadioButton();
            this.rbBlue = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.lbRed = new System.Windows.Forms.Label();
            this.lbGreen = new System.Windows.Forms.Label();
            this.lbBlue = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.extraFiltersToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1312, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.optionsToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::MMSDomaci.Properties.Resources.undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::MMSDomaci.Properties.Resources.redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem,
            this.gammaToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.maxAndMinCanalToolStripMenuItem,
            this.grayscaleToolStripMenuItem1,
            this.orderDitheringToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.rGBToolStripMenuItem.Text = "RGB Cannels";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.colorsToolStripMenuItem.Text = "256 Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // maxAndMinCanalToolStripMenuItem
            // 
            this.maxAndMinCanalToolStripMenuItem.Name = "maxAndMinCanalToolStripMenuItem";
            this.maxAndMinCanalToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.maxAndMinCanalToolStripMenuItem.Text = "Max and Min Channels";
            this.maxAndMinCanalToolStripMenuItem.Click += new System.EventHandler(this.maxAndMinCanalToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem1
            // 
            this.grayscaleToolStripMenuItem1.Name = "grayscaleToolStripMenuItem1";
            this.grayscaleToolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.grayscaleToolStripMenuItem1.Text = "Grayscales";
            this.grayscaleToolStripMenuItem1.Click += new System.EventHandler(this.grayscaleToolStripMenuItem1_Click);
            // 
            // orderDitheringToolStripMenuItem
            // 
            this.orderDitheringToolStripMenuItem.Name = "orderDitheringToolStripMenuItem";
            this.orderDitheringToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.orderDitheringToolStripMenuItem.Text = "Order dithering";
            this.orderDitheringToolStripMenuItem.Click += new System.EventHandler(this.orderDitheringToolStripMenuItem_Click);
            // 
            // extraFiltersToolStripMenuItem
            // 
            this.extraFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.egdeEnhanceToolStripMenuItem,
            this.pixelateToolStripMenuItem,
            this.crossDomainColorizeToolStripMenuItem,
            this.downsampleToolStripMenuItem,
            this.downsamplingChannelsToolStripMenuItem});
            this.extraFiltersToolStripMenuItem.Name = "extraFiltersToolStripMenuItem";
            this.extraFiltersToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.extraFiltersToolStripMenuItem.Text = "Extra Filters";
            // 
            // egdeEnhanceToolStripMenuItem
            // 
            this.egdeEnhanceToolStripMenuItem.Name = "egdeEnhanceToolStripMenuItem";
            this.egdeEnhanceToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.egdeEnhanceToolStripMenuItem.Text = "EgdeEnhance";
            this.egdeEnhanceToolStripMenuItem.Click += new System.EventHandler(this.egdeEnhanceToolStripMenuItem_Click);
            // 
            // pixelateToolStripMenuItem
            // 
            this.pixelateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.noGridToolStripMenuItem});
            this.pixelateToolStripMenuItem.Name = "pixelateToolStripMenuItem";
            this.pixelateToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.pixelateToolStripMenuItem.Text = "Pixelate";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // noGridToolStripMenuItem
            // 
            this.noGridToolStripMenuItem.Name = "noGridToolStripMenuItem";
            this.noGridToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.noGridToolStripMenuItem.Text = "NoGrid";
            this.noGridToolStripMenuItem.Click += new System.EventHandler(this.noGridToolStripMenuItem_Click);
            // 
            // crossDomainColorizeToolStripMenuItem
            // 
            this.crossDomainColorizeToolStripMenuItem.Name = "crossDomainColorizeToolStripMenuItem";
            this.crossDomainColorizeToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.crossDomainColorizeToolStripMenuItem.Text = "CrossDomainColorize";
            this.crossDomainColorizeToolStripMenuItem.Click += new System.EventHandler(this.crossDomainColorizeToolStripMenuItem_Click);
            // 
            // downsampleToolStripMenuItem
            // 
            this.downsampleToolStripMenuItem.Name = "downsampleToolStripMenuItem";
            this.downsampleToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.downsampleToolStripMenuItem.Text = "Downsampling";
            this.downsampleToolStripMenuItem.Click += new System.EventHandler(this.downsampleToolStripMenuItem_Click);
            // 
            // downsamplingChannelsToolStripMenuItem
            // 
            this.downsamplingChannelsToolStripMenuItem.Name = "downsamplingChannelsToolStripMenuItem";
            this.downsamplingChannelsToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.downsamplingChannelsToolStripMenuItem.Text = "Downsampling Channels";
            this.downsamplingChannelsToolStripMenuItem.Click += new System.EventHandler(this.downsamplingChannelsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // openImage
            // 
            this.openImage.FileName = " ";
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(68, 407);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(116, 31);
            this.btnHistogram.TabIndex = 6;
            this.btnHistogram.Text = "Histogram RGB";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(435, 31);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(298, 416);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(724, 31);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(313, 416);
            this.chart2.TabIndex = 14;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(1025, 31);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(298, 416);
            this.chart3.TabIndex = 15;
            this.chart3.Text = "chart3";
            // 
            // btnCanals
            // 
            this.btnCanals.Location = new System.Drawing.Point(278, 407);
            this.btnCanals.Name = "btnCanals";
            this.btnCanals.Size = new System.Drawing.Size(107, 31);
            this.btnCanals.TabIndex = 16;
            this.btnCanals.Text = "Canals";
            this.btnCanals.UseVisualStyleBackColor = true;
            this.btnCanals.Click += new System.EventHandler(this.btnCanals_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(7, 31);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(208, 182);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 5;
            this.picture.TabStop = false;
            // 
            // pictureB
            // 
            this.pictureB.Location = new System.Drawing.Point(221, 219);
            this.pictureB.Name = "pictureB";
            this.pictureB.Size = new System.Drawing.Size(208, 182);
            this.pictureB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureB.TabIndex = 4;
            this.pictureB.TabStop = false;
            // 
            // pictureG
            // 
            this.pictureG.Location = new System.Drawing.Point(7, 219);
            this.pictureG.Name = "pictureG";
            this.pictureG.Size = new System.Drawing.Size(208, 182);
            this.pictureG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureG.TabIndex = 3;
            this.pictureG.TabStop = false;
            // 
            // pictureR
            // 
            this.pictureR.Location = new System.Drawing.Point(221, 31);
            this.pictureR.Name = "pictureR";
            this.pictureR.Size = new System.Drawing.Size(208, 182);
            this.pictureR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureR.TabIndex = 2;
            this.pictureR.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // rbRed
            // 
            this.rbRed.AutoSize = true;
            this.rbRed.Location = new System.Drawing.Point(7, 413);
            this.rbRed.Name = "rbRed";
            this.rbRed.Size = new System.Drawing.Size(54, 20);
            this.rbRed.TabIndex = 18;
            this.rbRed.TabStop = true;
            this.rbRed.Text = "Red";
            this.rbRed.UseVisualStyleBackColor = true;
            // 
            // rbGreen
            // 
            this.rbGreen.AutoSize = true;
            this.rbGreen.Location = new System.Drawing.Point(68, 414);
            this.rbGreen.Name = "rbGreen";
            this.rbGreen.Size = new System.Drawing.Size(65, 20);
            this.rbGreen.TabIndex = 19;
            this.rbGreen.TabStop = true;
            this.rbGreen.Text = "Green";
            this.rbGreen.UseVisualStyleBackColor = true;
            // 
            // rbBlue
            // 
            this.rbBlue.AutoSize = true;
            this.rbBlue.Location = new System.Drawing.Point(139, 414);
            this.rbBlue.Name = "rbBlue";
            this.rbBlue.Size = new System.Drawing.Size(55, 20);
            this.rbBlue.TabIndex = 20;
            this.rbBlue.TabStop = true;
            this.rbBlue.Text = "Blue";
            this.rbBlue.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorPicker
            // 
            this.colorPicker.AnyColor = true;
            this.colorPicker.Color = System.Drawing.Color.Red;
            this.colorPicker.FullOpen = true;
            // 
            // lbRed
            // 
            this.lbRed.AutoSize = true;
            this.lbRed.Location = new System.Drawing.Point(221, 31);
            this.lbRed.Name = "lbRed";
            this.lbRed.Size = new System.Drawing.Size(0, 16);
            this.lbRed.TabIndex = 22;
            // 
            // lbGreen
            // 
            this.lbGreen.AutoSize = true;
            this.lbGreen.Location = new System.Drawing.Point(4, 219);
            this.lbGreen.Name = "lbGreen";
            this.lbGreen.Size = new System.Drawing.Size(0, 16);
            this.lbGreen.TabIndex = 23;
            // 
            // lbBlue
            // 
            this.lbBlue.AutoSize = true;
            this.lbBlue.Location = new System.Drawing.Point(221, 219);
            this.lbBlue.Name = "lbBlue";
            this.lbBlue.Size = new System.Drawing.Size(0, 16);
            this.lbBlue.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1312, 453);
            this.Controls.Add(this.lbBlue);
            this.Controls.Add(this.lbGreen);
            this.Controls.Add(this.lbRed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbBlue);
            this.Controls.Add(this.rbGreen);
            this.Controls.Add(this.rbRed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCanals);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnHistogram);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.pictureB);
            this.Controls.Add(this.pictureG);
            this.Controls.Add(this.pictureR);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MMS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureR;
        private System.Windows.Forms.PictureBox pictureG;
        private System.Windows.Forms.PictureBox pictureB;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egdeEnhanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noGridToolStripMenuItem;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button btnCanals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem maxAndMinCanalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossDomainColorizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downsampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downsamplingChannelsToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Label lbRed;
        private System.Windows.Forms.Label lbGreen;
        private System.Windows.Forms.Label lbBlue;
    }
}

