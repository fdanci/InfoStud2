
namespace InfoStud2
{
    partial class UCAllYearsPanel
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitleAllYears = new System.Windows.Forms.Label();
            this.panelY3 = new System.Windows.Forms.Panel();
            this.panelY1 = new System.Windows.Forms.Panel();
            this.panelY2 = new System.Windows.Forms.Panel();
            this.panelY4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(909, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitleAllYears
            // 
            this.lblTitleAllYears.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleAllYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAllYears.Location = new System.Drawing.Point(0, 0);
            this.lblTitleAllYears.Name = "lblTitleAllYears";
            this.lblTitleAllYears.Size = new System.Drawing.Size(1013, 25);
            this.lblTitleAllYears.TabIndex = 19;
            this.lblTitleAllYears.Text = "Student Subjects All Years";
            this.lblTitleAllYears.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelY3
            // 
            this.panelY3.Location = new System.Drawing.Point(9, 328);
            this.panelY3.Name = "panelY3";
            this.panelY3.Size = new System.Drawing.Size(485, 179);
            this.panelY3.TabIndex = 21;
            // 
            // panelY1
            // 
            this.panelY1.Location = new System.Drawing.Point(9, 120);
            this.panelY1.Name = "panelY1";
            this.panelY1.Size = new System.Drawing.Size(485, 177);
            this.panelY1.TabIndex = 23;
            // 
            // panelY2
            // 
            this.panelY2.Location = new System.Drawing.Point(500, 120);
            this.panelY2.Name = "panelY2";
            this.panelY2.Size = new System.Drawing.Size(485, 177);
            this.panelY2.TabIndex = 24;
            // 
            // panelY4
            // 
            this.panelY4.Location = new System.Drawing.Point(500, 328);
            this.panelY4.Name = "panelY4";
            this.panelY4.Size = new System.Drawing.Size(485, 179);
            this.panelY4.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Year 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Year 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Year 4";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.AutoSize = true;
            this.btnEdit.Location = new System.Drawing.Point(828, 521);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // UCAllYearsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelY4);
            this.Controls.Add(this.panelY2);
            this.Controls.Add(this.panelY1);
            this.Controls.Add(this.panelY3);
            this.Controls.Add(this.lblTitleAllYears);
            this.Controls.Add(this.btnClose);
            this.Name = "UCAllYearsPanel";
            this.Size = new System.Drawing.Size(1013, 560);
            this.Load += new System.EventHandler(this.UCAllYearsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitleAllYears;
        private System.Windows.Forms.Panel panelY3;
        private System.Windows.Forms.Panel panelY1;
        private System.Windows.Forms.Panel panelY2;
        private System.Windows.Forms.Panel panelY4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
    }
}
