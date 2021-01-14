
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
            this.gridYear.Location = new System.Drawing.Point(3, 3);
            this.gridYear.Name = "gridYear";
            this.gridYear.RowHeadersVisible = false;
            this.gridYear.Size = new System.Drawing.Size(479, 171);
            this.gridYear.TabIndex = 2;
            this.gridYear.TabStop = false;
            // 
            // UCYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridYear);
            this.Name = "UCYear";
            this.Size = new System.Drawing.Size(485, 177);
            ((System.ComponentModel.ISupportInitialize)(this.gridYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridYear;
    }
}
