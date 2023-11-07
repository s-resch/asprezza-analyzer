namespace AsprezzaAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btPlotAsprezza = new System.Windows.Forms.Button();
            this.clbTextSelection = new System.Windows.Forms.CheckedListBox();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.ofdSelectTextFile = new System.Windows.Forms.OpenFileDialog();
            this.btCheckAll = new System.Windows.Forms.Button();
            this.btExportPng = new System.Windows.Forms.Button();
            this.formsPlotAsprezzaPlot = new ScottPlot.FormsPlot();
            this.gbAnalysis = new System.Windows.Forms.GroupBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btExportCsv = new System.Windows.Forms.Button();
            this.btExportXml = new System.Windows.Forms.Button();
            this.lbDataPointView = new System.Windows.Forms.Label();
            this.btSetAspRules = new System.Windows.Forms.Button();
            this.lbAsprezzaDataHeading = new System.Windows.Forms.Label();
            this.gbTextSelect = new System.Windows.Forms.GroupBox();
            this.btUncheckAll = new System.Windows.Forms.Button();
            this.sfdExportImage = new System.Windows.Forms.SaveFileDialog();
            this.gbAnalysis.SuspendLayout();
            this.gbTextSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btPlotAsprezza
            // 
            this.btPlotAsprezza.Location = new System.Drawing.Point(7, 22);
            this.btPlotAsprezza.Margin = new System.Windows.Forms.Padding(4);
            this.btPlotAsprezza.Name = "btPlotAsprezza";
            this.btPlotAsprezza.Size = new System.Drawing.Size(128, 28);
            this.btPlotAsprezza.TabIndex = 0;
            this.btPlotAsprezza.Text = "Plot Asprezza";
            this.btPlotAsprezza.UseVisualStyleBackColor = true;
            this.btPlotAsprezza.Click += new System.EventHandler(this.btPlotAsprezza_Click);
            // 
            // clbTextSelection
            // 
            this.clbTextSelection.CheckOnClick = true;
            this.clbTextSelection.FormattingEnabled = true;
            this.clbTextSelection.Location = new System.Drawing.Point(7, 22);
            this.clbTextSelection.Margin = new System.Windows.Forms.Padding(4);
            this.clbTextSelection.Name = "clbTextSelection";
            this.clbTextSelection.Size = new System.Drawing.Size(308, 123);
            this.clbTextSelection.TabIndex = 1;
            // 
            // btSelectFile
            // 
            this.btSelectFile.Location = new System.Drawing.Point(324, 22);
            this.btSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(100, 28);
            this.btSelectFile.TabIndex = 2;
            this.btSelectFile.Text = "Select File";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // ofdSelectTextFile
            // 
            this.ofdSelectTextFile.Filter = "TEI XML-Files|*.xml";
            this.ofdSelectTextFile.Title = "Select file to be analyzed for asprezza";
            // 
            // btCheckAll
            // 
            this.btCheckAll.Location = new System.Drawing.Point(324, 52);
            this.btCheckAll.Margin = new System.Windows.Forms.Padding(4);
            this.btCheckAll.Name = "btCheckAll";
            this.btCheckAll.Size = new System.Drawing.Size(100, 28);
            this.btCheckAll.TabIndex = 10;
            this.btCheckAll.Text = "Check All";
            this.btCheckAll.UseVisualStyleBackColor = true;
            this.btCheckAll.Click += new System.EventHandler(this.btCheckAll_Click);
            // 
            // btExportPng
            // 
            this.btExportPng.Location = new System.Drawing.Point(7, 116);
            this.btExportPng.Margin = new System.Windows.Forms.Padding(4);
            this.btExportPng.Name = "btExportPng";
            this.btExportPng.Size = new System.Drawing.Size(128, 28);
            this.btExportPng.TabIndex = 11;
            this.btExportPng.Text = "Export PNG";
            this.btExportPng.UseVisualStyleBackColor = true;
            this.btExportPng.Click += new System.EventHandler(this.btExportPng_Click);
            // 
            // formsPlotAsprezzaPlot
            // 
            this.formsPlotAsprezzaPlot.Location = new System.Drawing.Point(7, 196);
            this.formsPlotAsprezzaPlot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlotAsprezzaPlot.Name = "formsPlotAsprezzaPlot";
            this.formsPlotAsprezzaPlot.Size = new System.Drawing.Size(884, 388);
            this.formsPlotAsprezzaPlot.TabIndex = 12;
            this.formsPlotAsprezzaPlot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formsPlotAsprezzaPlot_MouseClicked);
            // 
            // gbAnalysis
            // 
            this.gbAnalysis.Controls.Add(this.iconButton1);
            this.gbAnalysis.Controls.Add(this.btExportCsv);
            this.gbAnalysis.Controls.Add(this.btExportXml);
            this.gbAnalysis.Controls.Add(this.lbDataPointView);
            this.gbAnalysis.Controls.Add(this.btSetAspRules);
            this.gbAnalysis.Controls.Add(this.btExportPng);
            this.gbAnalysis.Controls.Add(this.lbAsprezzaDataHeading);
            this.gbAnalysis.Controls.Add(this.btPlotAsprezza);
            this.gbAnalysis.Location = new System.Drawing.Point(449, 15);
            this.gbAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.gbAnalysis.Name = "gbAnalysis";
            this.gbAnalysis.Padding = new System.Windows.Forms.Padding(4);
            this.gbAnalysis.Size = new System.Drawing.Size(419, 164);
            this.gbAnalysis.TabIndex = 13;
            this.gbAnalysis.TabStop = false;
            this.gbAnalysis.Text = "Analysis";
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.BalanceScale;
            this.iconButton1.IconColor = System.Drawing.Color.Gray;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(364, 15);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(48, 30);
            this.iconButton1.TabIndex = 14;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btExportCsv
            // 
            this.btExportCsv.Location = new System.Drawing.Point(276, 116);
            this.btExportCsv.Margin = new System.Windows.Forms.Padding(4);
            this.btExportCsv.Name = "btExportCsv";
            this.btExportCsv.Size = new System.Drawing.Size(128, 28);
            this.btExportCsv.TabIndex = 13;
            this.btExportCsv.Text = "Export CSV";
            this.btExportCsv.UseVisualStyleBackColor = true;
            this.btExportCsv.Click += new System.EventHandler(this.btExportCsv_Click);
            // 
            // btExportXml
            // 
            this.btExportXml.Location = new System.Drawing.Point(140, 116);
            this.btExportXml.Margin = new System.Windows.Forms.Padding(4);
            this.btExportXml.Name = "btExportXml";
            this.btExportXml.Size = new System.Drawing.Size(128, 28);
            this.btExportXml.TabIndex = 12;
            this.btExportXml.Text = "Export XML";
            this.btExportXml.UseVisualStyleBackColor = true;
            this.btExportXml.Click += new System.EventHandler(this.btExportXml_Click);
            // 
            // lbDataPointView
            // 
            this.lbDataPointView.AutoSize = true;
            this.lbDataPointView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataPointView.Location = new System.Drawing.Point(154, 56);
            this.lbDataPointView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataPointView.Name = "lbDataPointView";
            this.lbDataPointView.Size = new System.Drawing.Size(23, 20);
            this.lbDataPointView.TabIndex = 2;
            this.lbDataPointView.Text = "--";
            // 
            // btSetAspRules
            // 
            this.btSetAspRules.Location = new System.Drawing.Point(7, 52);
            this.btSetAspRules.Margin = new System.Windows.Forms.Padding(4);
            this.btSetAspRules.Name = "btSetAspRules";
            this.btSetAspRules.Size = new System.Drawing.Size(128, 28);
            this.btSetAspRules.TabIndex = 1;
            this.btSetAspRules.Text = "Set Asp. Rules";
            this.btSetAspRules.UseVisualStyleBackColor = true;
            this.btSetAspRules.Click += new System.EventHandler(this.btSetAspRules_Click);
            // 
            // lbAsprezzaDataHeading
            // 
            this.lbAsprezzaDataHeading.AutoSize = true;
            this.lbAsprezzaDataHeading.Location = new System.Drawing.Point(156, 22);
            this.lbAsprezzaDataHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAsprezzaDataHeading.Name = "lbAsprezzaDataHeading";
            this.lbAsprezzaDataHeading.Size = new System.Drawing.Size(105, 17);
            this.lbAsprezzaDataHeading.TabIndex = 0;
            this.lbAsprezzaDataHeading.Text = "Asprezza Data:";
            // 
            // gbTextSelect
            // 
            this.gbTextSelect.Controls.Add(this.btUncheckAll);
            this.gbTextSelect.Controls.Add(this.clbTextSelection);
            this.gbTextSelect.Controls.Add(this.btSelectFile);
            this.gbTextSelect.Controls.Add(this.btCheckAll);
            this.gbTextSelect.Location = new System.Drawing.Point(12, 15);
            this.gbTextSelect.Margin = new System.Windows.Forms.Padding(4);
            this.gbTextSelect.Name = "gbTextSelect";
            this.gbTextSelect.Padding = new System.Windows.Forms.Padding(4);
            this.gbTextSelect.Size = new System.Drawing.Size(430, 164);
            this.gbTextSelect.TabIndex = 14;
            this.gbTextSelect.TabStop = false;
            this.gbTextSelect.Text = "Text Selection";
            // 
            // btUncheckAll
            // 
            this.btUncheckAll.Location = new System.Drawing.Point(324, 84);
            this.btUncheckAll.Margin = new System.Windows.Forms.Padding(4);
            this.btUncheckAll.Name = "btUncheckAll";
            this.btUncheckAll.Size = new System.Drawing.Size(100, 28);
            this.btUncheckAll.TabIndex = 11;
            this.btUncheckAll.Text = "Uncheck All";
            this.btUncheckAll.UseVisualStyleBackColor = true;
            this.btUncheckAll.Click += new System.EventHandler(this.btUncheckAll_Click);
            // 
            // sfdExportImage
            // 
            this.sfdExportImage.Filter = "PNG image|*.png";
            this.sfdExportImage.Title = "Export asprezza analysis data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 602);
            this.Controls.Add(this.gbTextSelect);
            this.Controls.Add(this.gbAnalysis);
            this.Controls.Add(this.formsPlotAsprezzaPlot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Asprezza Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.gbAnalysis.ResumeLayout(false);
            this.gbAnalysis.PerformLayout();
            this.gbTextSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPlotAsprezza;
        private System.Windows.Forms.CheckedListBox clbTextSelection;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.OpenFileDialog ofdSelectTextFile;
        private System.Windows.Forms.Button btCheckAll;
        private System.Windows.Forms.Button btExportPng;
        private ScottPlot.FormsPlot formsPlotAsprezzaPlot;
        private System.Windows.Forms.GroupBox gbAnalysis;
        private System.Windows.Forms.Label lbDataPointView;
        private System.Windows.Forms.Button btSetAspRules;
        private System.Windows.Forms.Label lbAsprezzaDataHeading;
        private System.Windows.Forms.GroupBox gbTextSelect;
        private System.Windows.Forms.SaveFileDialog sfdExportImage;
        private System.Windows.Forms.Button btUncheckAll;
        private System.Windows.Forms.Button btExportCsv;
        private System.Windows.Forms.Button btExportXml;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

