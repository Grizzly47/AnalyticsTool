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
            this.searchBar_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameDetails_DataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gameDetails_DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBar_TextBox
            // 
            this.searchBar_TextBox.Location = new System.Drawing.Point(118, 18);
            this.searchBar_TextBox.Name = "searchBar_TextBox";
            this.searchBar_TextBox.Size = new System.Drawing.Size(207, 23);
            this.searchBar_TextBox.TabIndex = 4;
            this.searchBar_TextBox.TextChanged += new System.EventHandler(this.searchBar_TextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By Name:";
            // 
            // gameDetails_DataGrid
            // 
            this.gameDetails_DataGrid.AllowUserToAddRows = false;
            this.gameDetails_DataGrid.AllowUserToOrderColumns = true;
            this.gameDetails_DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gameDetails_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameDetails_DataGrid.Location = new System.Drawing.Point(25, 55);
            this.gameDetails_DataGrid.MultiSelect = false;
            this.gameDetails_DataGrid.Name = "gameDetails_DataGrid";
            this.gameDetails_DataGrid.ReadOnly = true;
            this.gameDetails_DataGrid.RowTemplate.Height = 25;
            this.gameDetails_DataGrid.Size = new System.Drawing.Size(410, 407);
            this.gameDetails_DataGrid.TabIndex = 6;
            this.gameDetails_DataGrid.DoubleClick += new System.EventHandler(this.gameList_GridView_MouseDoubleClick);
            // 
            // AnalyticsGameDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 486);
            this.Controls.Add(this.gameDetails_DataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchBar_TextBox);
            this.Name = "AnalyticsGameDetails";
            this.Text = "AnalyticsGameDetails";
            ((System.ComponentModel.ISupportInitialize)(this.gameDetails_DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox searchBar_TextBox;
        private Label label2;
        private DataGridView gameDetails_DataGrid;
    }
}