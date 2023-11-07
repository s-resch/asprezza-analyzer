using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsprezzaAnalyzer
{
    public partial class AsprezzaRuleForm : Form
    {
        #region Properties and Fields

        /// <summary>
        /// Dictionary storing asprezza rules and their corresponding numeric value to "measure" asprezza
        /// </summary>
        private Dictionary<string, string> settings;

        /// <summary>
        /// Reference to calling window to pass asprezza rules to main application window
        /// </summary>
        private MainForm parentReference;

        #endregion

        #region Constructor

        public AsprezzaRuleForm(MainForm parent)
        {
            InitializeComponent();
            this.parentReference = parent;
            //this.Icon = Properties.Resources.configuration_edit;

            //Fill Grid with values
            this.FillGrid();

            this.numudMultiplicatorRhyme.Value = ConfigExtractor.ParseMultiplicatorRhyme();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Fill grid of settings with values using these hints:
        /// https://learn.microsoft.com/de-de/dotnet/api/system.windows.forms.datagridview?view=windowsdesktop-7.0
        /// </summary>
        private void FillGrid()
        {

                //Get the settings stored in Xml config file
                this.settings = ConfigExtractor.ParseAsprezzaRules();

                //Clear previous entries in grid
                if (this.dataGridView1.Rows.Count > 0)
                    this.dataGridView1.Rows.Clear();

                //We need a first default row (provided as soon as assing new rows is set to true)
                this.dataGridView1.AllowUserToAddRows = true;

            //this.dataGridView1.Rows = new DataGridViewRowCollection(dataGridView1);

            //Insert pairs of setting and its value into grid using following hints:
            // https://stackoverflow.com/questions/10063770/how-to-add-a-new-row-to-datagridview-programmatically
            foreach (KeyValuePair<string, string> set in settings)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = set.Key;
                    row.Cells[1].Value = set.Value;
                    dataGridView1.Rows.Add(row);
                }

                //Disable mode for adding new rows again, so user can't add any senseless settings which could cause trouble
                //this.dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Save settings when clicking on OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            //Get new settings set by user into our register
            this.settings = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                    settings.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            }

            //Write the new register to Xml config file
            ConfigExtractor.Write(this.settings, this.numudMultiplicatorRhyme.Value);

            this.parentReference.handlePlotCall();

            //Tell user that everything has been done
            MessageBox.Show("All changes applied to configuration file", "Changes applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// //Don't do anything, just get values again from Xml config file (old values) when clicking on Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.FillGrid();
        }


        /// <summary>
        /// //Save settings but don't close window when clicking on Apply button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btApply_Click(object sender, EventArgs e)
        {
            this.settings = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                settings.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            }

            ConfigExtractor.Write(this.settings, this.numudMultiplicatorRhyme.Value);
        }

        /// <summary>
        /// Handle closing of current window managing asprezza rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentReference.handlePlotCall();
        }        

        /// <summary>
        /// Handle click on Export Rules Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExportRules_Click(object sender, EventArgs e)
        {
            this.sfdExportRules.Filter = "XML File|*.xml";
            //Make sure we have a unique file name as default value
            this.sfdExportRules.FileName = "asprezzaRules" + DateTime.Now.ToString("yyyyMMddHHmmss");
            this.sfdExportRules.ShowDialog();
            if (this.sfdExportRules.FileName != "")
            {
                AsprezzaRuleImportExport.ExportToXml(this.sfdExportRules.FileName);
            }
        }

        /// <summary>
        /// Handle click on Import Rules button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btImportRules_Click(object sender, EventArgs e)
        {
            if (this.ofdImportRules.ShowDialog() == DialogResult.OK)
            {
                //Read data from file
                AsprezzaRuleImportExport.ImportFromXml(this.ofdImportRules.FileName);

                //Apply imported values to GUI
                this.FillGrid();
                this.numudMultiplicatorRhyme.Value = ConfigExtractor.ParseMultiplicatorRhyme();
            }
        }

        #endregion
    }

}
