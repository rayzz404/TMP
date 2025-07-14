namespace TMP
{
    partial class Languages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Languages));
            EN = new Button();
            RU = new Button();
            SuspendLayout();
            // 
            // EN
            // 
            EN.FlatStyle = FlatStyle.Popup;
            EN.Location = new Point(12, 12);
            EN.Name = "EN";
            EN.Size = new Size(150, 100);
            EN.TabIndex = 0;
            EN.Text = "EN";
            EN.UseVisualStyleBackColor = true;
            // 
            // RU
            // 
            RU.FlatStyle = FlatStyle.Popup;
            RU.Location = new Point(184, 12);
            RU.Name = "RU";
            RU.Size = new Size(150, 100);
            RU.TabIndex = 1;
            RU.Text = "RU";
            RU.UseVisualStyleBackColor = true;
            // 
            // Languages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 134);
            Controls.Add(RU);
            Controls.Add(EN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Languages";
            ShowIcon = false;
            Text = "Languages";
            ResumeLayout(false);
        }

        #endregion

        public Button EN;
        public Button RU;
    }
}