
namespace AsprezzaAnalyzer
{
    partial class AsprezzaRuleForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColSettingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettingValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.ofdImportRules = new System.Windows.Forms.OpenFileDialog();
            this.lbMultiplicatorRhyme = new System.Windows.Forms.Label();
            this.numudMultiplicatorRhyme = new System.Windows.Forms.NumericUpDown();
            this.btExportRules = new System.Windows.Forms.Button();
            this.btImportRules = new System.Windows.Forms.Button();
            this.sfdExportRules = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudMultiplicatorRhyme)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSettingName,
            this.ColSettingValue});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(13, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(512, 215);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColSettingName
            // 
            this.ColSettingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSettingName.HeaderText = "Asprezza Indicator";
            this.ColSettingName.MinimumWidth = 6;
            this.ColSettingName.Name = "ColSettingName";
            // 
            // ColSettingValue
            // 
            this.ColSettingValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSettingValue.HeaderText = "Asprezza Value";
            this.ColSettingValue.MinimumWidth = 6;
            this.ColSettingValue.Name = "ColSettingValue";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(13, 347);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 28);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(121, 347);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ofdImportRules
            // 
            this.ofdImportRules.Filter = "XML File|*.xml";
            // 
            // lbMultiplicatorRhyme
            // 
            this.lbMultiplicatorRhyme.AutoSize = true;
            this.lbMultiplicatorRhyme.Location = new System.Drawing.Point(13, 271);
            this.lbMultiplicatorRhyme.Name = "lbMultiplicatorRhyme";
            this.lbMultiplicatorRhyme.Size = new System.Drawing.Size(204, 17);
            this.lbMultiplicatorRhyme.TabIndex = 3;
            this.lbMultiplicatorRhyme.Text = "Multiplicator for rhyme position:";
            // 
            // numudMultiplicatorRhyme
            // 
            this.numudMultiplicatorRhyme.DecimalPlaces = 2;
            this.numudMultiplicatorRhyme.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numudMultiplicatorRhyme.Location = new System.Drawing.Point(223, 269);
            this.numudMultiplicatorRhyme.Name = "numudMultiplicatorRhyme";
            this.numudMultiplicatorRhyme.Size = new System.Drawing.Size(94, 22);
            this.numudMultiplicatorRhyme.TabIndex = 4;
            this.numudMultiplicatorRhyme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btExportRules
            // 
            this.btExportRules.Location = new System.Drawing.Point(377, 313);
            this.btExportRules.Name = "btExportRules";
            this.btExportRules.Size = new System.Drawing.Size(114, 28);
            this.btExportRules.TabIndex = 5;
            this.btExportRules.Text = "Export Rules";
            this.btExportRules.UseVisualStyleBackColor = true;
            this.btExportRules.Click += new System.EventHandler(this.btExportRules_Click);
            // 
            // btImportRules
            // 
            this.btImportRules.Location = new System.Drawing.Point(377, 347);
            this.btImportRules.Name = "btImportRules";
            this.btImportRules.Size = new System.Drawing.Size(114, 28);
            this.btImportRules.TabIndex = 6;
            this.btImportRules.Text = "Import Rules";
            this.btImportRules.UseVisualStyleBackColor = true;
            this.btImportRules.Click += new System.EventHandler(this.btImportRules_Click);
            // 
            // AsprezzaRuleForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 411);
            this.Controls.Add(this.btImportRules);
            this.Controls.Add(this.btExportRules);
            this.Controls.Add(this.numudMultiplicatorRhyme);
            this.Controls.Add(this.lbMultiplicatorRhyme);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AsprezzaRuleForm";
            this.ShowIcon = false;
            this.Text = "AppConfigurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudMultiplicatorRhyme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.OpenFileDialog ofdImportRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettingValue;
        private System.Windows.Forms.Label lbMultiplicatorRhyme;
        private System.Windows.Forms.NumericUpDown numudMultiplicatorRhyme;
        private System.Windows.Forms.Button btExportRules;
        private System.Windows.Forms.Button btImportRules;
        private System.Windows.Forms.SaveFileDialog sfdExportRules;
    }

}