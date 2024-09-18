namespace FinalToolVisualizer
{
    partial class AnalyticMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.importButton = new System.Windows.Forms.Button();
            this.mergeButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.gameList_GridView = new System.Windows.Forms.DataGridView();
            this.removeGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameList_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(25, 15);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 25);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // mergeButton
            // 
            this.mergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeButton.Location = new System.Drawing.Point(175, 15);
            this.mergeButton.Name = "mergeButton";
            this.mergeButton.Size = new System.Drawing.Size(116, 25);
            this.mergeButton.TabIndex = 1;
            this.mergeButton.Text = "Merge";
            this.mergeButton.UseVisualStyleBackColor = true;
            this.mergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(325, 15);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(116, 25);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // gameList_GridView
            // 
            this.gameList_GridView.AllowUserToAddRows = false;
            this.gameList_GridView.AllowUserToOrderColumns = true;
            this.gameList_GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gameList_GridView.Location = new System.Drawing.Point(25, 50);
            this.gameList_GridView.MultiSelect = false;
            this.gameList_GridView.Name = "gameList_GridView";
            this.gameList_GridView.ReadOnly = true;
            this.gameList_GridView.RowTemplate.Height = 25;
            this.gameList_GridView.Size = new System.Drawing.Size(416, 380);
            this.gameList_GridView.TabIndex = 5;
            this.gameList_GridView.DoubleClick += new System.EventHandler(this.GameList_GridView_MouseDoubleClick);
            // 
            // removeGameButton
            // 
            this.removeGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeGameButton.Location = new System.Drawing.Point(25, 449);
            this.removeGameButton.Name = "removeGameButton";
            this.removeGameButton.Size = new System.Drawing.Size(116, 25);
            this.removeGameButton.TabIndex = 7;
            this.removeGameButton.Text = "Remove Game";
            this.removeGameButton.UseVisualStyleBackColor = true;
            // 
            // AnalyticMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 486);
            this.Controls.Add(this.removeGameButton);
            this.Controls.Add(this.gameList_GridView);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.mergeButton);
            this.Controls.Add(this.importButton);
            this.Margin = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.Name = "AnalyticMain";
            this.Text = "Analytic: Main";
            ((System.ComponentModel.ISupportInitialize)(this.gameList_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button importButton;
        private Button mergeButton;
        private Button exportButton;
        private DataGridView gameList_GridView;
        private Button removeGameButton;
    }
}