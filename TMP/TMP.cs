using NAudio.Wave;

namespace TMP
{
    public partial class TMP : Form
    {
        private string list;
        private string cfg;

        private AudioFileReader? afr;
        private WaveOutEvent woe;

        private bool is_queue = true;
        private bool is_paused;

        private Size orgSize;
        private Rectangle[] rects = new Rectangle[12];

        List<string> paths = [];

        ToolTip tip = new();
        void LockCtrls()
        {
            pauseButton.Enabled = false;
            playButton.Enabled = false;
            time.Enabled = false;
        }

        void LoadCfgs()
        {
            cfg = Path.Combine(Application.StartupPath, "config");

            if (File.Exists(cfg))
            {
                using StreamReader reader = new StreamReader(cfg);
                string line = reader.ReadLine();

                if (line == "0")
                {
                    is_queue = false;
                }
                else if (line == "1")
                {
                    is_queue = true;
                }
            }

            list = Path.Combine(Application.StartupPath, "playlist");

            if (File.Exists(list))
            {
                paths = File.ReadLines(list).ToList();
            }

            foreach (var path in paths)
            {
                playlist.Items.Add(Path.GetFileNameWithoutExtension(path));
            }

            if (playlist.Items.Count == 0)
            {
                LockCtrls();
            }
        }
        public TMP()
        {
            InitializeComponent();

            #region rectangles

            orgSize = this.Size;
            rects[0] = new Rectangle(loadButton.Location, loadButton.Size);
            rects[1] = new Rectangle(playButton.Location, playButton.Size);
            rects[2] = new Rectangle(pauseButton.Location, pauseButton.Size);
            rects[3] = new Rectangle(Volume.Location, Volume.Size);
            rects[4] = new Rectangle(playlist.Location, playlist.Size);
            rects[5] = new Rectangle(title.Location, title.Size);
            rects[6] = new Rectangle(time.Location, time.Size);
            rects[7] = new Rectangle(current_time.Location, current_time.Size);
            rects[8] = new Rectangle(duration.Location, duration.Size);
            rects[9] = new Rectangle(slash.Location, slash.Size);
            rects[10] = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            rects[11] = new Rectangle(volumeLevel.Location, volumeLevel.Size);

            #endregion

            woe = new WaveOutEvent();

            LoadCfgs();
        }
        private void TMP_Resize(object sender, EventArgs e)
        {
            resize(loadButton, rects[0]);
            resize(playButton, rects[1]);
            resize(pauseButton, rects[2]);
            resize(Volume, rects[3]);
            resize(playlist, rects[4]);
            resize(title, rects[5]);
            resize(time, rects[6]);
            resize(current_time, rects[7]);
            resize(duration, rects[8]);
            resize(slash, rects[9]);
            resize(pictureBox1, rects[10]);
            resize(volumeLevel, rects[11]);
        }

        //some trick i've got from one yt video. ^C ^V

        private void resize(Control c, Rectangle r)
        {
            float xRatio = Width / (float)(orgSize.Width);
            float yRatio = Height / (float)(orgSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void TMP_FormClosed(object sender, FormClosedEventArgs e)
        {
            woe.Dispose();
            afr?.Dispose();

            using (StreamWriter writer = new StreamWriter(cfg))
            {
                if (is_queue)
                {
                    writer.WriteLine(1);
                }
                else
                {
                    writer.WriteLine(0);
                }
            }

            using StreamWriter writer2 = new StreamWriter(list);

            foreach (var path in paths)
            {
                writer2.WriteLine(path);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockCtrls();

            playlist.Items.Clear();
            paths.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlist.SelectedIndex != -1)
            { 
                playlist.Items.RemoveAt(playlist.SelectedIndex);
                paths.RemoveAt(playlist.SelectedIndex);

                if (playlist.Items.Count == 0)
                {
                    LockCtrls();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Text|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter writer = new StreamWriter(sfd.FileName);
                foreach (string line in paths)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var name in ofd.FileNames)
                {
                    paths.Add(name);
                    playlist.Items.Add(Path.GetFileNameWithoutExtension(name));
                }

                if (playlist.Items.Count != 0)
                {
                    playButton.Enabled = true;
                }
            }
        }

        private void playlist_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && playlist.IndexFromPoint(e.X, e.Y) == -1)
            {
                playlist.SelectedIndex = -1;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "All|*.mp3;*.wav|Mp3|*.mp3|Wav|*.wav";

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var name in ofd.FileNames)
                {
                    paths.Add(name);
                    playlist.Items.Add(Path.GetFileNameWithoutExtension(name));
                }

                if (playlist.Items.Count != 0)
                {
                    playButton.Enabled = true;
                }
            }
        }

        private void _play()
        {
            if (woe.PlaybackState == PlaybackState.Playing || woe.PlaybackState == PlaybackState.Paused)
            {
                woe.Stop();
            }

            string path = paths[playlist.SelectedIndex];

            if (File.Exists(path))
            {
                afr = new AudioFileReader(path);

                woe.Init(afr);
                woe.Play();

                timer1.Start();

                title.Text = Path.GetFileNameWithoutExtension(afr.FileName);
            }
            else
            {
                MessageBox.Show($"The file {path} doesn't exist. It will be not played", "Error", MessageBoxButtons.OK);
                paths.Remove(path);
                playlist.Items.Remove(path);
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (playlist.SelectedIndex == -1)
            {
                playlist.SelectedIndex = 0;
            }

            _play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (!is_paused)
            {
                woe.Pause();
                is_paused = true;
            }
            else
            {
                woe.Play();
                is_paused = false;
            }
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            woe.Volume = Volume.Value / 100f;
            volumeLevel.Text = $"{Volume.Value}%";
        }

        private void time_Scroll(object sender, EventArgs e)
        {
            afr!.CurrentTime = TimeSpan.FromSeconds(time.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Maximum = (int)afr!.TotalTime.TotalSeconds;
            time.Value = (int)afr.CurrentTime.TotalSeconds;

            duration.Text = afr.TotalTime.ToString("mm\\:ss");
            current_time.Text = afr.CurrentTime.ToString("mm\\:ss");

            if (time.Value == time.Maximum)
            {
                if (playlist.Items.Count != 0)
                {
                    if (playlist.SelectedIndex == -1)
                    {
                        playlist.SelectedIndex = 0;
                    }
                    else
                    {
                        if (is_queue)
                        {
                            if (playlist.SelectedIndex < playlist.Items.Count - 1)
                            {
                                ++playlist.SelectedIndex;
                            }
                            else
                            {
                                playlist.SelectedIndex = 0;
                            }
                        }
                    }

                    timer1.Stop();
                    _play();
                }
                else
                {
                    LockCtrls();
                    timer1.Stop();
                }
            }
        }

        private void playlist_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var file in (string[])e.Data!.GetData(DataFormats.FileDrop)!)
            {
                paths.Add(file);
                playlist.Items.Add(Path.GetFileNameWithoutExtension(file));

                playButton.Enabled = true;
            }

        }

        private void playlist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All|*.png;*.jpg|PNG|*.png|JPG|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void TMP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space)
            {
                pauseButton_Click(sender, e);
            }
            else if (e.KeyValue == (char)Keys.Escape)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void switchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_queue)
            {
                is_queue = true;

                tip.Show("Mode: Queue", playlist, 1500);
            }
            else
            {
                is_queue = false;

                tip.Show("Mode: Repeat", playlist, 1500);
            }
        }

        private void playlist_DoubleClick(object sender, EventArgs e)
        {
            if (playlist.Items.Count != 0)
            {
                if (playlist.SelectedIndex == -1)
                {
                    playlist.SelectedIndex = 0;
                }

                _play();
            }
        }

        private void defaultSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 500;
            Height = 500;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            tip.Show("Select picture", pictureBox1, 1500);
        }
    }
}
