namespace TMP
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            size = new Button();
            colors = new Button();
            SuspendLayout();
            // 
            // size
            // 
            size.Location = new Point(12, 12);
            size.Name = "size";
            size.Size = new Size(200, 81);
            size.TabIndex = 0;
            size.Text = "Size";
            size.UseVisualStyleBackColor = true;
            // 
            // colors
            // 
            colors.Location = new Point(12, 99);
            colors.Name = "colors";
            colors.Size = new Size(200, 100);
            colors.TabIndex = 1;
            colors.Text = "Colors";
            colors.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 211);
            Controls.Add(colors);
            Controls.Add(size);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
        }

        #endregion

        public Button size;
        public Button colors;
    }
}