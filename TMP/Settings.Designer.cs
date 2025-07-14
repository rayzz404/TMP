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
            language = new Button();
            SuspendLayout();
            // 
            // size
            // 
            size.FlatStyle = FlatStyle.Popup;
            size.Location = new Point(12, 12);
            size.Name = "size";
            size.Size = new Size(200, 54);
            size.TabIndex = 0;
            size.Text = "Size";
            size.UseVisualStyleBackColor = true;
            // 
            // colors
            // 
            colors.FlatStyle = FlatStyle.Popup;
            colors.Location = new Point(12, 72);
            colors.Name = "colors";
            colors.Size = new Size(200, 54);
            colors.TabIndex = 1;
            colors.Text = "Colors";
            colors.UseVisualStyleBackColor = true;
            // 
            // language
            // 
            language.FlatStyle = FlatStyle.Popup;
            language.Location = new Point(12, 132);
            language.Name = "language";
            language.Size = new Size(200, 57);
            language.TabIndex = 2;
            language.Text = "Language";
            language.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 201);
            Controls.Add(language);
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
        public Button language;
    }
}