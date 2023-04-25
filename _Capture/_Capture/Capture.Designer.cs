
namespace _Capture
{
    partial class Capture
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sETUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_Com = new System.Windows.Forms.ToolStripComboBox();
            this.check_DataReceived = new System.Windows.Forms.CheckBox();
            this.check_snap = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(0, 30);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(853, 600);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oKToolStripMenuItem,
            this.eXITToolStripMenuItem,
            this.sETUPToolStripMenuItem,
            this.iMAGEToolStripMenuItem,
            this.toolStripComboBox_Com});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 31);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oKToolStripMenuItem
            // 
            this.oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            this.oKToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
            this.oKToolStripMenuItem.Text = "OK";
            this.oKToolStripMenuItem.Click += new System.EventHandler(this.oKToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(53, 27);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // iMAGEToolStripMenuItem
            // 
            this.iMAGEToolStripMenuItem.Name = "iMAGEToolStripMenuItem";
            this.iMAGEToolStripMenuItem.Size = new System.Drawing.Size(70, 27);
            this.iMAGEToolStripMenuItem.Text = "IMAGE";
            // 
            // sETUPToolStripMenuItem
            // 
            this.sETUPToolStripMenuItem.Name = "sETUPToolStripMenuItem";
            this.sETUPToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.sETUPToolStripMenuItem.Text = "SETUP";
            this.sETUPToolStripMenuItem.Click += new System.EventHandler(this.sETUPToolStripMenuItem_Click);
            // 
            // toolStripComboBox_Com
            // 
            this.toolStripComboBox_Com.Name = "toolStripComboBox_Com";
            this.toolStripComboBox_Com.Size = new System.Drawing.Size(121, 27);
            this.toolStripComboBox_Com.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Com_SelectedIndexChanged);
            // 
            // check_DataReceived
            // 
            this.check_DataReceived.AutoSize = true;
            this.check_DataReceived.Location = new System.Drawing.Point(393, 6);
            this.check_DataReceived.Name = "check_DataReceived";
            this.check_DataReceived.Size = new System.Drawing.Size(18, 17);
            this.check_DataReceived.TabIndex = 4;
            this.check_DataReceived.UseVisualStyleBackColor = true;
            // 
            // check_snap
            // 
            this.check_snap.AutoSize = true;
            this.check_snap.Location = new System.Drawing.Point(427, 6);
            this.check_snap.Name = "check_snap";
            this.check_snap.Size = new System.Drawing.Size(18, 17);
            this.check_snap.TabIndex = 5;
            this.check_snap.UseVisualStyleBackColor = true;
            // 
            // Capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 632);
            this.Controls.Add(this.check_snap);
            this.Controls.Add(this.check_DataReceived);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Capture";
            this.Text = "Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Capture_FormClosing);
            this.Load += new System.EventHandler(this.Capture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMAGEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sETUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Com;
        private System.Windows.Forms.CheckBox check_DataReceived;
        private System.Windows.Forms.CheckBox check_snap;
    }
}

