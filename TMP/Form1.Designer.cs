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
            curTime = new Label();
            slash = new Label();
            dur = new Label();
            pictureBox1 = new PictureBox();
            title = new Label();
            playlist = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            clearToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            queueToolStripMenuItem = new ToolStripMenuItem();
            autorepeatToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            defaultToolStripMenuItem = new ToolStripMenuItem();
            bigToolStripMenuItem = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)Volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.FlatStyle = FlatStyle.Popup;
            loadButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadButton.Location = new Point(12, 399);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(150, 50);
            loadButton.TabIndex = 0;
            loadButton.Text = "load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // playButton
            // 
            playButton.FlatStyle = FlatStyle.Popup;
            playButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playButton.Location = new Point(168, 399);
            playButton.Name = "playButton";
            playButton.Size = new Size(150, 50);
            playButton.TabIndex = 1;
            playButton.Text = "play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.FlatStyle = FlatStyle.Popup;
            pauseButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pauseButton.Location = new Point(324, 399);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(150, 50);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // Volume
            // 
            Volume.AutoSize = false;
            Volume.Location = new Point(12, 364);
            Volume.Maximum = 100;
            Volume.Name = "Volume";
            Volume.Size = new Size(462, 30);
            Volume.TabIndex = 3;
            Volume.TickFrequency = 0;
            Volume.Value = 20;
            Volume.Scroll += Volume_Scroll;
            // 
            // time
            // 
            time.AutoSize = false;
            time.Location = new Point(12, 328);
            time.Maximum = 100;
            time.Name = "time";
            time.Size = new Size(462, 30);
            time.TabIndex = 4;
            time.TickFrequency = 0;
            time.Value = 20;
            time.Scroll += time_Scroll;
            // 
            // curTime
            // 
            curTime.AutoSize = true;
            curTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            curTime.Location = new Point(12, 310);
            curTime.Name = "curTime";
            curTime.Size = new Size(38, 16);
            curTime.TabIndex = 5;
            curTime.Text = "00:00";
            // 
            // slash
            // 
            slash.AutoSize = true;
            slash.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slash.Location = new Point(57, 310);
            slash.Name = "slash";
            slash.Size = new Size(11, 16);
            slash.TabIndex = 6;
            slash.Text = "/";
            // 
            // dur
            // 
            dur.AutoSize = true;
            dur.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dur.Location = new Point(71, 310);
            dur.Name = "dur";
            dur.Size = new Size(38, 16);
            dur.TabIndex = 7;
            dur.Text = "00:00";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            pictureBox1.MouseUp += playlist_MouseUp;
            // 
            // title
            // 
            title.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title.Location = new Point(257, 9);
            title.Name = "title";
            title.Size = new Size(212, 30);
            title.TabIndex = 9;
            title.Text = "No playing";
            // 
            // playlist
            // 
            playlist.AllowDrop = true;
            playlist.BorderStyle = BorderStyle.None;
            playlist.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playlist.FormattingEnabled = true;
            playlist.Location = new Point(257, 42);
            playlist.Name = "playlist";
            playlist.Size = new Size(217, 240);
            playlist.TabIndex = 10;
            playlist.DragDrop += playlist_DragDrop;
            playlist.DragEnter += playlist_DragEnter;
            playlist.DoubleClick += playButton_Click;
            playlist.MouseUp += playlist_MouseUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { clearToolStripMenuItem, deleteToolStripMenuItem, saveToolStripMenuItem, loadToolStripMenuItem, queueToolStripMenuItem, autorepeatToolStripMenuItem, settingsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(141, 158);
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(140, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(140, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(140, 22);
            saveToolStripMenuItem.Text = "Save Playlist";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(140, 22);
            loadToolStripMenuItem.Text = "Load Playlist";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // queueToolStripMenuItem
            // 
            queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            queueToolStripMenuItem.Size = new Size(140, 22);
            queueToolStripMenuItem.Text = "Queue";
            queueToolStripMenuItem.Click += queueToolStripMenuItem_Click;
            // 
            // autorepeatToolStripMenuItem
            // 
            autorepeatToolStripMenuItem.Name = "autorepeatToolStripMenuItem";
            autorepeatToolStripMenuItem.Size = new Size(140, 22);
            autorepeatToolStripMenuItem.Text = "Autorepeat";
            autorepeatToolStripMenuItem.Click += autorepeatToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(140, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { defaultToolStripMenuItem, bigToolStripMenuItem, smallToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(181, 92);
            // 
            // defaultToolStripMenuItem
            // 
            defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            defaultToolStripMenuItem.Size = new Size(180, 22);
            defaultToolStripMenuItem.Text = "Default";
            defaultToolStripMenuItem.Click += defaultToolStripMenuItem_Click;
            // 
            // bigToolStripMenuItem
            // 
            bigToolStripMenuItem.Name = "bigToolStripMenuItem";
            bigToolStripMenuItem.Size = new Size(180, 22);
            bigToolStripMenuItem.Text = "Big";
            bigToolStripMenuItem.Click += bigToolStripMenuItem_Click;
            // 
            // smallToolStripMenuItem
            // 
            smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            smallToolStripMenuItem.Size = new Size(180, 22);
            smallToolStripMenuItem.Text = "Small";
            smallToolStripMenuItem.Click += smallToolStripMenuItem_Click;
            // 
            // TMP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(484, 461);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(playlist);
            Controls.Add(title);
            Controls.Add(pictureBox1);
            Controls.Add(dur);
            Controls.Add(slash);
            Controls.Add(curTime);
            Controls.Add(time);
            Controls.Add(Volume);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(loadButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TMP";
            FormClosed += TMP_FormClosed;
            ResizeEnd += TMP_ResizeEnd;
            MouseUp += playlist_MouseUp;
            Resize += TMP_Resize;
            ((System.ComponentModel.ISupportInitialize)Volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)time).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadButton;
        private Button playButton;
        private Button pauseButton;
        private TrackBar Volume;
        private TrackBar time;
        private Label curTime;
        private Label slash;
        private Label dur;
        private PictureBox pictureBox1;
        private Label title;
        private ListBox playlist;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem queueToolStripMenuItem;
        private ToolStripMenuItem autorepeatToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        public ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem bigToolStripMenuItem;
        private ToolStripMenuItem smallToolStripMenuItem;
    }
}
