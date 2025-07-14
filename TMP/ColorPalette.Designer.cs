namespace TMP
{
    partial class ColorPalette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPalette));
            red = new Button();
            yellow = new Button();
            green = new Button();
            white = new Button();
            pink = new Button();
            blue = new Button();
            SuspendLayout();
            // 
            // red
            // 
            red.BackColor = Color.IndianRed;
            red.ForeColor = Color.IndianRed;
            red.Location = new Point(12, 21);
            red.Name = "red";
            red.Size = new Size(100, 100);
            red.TabIndex = 0;
            red.TabStop = false;
            red.UseVisualStyleBackColor = false;
            // 
            // yellow
            // 
            yellow.BackColor = Color.LightYellow;
            yellow.Location = new Point(118, 21);
            yellow.Name = "yellow";
            yellow.Size = new Size(100, 100);
            yellow.TabIndex = 1;
            yellow.TabStop = false;
            yellow.UseVisualStyleBackColor = false;
            // 
            // green
            // 
            green.BackColor = Color.LightGreen;
            green.Location = new Point(224, 21);
            green.Name = "green";
            green.Size = new Size(100, 100);
            green.TabIndex = 2;
            green.TabStop = false;
            green.UseVisualStyleBackColor = false;
            // 
            // white
            // 
            white.BackColor = Color.White;
            white.Location = new Point(224, 127);
            white.Name = "white";
            white.Size = new Size(100, 100);
            white.TabIndex = 3;
            white.TabStop = false;
            white.UseVisualStyleBackColor = false;
            // 
            // pink
            // 
            pink.BackColor = Color.LightPink;
            pink.Location = new Point(118, 127);
            pink.Name = "pink";
            pink.Size = new Size(100, 100);
            pink.TabIndex = 4;
            pink.TabStop = false;
            pink.UseVisualStyleBackColor = false;
            // 
            // blue
            // 
            blue.BackColor = Color.LightBlue;
            blue.Location = new Point(12, 127);
            blue.Name = "blue";
            blue.Size = new Size(100, 100);
            blue.TabIndex = 5;
            blue.TabStop = false;
            blue.UseVisualStyleBackColor = false;
            // 
            // ColorPalette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 241);
            Controls.Add(blue);
            Controls.Add(pink);
            Controls.Add(white);
            Controls.Add(green);
            Controls.Add(yellow);
            Controls.Add(red);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ColorPalette";
            Text = "Color Palette";
            ResumeLayout(false);
        }

        #endregion

        public Button red;
        public Button yellow;
        public Button green;
        public Button white;
        public Button pink;
        public Button blue;
    }
}