namespace FinalToolVisualizer
{
    partial class AnalyticsGameDetails
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
            searchBar_TextBox = new TextBox();
            label2 = new Label();
            gameDetails_DataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gameDetails_DataGrid).BeginInit();
            SuspendLayout();
            // 
            // searchBar_TextBox
            // 
            searchBar_TextBox.Location = new Point(118, 18);
            searchBar_TextBox.Name = "searchBar_TextBox";
            searchBar_TextBox.Size = new Size(207, 23);
            searchBar_TextBox.TabIndex = 4;
            searchBar_TextBox.TextChanged += searchBar_TextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 21);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 5;
            label2.Text = "Filter By Name:";
            label2.Click += label2_Click;
            // 
            // gameDetails_DataGrid
            // 
            gameDetails_DataGrid.AllowUserToAddRows = false;
            gameDetails_DataGrid.AllowUserToOrderColumns = true;
            gameDetails_DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gameDetails_DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gameDetails_DataGrid.Location = new Point(25, 55);
            gameDetails_DataGrid.MultiSelect = false;
            gameDetails_DataGrid.Name = "gameDetails_DataGrid";
            gameDetails_DataGrid.ReadOnly = true;
            gameDetails_DataGrid.RowTemplate.Height = 25;
            gameDetails_DataGrid.Size = new Size(410, 407);
            gameDetails_DataGrid.TabIndex = 6;
            // 
            // AnalyticsGameDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 486);
            Controls.Add(gameDetails_DataGrid);
            Controls.Add(label2);
            Controls.Add(searchBar_TextBox);
            Name = "AnalyticsGameDetails";
            Text = "AnalyticsGameDetails";
            ((System.ComponentModel.ISupportInitialize)gameDetails_DataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox searchBar_TextBox;
        private Label label2;
        private DataGridView gameDetails_DataGrid;
    }
}