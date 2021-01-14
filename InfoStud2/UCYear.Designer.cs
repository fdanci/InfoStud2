
namespace InfoStud2
{
    partial class UCYear
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridYear = new System.Windows.Forms.DataGridView();
            this.lblYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridYear)).BeginInit();
            this.SuspendLayout();
            // 
            // gridYear
            // 
            this.gridYear.AllowUserToAddRows = false;
            this.gridYear.AllowUserToDeleteRows = false;
            this.gridYear.AllowUserToResizeColumns = false;
            this.gridYear.AllowUserToResizeRows = false;
            this.gridYear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridYear.Enabled = false;
            this.gridYear.Location = new System.Drawing.Point(3, 22);
            this.gridYear.Name = "gridYear";
            this.gridYear.RowHeadersVisible = false;
            this.gridYear.Size = new System.Drawing.Size(479, 132);
            this.gridYear.TabIndex = 2;
            this.gridYear.TabStop = false;
            this.gridYear.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridYear_DataBindingComplete);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(3, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year";
            // 
            // UCYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.gridYear);
            this.Name = "UCYear";
            this.Size = new System.Drawing.Size(485, 177);
            this.Load += new System.EventHandler(this.UCYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridYear;
        private System.Windows.Forms.Label lblYear;
    }
}
