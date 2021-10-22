
namespace VaR_D0zbsj
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
            this.dGTick = new System.Windows.Forms.DataGridView();
            this.dGPortfolio = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGPortfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // dGTick
            // 
            this.dGTick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGTick.Location = new System.Drawing.Point(101, 165);
            this.dGTick.Name = "dGTick";
            this.dGTick.RowHeadersWidth = 62;
            this.dGTick.RowTemplate.Height = 28;
            this.dGTick.Size = new System.Drawing.Size(566, 391);
            this.dGTick.TabIndex = 0;
            // 
            // dGPortfolio
            // 
            this.dGPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGPortfolio.Location = new System.Drawing.Point(839, 165);
            this.dGPortfolio.Name = "dGPortfolio";
            this.dGPortfolio.RowHeadersWidth = 62;
            this.dGPortfolio.RowTemplate.Height = 28;
            this.dGPortfolio.Size = new System.Drawing.Size(566, 391);
            this.dGPortfolio.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(101, 624);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(237, 74);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 809);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dGPortfolio);
            this.Controls.Add(this.dGTick);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dGTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGPortfolio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGTick;
        private System.Windows.Forms.DataGridView dGPortfolio;
        private System.Windows.Forms.Button btnSave;
    }
}

