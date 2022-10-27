namespace NutriScience_truckscale.view
{
    partial class Truckscale_tab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Truckscale_tab));
            this.tspanelMain = new Bunifu.UI.WinForms.BunifuPanel();
            this.dropDown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.SuspendLayout();
            // 
            // tspanelMain
            // 
            this.tspanelMain.BackgroundColor = System.Drawing.Color.Transparent;
            this.tspanelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspanelMain.BackgroundImage")));
            this.tspanelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tspanelMain.BorderColor = System.Drawing.Color.Transparent;
            this.tspanelMain.BorderRadius = 3;
            this.tspanelMain.BorderThickness = 1;
            this.tspanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tspanelMain.Location = new System.Drawing.Point(0, 0);
            this.tspanelMain.Name = "tspanelMain";
            this.tspanelMain.ShowBorders = true;
            this.tspanelMain.Size = new System.Drawing.Size(1014, 611);
            this.tspanelMain.TabIndex = 1;
            this.tspanelMain.Click += new System.EventHandler(this.tspanelMain_Click);
            // 
            // dropDown
            // 
            this.dropDown.BackColor = System.Drawing.Color.Transparent;
            this.dropDown.BackgroundColor = System.Drawing.Color.White;
            this.dropDown.BorderColor = System.Drawing.Color.Silver;
            this.dropDown.BorderRadius = 1;
            this.dropDown.Color = System.Drawing.Color.Silver;
            this.dropDown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropDown.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropDown.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dropDown.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropDown.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dropDown.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropDown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropDown.FillDropDown = true;
            this.dropDown.FillIndicator = false;
            this.dropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dropDown.ForeColor = System.Drawing.Color.Black;
            this.dropDown.FormattingEnabled = true;
            this.dropDown.Icon = null;
            this.dropDown.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropDown.IndicatorColor = System.Drawing.Color.DarkGray;
            this.dropDown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropDown.IndicatorThickness = 2;
            this.dropDown.IsDropdownOpened = false;
            this.dropDown.ItemBackColor = System.Drawing.Color.White;
            this.dropDown.ItemBorderColor = System.Drawing.Color.White;
            this.dropDown.ItemForeColor = System.Drawing.Color.Black;
            this.dropDown.ItemHeight = 26;
            this.dropDown.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dropDown.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dropDown.ItemTopMargin = 3;
            this.dropDown.Location = new System.Drawing.Point(37, 66);
            this.dropDown.Name = "dropDown";
            this.dropDown.Size = new System.Drawing.Size(142, 32);
            this.dropDown.TabIndex = 0;
            this.dropDown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropDown.TextLeftMargin = 5;
            // 
            // Truckscale_tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dropDown);
            this.Name = "Truckscale_tab";
            this.Size = new System.Drawing.Size(515, 321);
            this.Load += new System.EventHandler(this.Truckscale_tab_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuPanel tspanelMain;
        private Bunifu.UI.WinForms.BunifuDropdown dropDown;
    }
}
