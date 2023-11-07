using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ScottPlot.Plottable;
using System.Text.RegularExpressions;

namespace AsprezzaAnalyzer
{
    public partial class MainForm : Form
    {
        #region Private attributes

        /// <summary>
        /// List of text units found in selected text file
        /// </summary>
        private List<TextUnit> unitList = new List<TextUnit>();

        /// <summary>
        /// List to store all text identifiers found in text file selected
        /// </summary>
        List<string> dataTextIdentifier = new List<string>();

        /// <summary>
        /// Plot to display graph of asprezza analysis
        /// </summary>
        private SignalPlot asprezzaPlot;

        /// <summary>
        /// Marker to highlight data point data is to be shown for
        /// </summary>
        private ScottPlot.Plottable.MarkerPlot HighlightedPoint;

        /// <summary>
        /// Last index highlighted with MighlightedPoint
        /// </summary>
        private int LastHighlightedIndex = -1;

        /// <summary>
        /// Results of asprezza calculation
        /// </summary>
        private AsprezzaResultSet asprezzaResults = new AsprezzaResultSet();

        /// <summary>
        /// File parser to read files to be analyzed
        /// </summary>
        private IFileParser fileParser;

        #endregion

        #region Constructor

        /// <summary>
        /// Construct MainForm to be displayed to user using scottplot: https://scottplot.net/
        /// </summary>
        public MainForm()
        {
            //Set file parser to TEI XML parser (could be changed in future scenarios)
            this.fileParser = new TeiXmlParser();

            InitializeComponent();

            //Organize Icons using https://github.com/awesome-inc/FontAwesome.Sharp and https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.gethicon?view=windowsdesktop-7.0
            System.Drawing.Bitmap bitm = FontAwesome.Sharp.FormsIconHelper.ToBitmap(FontAwesome.Sharp.IconChar.WaveSquare, FontAwesome.Sharp.IconFont.Solid, 48, Color.Red);
            this.Icon = System.Drawing.Icon.FromHandle(bitm.GetHicon());

            //Calculate minimum sizes to make sure that there are no inconvenient layout effects
            this.gbTextSelect.MinimumSize = new Size(this.clbTextSelection.Width + btSelectFile.Width + 20, this.clbTextSelection.Height + 20);
            this.gbAnalysis.MinimumSize = this.gbTextSelect.MinimumSize;
            this.formsPlotAsprezzaPlot.MinimumSize = new Size(this.gbTextSelect.MinimumSize.Width + this.gbAnalysis.MinimumSize.Width + 20, this.gbTextSelect.MinimumSize.Height * 2);
            this.MinimumSize = new Size(this.gbTextSelect.MinimumSize.Width + this.gbAnalysis.MinimumSize.Width + 100, this.gbTextSelect.MinimumSize.Height + this.formsPlotAsprezzaPlot.MinimumSize.Height + 50);

            //Add a red circle we can move around later as a highlighted point indicator
            HighlightedPoint = this.formsPlotAsprezzaPlot.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = Color.Red;
            HighlightedPoint.MarkerSize = 15;
            HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.filledCircle;
            HighlightedPoint.IsVisible = false;

            //Define style of plot
            this.formsPlotAsprezzaPlot.Plot.Style(ScottPlot.Style.Light1);
            this.formsPlotAsprezzaPlot.Plot.XAxis.TickLabelStyle(Color.Black, null, 12, true, null);
            this.formsPlotAsprezzaPlot.Plot.YAxis.TickLabelStyle(Color.Black, null, 12, true, null);
            this.formsPlotAsprezzaPlot.Plot.SetAxisLimitsY(0, 10);
            this.formsPlotAsprezzaPlot.Plot.SetAxisLimitsX(0, 1000);
            this.formsPlotAsprezzaPlot.Plot.Palette = ScottPlot.Palette.PolarNight;
            this.formsPlotAsprezzaPlot.Render();
        }

        #endregion

        #region Main Logic

        /// <summary>
        /// Main fucntion of application: Handle all actions to plot results of asprezza calculation
        /// </summary>
        public void handlePlotCall()
        {
            //Get all texts selected in listbox to be analyzed
            List<string> textIdentifiers = new List<string>();

            foreach(var item in this.clbTextSelection.CheckedItems)
            {
                textIdentifiers.Add(item.ToString());
            }

            string analysisIdentifier = String.Join("; ", textIdentifiers);

            AsprezzaCalculator calc = new AsprezzaCalculator();
            this.asprezzaResults = calc.CalulateAsprezza(textIdentifiers, this.unitList);

            //Plot results
            this.asprezzaPlot = ScottPlotService.PlotData(this.formsPlotAsprezzaPlot, this.asprezzaPlot, this.asprezzaResults.dataAsprezza.ToArray(), this.asprezzaResults.dataLables.ToArray(), String.Join("; ", textIdentifiers));
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Button Click to analyze text data and to plot results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPlotAsprezza_Click(object sender, EventArgs e)
        {

            this.handlePlotCall();
        }

        /// <summary>
        /// Handle Resize of form so that plotting area always fills window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            formsPlotAsprezzaPlot.Width = this.Width - 50;
            formsPlotAsprezzaPlot.Height = this.Height / 2;

            this.gbTextSelect.Height = this.Height / 2 - 100;
            this.gbAnalysis.Height = this.Height / 2 - 100;
            this.gbTextSelect.Width = this.Width / 2 - 50;
            this.gbAnalysis.Width = this.Width / 2 - 50;

            this.gbAnalysis.Location = new Point(this.gbTextSelect.Width + 30, this.gbTextSelect.Location.Y);
            this.formsPlotAsprezzaPlot.Location = new Point(this.formsPlotAsprezzaPlot.Location.X, this.Height / 2 - 70);
        }

        /// <summary>
        /// Button click to read text file in TEI XML format to list textual units that can be analyzed independently
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (ofdSelectTextFile.ShowDialog() == DialogResult.OK)
            {
                //Read data from file
                this.unitList = this.fileParser.ReadText(ofdSelectTextFile.FileName);

                //Clear listbox and then list new textual units from file
                this.clbTextSelection.Items.Clear();
                foreach (TextUnit tu in unitList)
                {
                    this.clbTextSelection.Items.Add(tu.Identifier);
                }
            }
        }

        /// <summary>
        /// Handle click on button to check all texts in checked list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCheckAll_Click(object sender, EventArgs e)
        {
            if (this.clbTextSelection.Items != null)
            {
                for (int i = 0; i < clbTextSelection.Items.Count; i++)
                {
                    clbTextSelection.SetItemChecked(i, true);
                }
            }
        }


        /// <summary>
        /// Handle mouse click on plot using these hints: https://scottplot.net/faq/mouse-position/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formsPlotAsprezzaPlot_MouseClicked(object sender, MouseEventArgs e)
        {
            if (this.asprezzaPlot != null)
            {
                // determine point nearest the cursor
                (double mouseCoordX, double mouseCoordY) = this.formsPlotAsprezzaPlot.GetMouseCoordinates();
                (double pointX, double pointY, int pointIndex) = this.asprezzaPlot.GetPointNearestX(mouseCoordX);

                // place the highlight over the point of interest
                HighlightedPoint.X = pointX;
                HighlightedPoint.Y = pointY;
                HighlightedPoint.IsVisible = true;

                // render if the highlighted point chnaged
                if (LastHighlightedIndex != pointIndex)
                {
                    LastHighlightedIndex = pointIndex;
                    formsPlotAsprezzaPlot.Render();
                }

                // update the GUI to describe the highlighted point                
                this.lbDataPointView.Text = $"{this.asprezzaResults.dataLables[pointIndex].Split('-')[1]}\r\nasprezza: {this.asprezzaResults.dataAsprezza[pointIndex]}";
            }
        }

        /// <summary>
        /// Detect arrow keys in scott plot using these hints: https://stackoverflow.com/questions/37792707/handling-arrow-keys-in-a-form and https://scottplot.net/faq/mouse-position/
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.asprezzaPlot != null)
            {
                if (keyData == Keys.Left || keyData == Keys.Right)
                {
                    double pointX = 0.0;
                    double pointY = 0.0;
                    int pointIndex = 0;

                    switch (keyData)
                    {
                        case Keys.Right:
                            this.HighlightedPoint.X++;
                            (pointX, pointY, pointIndex) = this.asprezzaPlot.GetPointNearestX(this.HighlightedPoint.X);
                            if ((int)HighlightedPoint.X < this.asprezzaResults.dataAsprezza.Count)
                                this.HighlightedPoint.Y = this.asprezzaResults.dataAsprezza[(int)this.HighlightedPoint.X];
                            break;
                        case Keys.Left:
                            this.HighlightedPoint.X--;
                            (pointX, pointY, pointIndex) = this.asprezzaPlot.GetPointNearestX(this.HighlightedPoint.X);
                            if ((int)HighlightedPoint.X <= this.asprezzaResults.dataAsprezza.Count && (int)HighlightedPoint.X > 0)
                                this.HighlightedPoint.Y = this.asprezzaResults.dataAsprezza[(int)this.HighlightedPoint.X];
                            break;
                    }
                    // render if the highlighted point changed
                    if (LastHighlightedIndex != pointIndex)
                    {
                        LastHighlightedIndex = pointIndex;
                        formsPlotAsprezzaPlot.Render();
                        this.lbDataPointView.Text = $"{this.asprezzaResults.dataLables[pointIndex].Split('-')[1]}\r\nasprezza: {this.asprezzaResults.dataAsprezza[pointIndex]}";
                    }
                    return true;
                }
            }
        
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// React to click on button to edit asprezza rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSetAspRules_Click(object sender, EventArgs e)
        {
            AsprezzaRuleForm dialog = new AsprezzaRuleForm(this);
            dialog.ShowDialog();
        }

        /// <summary>
        /// React to closing of Asprezza Analyzer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }        

        /// <summary>
        /// React to click on button to uncheck all texts in checked list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUncheckAll_Click(object sender, EventArgs e)
        {
            if (this.clbTextSelection.Items != null)
            {
                for (int i = 0; i < clbTextSelection.Items.Count; i++)
                {
                    clbTextSelection.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// Handle click on button to create PNG export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExportPng_Click(object sender, EventArgs e)
        {
            this.sfdExportImage.Filter = "PNG Image|*.png";
            this.sfdExportImage.FileName = Regex.Replace(String.Join("_", this.clbTextSelection.CheckedItems.Cast<string>()).Trim(), "[^A-Za-z0-9_. ]+", "") + ".png";
            this.sfdExportImage.ShowDialog();
            if (this.sfdExportImage.FileName != "")
            {
                this.formsPlotAsprezzaPlot.Plot.SaveFig(this.sfdExportImage.FileName, 1920, 870, false, 2);
            }
        }

        /// <summary>
        /// React to click on button to export XML report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExportXml_Click(object sender, EventArgs e)
        {
            this.sfdExportImage.Filter = "XML File|*.xml";
            this.sfdExportImage.FileName = Regex.Replace(String.Join("_", this.clbTextSelection.CheckedItems.Cast<string>()).Trim(), "[^A-Za-z0-9_. ]+", "") + ".xml";
            this.sfdExportImage.ShowDialog();
            if (this.sfdExportImage.FileName != "")
            {
                AsprezzaExporter.ExportAsprezzaXML(this.asprezzaResults, this.sfdExportImage.FileName);
            }
        }

        /// <summary>
        /// React to click on button to export CSV report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExportCsv_Click(object sender, EventArgs e)
        {
            this.sfdExportImage.Filter = "CSV File|*.csv";
            this.sfdExportImage.FileName = Regex.Replace(String.Join("_", this.clbTextSelection.CheckedItems.Cast<string>()).Trim(), "[^A-Za-z0-9_. ]+", "") + ".csv";
            this.sfdExportImage.ShowDialog();
            if (this.sfdExportImage.FileName != "")
            {
                AsprezzaExporter.ExportAsprezzaCSV(this.asprezzaResults, this.sfdExportImage.FileName);
            }
        }        

        /// <summary>
        /// React to click on icon button to show legal notices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton1_Click(object sender, EventArgs e)
        {
            LegalNotices notices = new LegalNotices();
            notices.ShowDialog();
        }

        #endregion
    }
}
