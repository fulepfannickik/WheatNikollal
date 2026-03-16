namespace Wheat
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
            this.WheatDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megnyitásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.körToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.WheatDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WheatDataGrid
            // 
            this.WheatDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WheatDataGrid.Location = new System.Drawing.Point(28, 44);
            this.WheatDataGrid.Name = "WheatDataGrid";
            this.WheatDataGrid.Size = new System.Drawing.Size(711, 384);
            this.WheatDataGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adatokToolStripMenuItem,
            this.diagraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adatokToolStripMenuItem
            // 
            this.adatokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.megnyitásToolStripMenuItem});
            this.adatokToolStripMenuItem.Name = "adatokToolStripMenuItem";
            this.adatokToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.adatokToolStripMenuItem.Text = "Adatok";
            // 
            // megnyitásToolStripMenuItem
            // 
            this.megnyitásToolStripMenuItem.Name = "megnyitásToolStripMenuItem";
            this.megnyitásToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.megnyitásToolStripMenuItem.Text = "Megnyitás";
            this.megnyitásToolStripMenuItem.Click += new System.EventHandler(this.megnyitásToolStripMenuItem_Click);
            // 
            // diagraToolStripMenuItem
            // 
            this.diagraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.körToolStripMenuItem,
            this.toolStripMenuItem1});
            this.diagraToolStripMenuItem.Name = "diagraToolStripMenuItem";
            this.diagraToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.diagraToolStripMenuItem.Text = "Diagramok";
            // 
            // körToolStripMenuItem
            // 
            this.körToolStripMenuItem.Name = "körToolStripMenuItem";
            this.körToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.körToolStripMenuItem.Text = "Kör (országok)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WheatDataGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.WheatDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView WheatDataGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megnyitásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem körToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

