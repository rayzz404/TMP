namespace TMP
{
    partial class TMP
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMP));
            loadButton = new Button();
            playButton = new Button();
            pauseButton = new Button();
            Volume = new TrackBar();
            time = new TrackBar();
            current_time = new Label();
            slash = new Label();
            duration = new Label();
            pictureBox1 = new PictureBox();
            title = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            clearToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            switchModeToolStripMenuItem = new ToolStripMenuItem();
            defaultSizeToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            volumeLevel = new Label();
            playlist = new ListBox();
            ((System.ComponentModel.ISupportInitialize)Volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.Cursor = Cursors.Hand;
            loadButton.FlatAppearance.BorderSize = 0;
            loadButton.FlatStyle = FlatStyle.Popup;
            loadButton.Font = new Font("Alef", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadButton.Location = new Point(9, 399);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(150, 50);
            loadButton.TabIndex = 0;
            loadButton.TabStop = false;
            loadButton.Text = "LOAD";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // playButton
            // 
            playButton.BackColor = SystemColors.Window;
            playButton.Cursor = Cursors.Hand;
            playButton.FlatAppearance.BorderSize = 0;
            playButton.FlatStyle = FlatStyle.Popup;
            playButton.Font = new Font("Alef", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playButton.Location = new Point(165, 399);
            playButton.Name = "playButton";
            playButton.Size = new Size(150, 50);
            playButton.TabIndex = 0;
            playButton.TabStop = false;
            playButton.Text = "▶";
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Cursor = Cursors.Hand;
            pauseButton.FlatAppearance.BorderSize = 0;
            pauseButton.FlatStyle = FlatStyle.Popup;
            pauseButton.Font = new Font("Alef", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pauseButton.Location = new Point(321, 399);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(151, 50);
            pauseButton.TabIndex = 0;
            pauseButton.TabStop = false;
            pauseButton.Text = "||";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // Volume
            // 
            Volume.AutoSize = false;
            Volume.Cursor = Cursors.Hand;
            Volume.Location = new Point(6, 350);
            Volume.Maximum = 100;
            Volume.Name = "Volume";
            Volume.Size = new Size(466, 30);
            Volume.TabIndex = 0;
            Volume.TabStop = false;
            Volume.TickFrequency = 0;
            Volume.Value = 20;
            Volume.Scroll += Volume_Scroll;
            // 
            // time
            // 
            time.AutoSize = false;
            time.BackColor = SystemColors.Window;
            time.Cursor = Cursors.Hand;
            time.Location = new Point(6, 315);
            time.Maximum = 100;
            time.Name = "time";
            time.Size = new Size(466, 30);
            time.TabIndex = 0;
            time.TabStop = false;
            time.TickFrequency = 0;
            time.Value = 20;
            time.Scroll += time_Scroll;
            // 
            // current_time
            // 
            current_time.AutoSize = true;
            current_time.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            current_time.Location = new Point(12, 288);
            current_time.Name = "current_time";
            current_time.Size = new Size(48, 18);
            current_time.TabIndex = 5;
            current_time.Text = "00:00";
            // 
            // slash
            // 
            slash.AutoSize = true;
            slash.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slash.Location = new Point(66, 288);
            slash.Name = "slash";
            slash.Size = new Size(12, 18);
            slash.TabIndex = 6;
            slash.Text = "/";
            // 
            // duration
            // 
            duration.AutoSize = true;
            duration.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            duration.Location = new Point(84, 288);
            duration.Name = "duration";
            duration.Size = new Size(48, 18);
            duration.TabIndex = 7;
            duration.Text = "00:00";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(6, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseUp += playlist_MouseUp;
            // 
            // title
            // 
            title.Font = new Font("Alef", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title.Location = new Point(6, 235);
            title.Name = "title";
            title.Size = new Size(466, 30);
            title.TabIndex = 0;
            title.Text = "No song is playing right now";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { clearToolStripMenuItem, deleteToolStripMenuItem, saveToolStripMenuItem, loadToolStripMenuItem, switchModeToolStripMenuItem, defaultSizeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(144, 136);
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(143, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(143, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(143, 22);
            saveToolStripMenuItem.Text = "Save Playlist";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(143, 22);
            loadToolStripMenuItem.Text = "Load Playlist";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // switchModeToolStripMenuItem
            // 
            switchModeToolStripMenuItem.Name = "switchModeToolStripMenuItem";
            switchModeToolStripMenuItem.Size = new Size(143, 22);
            switchModeToolStripMenuItem.Text = "Switch Mode";
            switchModeToolStripMenuItem.Click += switchModeToolStripMenuItem_Click;
            // 
            // defaultSizeToolStripMenuItem
            // 
            defaultSizeToolStripMenuItem.Name = "defaultSizeToolStripMenuItem";
            defaultSizeToolStripMenuItem.Size = new Size(143, 22);
            defaultSizeToolStripMenuItem.Text = "Default size";
            defaultSizeToolStripMenuItem.Click += defaultSizeToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // volumeLevel
            // 
            volumeLevel.AutoSize = true;
            volumeLevel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            volumeLevel.Location = new Point(432, 288);
            volumeLevel.Name = "volumeLevel";
            volumeLevel.Size = new Size(40, 18);
            volumeLevel.TabIndex = 9;
            volumeLevel.Text = "20%";
            // 
            // playlist
            // 
            playlist.AllowDrop = true;
            playlist.BorderStyle = BorderStyle.None;
            playlist.Cursor = Cursors.Hand;
            playlist.Font = new Font("Alef", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playlist.FormattingEnabled = true;
            playlist.ItemHeight = 22;
            playlist.Location = new Point(242, 12);
            playlist.Name = "playlist";
            playlist.Size = new Size(230, 220);
            playlist.TabIndex = 10;
            playlist.DragDrop += playlist_DragDrop;
            playlist.DragEnter += playlist_DragEnter;
            playlist.DoubleClick += playlist_DoubleClick;
            playlist.MouseUp += playlist_MouseUp;
            // 
            // TMP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(484, 461);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(volumeLevel);
            Controls.Add(playlist);
            Controls.Add(loadButton);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(Volume);
            Controls.Add(time);
            Controls.Add(pictureBox1);
            Controls.Add(title);
            Controls.Add(duration);
            Controls.Add(slash);
            Controls.Add(current_time);
            KeyPreview = true;
            Name = "TMP";
            ShowIcon = false;
            FormClosed += TMP_FormClosed;
            KeyUp += TMP_KeyUp;
            Resize += TMP_Resize;
            ((System.ComponentModel.ISupportInitialize)Volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)time).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadButton;
        private Button playButton;
        private Button pauseButton;
        private TrackBar Volume;
        private TrackBar time;
        private Label current_time;
        private Label slash;
        private Label duration;
        private PictureBox pictureBox1;
        private Label title;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem switchModeToolStripMenuItem;
        private Label volumeLevel;
        private ToolStripMenuItem defaultSizeToolStripMenuItem;
        private ListBox playlist;
    }
}
