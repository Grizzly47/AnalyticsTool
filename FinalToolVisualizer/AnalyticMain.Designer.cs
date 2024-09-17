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
            importButton = new Button();
            mergeButton = new Button();
            exportButton = new Button();
            gameList_GridView = new DataGridView();
            removeGameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)gameList_GridView).BeginInit();
            SuspendLayout();
            // 
            // importButton
            // 
            importButton.Location = new Point(25, 15);
            importButton.Name = "importButton";
            importButton.Size = new Size(100, 25);
            importButton.TabIndex = 0;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += importButton_Click;
            // 
            // mergeButton
            // 
            mergeButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mergeButton.Location = new Point(175, 15);
            mergeButton.Name = "mergeButton";
            mergeButton.Size = new Size(116, 25);
            mergeButton.TabIndex = 1;
            mergeButton.Text = "Merge";
            mergeButton.UseVisualStyleBackColor = true;
            mergeButton.Click += mergeButton_Click;
            // 
            // exportButton
            // 
            exportButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            exportButton.Location = new Point(325, 15);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(116, 25);
            exportButton.TabIndex = 2;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // gameList_GridView
            // 
            gameList_GridView.AllowUserToAddRows = false;
            gameList_GridView.AllowUserToOrderColumns = true;
            gameList_GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gameList_GridView.Location = new Point(25, 50);
            gameList_GridView.MultiSelect = false;
            gameList_GridView.Name = "gameList_GridView";
            gameList_GridView.ReadOnly = true;
            gameList_GridView.RowTemplate.Height = 25;
            gameList_GridView.Size = new Size(416, 380);
            gameList_GridView.TabIndex = 5;
            gameList_GridView.CellContentClick += gameList_GridView_CellContentClick;
            gameList_GridView.MouseDoubleClick += gameList_GridView_MouseDoubleClick;
            // 
            // removeGameButton
            // 
            removeGameButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            removeGameButton.Location = new Point(25, 449);
            removeGameButton.Name = "removeGameButton";
            removeGameButton.Size = new Size(116, 25);
            removeGameButton.TabIndex = 7;
            removeGameButton.Text = "Remove Game";
            removeGameButton.UseVisualStyleBackColor = true;
            removeGameButton.Click += removeGameButton_Click;
            // 
            // AnalyticMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 486);
            Controls.Add(removeGameButton);
            Controls.Add(gameList_GridView);
            Controls.Add(exportButton);
            Controls.Add(mergeButton);
            Controls.Add(importButton);
            Margin = new Padding(2, 6, 2, 6);
            Name = "AnalyticMain";
            Text = "Analytic: Main";
            ((System.ComponentModel.ISupportInitialize)gameList_GridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button importButton;
        private Button mergeButton;
        private Button exportButton;
        private DataGridView gameList_GridView;
        private Button removeGameButton;
    }
}