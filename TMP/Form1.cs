using NAudio.Wave;

namespace TMP
{
    public partial class TMP : Form
    {
        #region files

        private string list;
        private string index;
        private string image;
        private string data;

        #endregion

        private List<string> _list;

        private AudioFileReader? afr;
        private WaveOutEvent woe;

        private bool is_paused;
        private bool is_queue;
        private bool is_autorepeat;

        #region rectangles

        private Size orgSize;

        Rectangle loadRect;
        Rectangle playRect;
        Rectangle pauseRect;
        Rectangle volRect;
        Rectangle listRect;
        Rectangle titleRect;
        Rectangle timeRect;
        Rectangle curTimeRect;
        Rectangle durRect;
        Rectangle slashRect;
        Rectangle picRect;

        #endregion
        public TMP()
        {
            InitializeComponent();

            #region files

            list = Path.Combine(Application.LocalUserAppDataPath, "list");
            index = Path.Combine(Application.LocalUserAppDataPath, "index");
            image = Path.Combine(Application.LocalUserAppDataPath, "image");
            data = Path.Combine(Application.LocalUserAppDataPath, "data");

            #endregion

            woe = new WaveOutEvent();

            _list = new List<string>();

            pauseButton.Enabled = false;

            try
            {
                using StreamReader reader = new StreamReader(list);
                string? lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    _list.Add(lines);

                    playlist.Items.Add(Path.GetFileNameWithoutExtension(lines));
                }
            }
            catch (FileNotFoundException) { }

            try
            {
                using StreamReader reader = new StreamReader(index);
                string line = reader.ReadLine()!;

                try
                {
                    playlist.SelectedIndex = int.Parse(line);
                }
                catch (ArgumentOutOfRangeException) { }
            }
            catch (FileNotFoundException) { }

            #region rectangles

            orgSize = this.Size;
            loadRect = new Rectangle(loadButton.Location, loadButton.Size);
            playRect = new Rectangle(playButton.Location, playButton.Size);
            pauseRect = new Rectangle(pauseButton.Location, pauseButton.Size);
            volRect = new Rectangle(Volume.Location, Volume.Size);
            listRect = new Rectangle(playlist.Location, playlist.Size);
            titleRect = new Rectangle(title.Location, title.Size);
            timeRect = new Rectangle(time.Location, time.Size);
            curTimeRect = new Rectangle(curTime.Location, curTime.Size);
            durRect = new Rectangle(dur.Location, dur.Size);
            slashRect = new Rectangle(slash.Location, slash.Size);
            picRect = new Rectangle(pictureBox1.Location, pictureBox1.Size);

            #endregion

            try
            {
                using StreamReader reader = new StreamReader(image);
                pictureBox1.ImageLocation = reader.ReadLine();
            }
            catch (FileNotFoundException) { }

            try
            {
                using StreamReader reader = new StreamReader(data);
                string line = reader.ReadLine()!;

                Volume.Value = int.Parse(line);

                int num = int.Parse(reader.ReadLine()!);
                time.Maximum = num;

                int num2 = int.Parse(reader.ReadLine()!);
                time.Value = num2;

                string line2 = reader.ReadLine()!;
                if (line2 == "True")
                {
                    is_queue = true;
                    is_autorepeat = false;
                }
                else
                {
                    is_queue = false;
                    is_autorepeat = true;
                }

                string line3 = reader.ReadLine()!;
                if (line3 == "True")
                {
                    is_queue = false;
                    is_autorepeat = true;
                }
                else
                {
                    is_queue = true;
                    is_autorepeat = false;
                }
            }
            catch (FileNotFoundException) { }

            _play();

            woe.Pause();
            is_paused = true;

            if (afr != null)
            {
                afr.CurrentTime = TimeSpan.FromSeconds(time.Value);

                dur.Text = afr.TotalTime.ToString("mm\\:ss");
                curTime.Text = afr.CurrentTime.ToString("mm\\:ss");
            }
        }

        private void Msplayer_Resize(object sender, EventArgs e)
        {
            resize(loadButton, loadRect);
            resize(playButton, playRect);
            resize(pauseButton, pauseRect);
            resize(Volume, volRect);
            resize(playlist, listRect);
            resize(title, titleRect);
            resize(time, timeRect);
            resize(curTime, curTimeRect);
            resize(dur, durRect);
            resize(slash, slashRect);
            resize(pictureBox1, picRect);
        }

        private void resize(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(orgSize.Width);
            float yRatio = (float)(this.Height) / (float)(orgSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Msplayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            woe.Dispose();
            afr?.Dispose();

            using StreamWriter writer = new StreamWriter(data);
            writer.WriteLine(Volume.Value);
            writer.WriteLine(time.Maximum);
            writer.WriteLine(time.Value);
            writer.WriteLine(is_queue);
            writer.WriteLine(is_autorepeat);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(list))
            {
                writer.Write(string.Empty);
            }

            _list.Clear();

            playlist.Items.Clear();

            if (File.Exists(index))
            {
                File.Delete(index);
            }
            if (File.Exists(list))
            {
                File.Delete(list);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlist.SelectedIndex != -1)
            {
                using (StreamWriter writer = new StreamWriter(list))
                {
                    foreach (string line in _list)
                    {
                        if (line != _list[playlist.SelectedIndex])
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                playlist.Items.RemoveAt(playlist.SelectedIndex);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text|*.txt";
            sfd.FileName = "songs";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    foreach (string line in _list)
                    {
                        writer.WriteLine(line);
                    }
                }

                File.SetAttributes(sfd.FileName, FileAttributes.ReadOnly);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Text|*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using StreamReader reader = new StreamReader(ofd.FileName);
                string line = reader.ReadLine()!;

                using StreamWriter writer = new StreamWriter(list);
                if (!_list.Contains(line))
                {
                    if (line.Contains('\\'))
                    {
                        if ((line.Contains(".mp3", StringComparison.OrdinalIgnoreCase) || line.Contains(".wav", StringComparison.OrdinalIgnoreCase)))
                        {
                            writer.WriteLine(line);

                            _list.Add(line);

                            playlist.Items.Add(Path.GetFileNameWithoutExtension(line));
                        }
                    }
                }

                string? lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    writer.WriteLine(lines);

                    _list.Add(lines);

                    playlist.Items.Add(Path.GetFileNameWithoutExtension(lines));
                }
            }

            ofd.Dispose();
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
                using StreamWriter writer = new StreamWriter(list, true);
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    if (!_list.Contains(ofd.FileNames[i]))
                    {
                        writer.WriteLine(ofd.FileNames[i]);

                        _list.Add(ofd.FileNames[i]);

                        playlist.Items.Add(Path.GetFileNameWithoutExtension(ofd.FileNames[i]));
                    }
                }
            }
        }

        private void _play()
        {
            if (_list.Count != 0)
            {
                woe.Stop();
                woe.Dispose();

                afr?.Dispose();

                try
                {
                    afr = new AudioFileReader(_list[playlist.SelectedIndex]);

                    woe = new WaveOutEvent();
                }
                catch (ArgumentOutOfRangeException)
                {
                    afr?.Dispose();
                    woe.Dispose();

                    playlist.SelectedIndex = 0;

                    afr = new AudioFileReader(_list[playlist.SelectedIndex]);

                    woe = new WaveOutEvent();
                }

                using (StreamWriter writer = new StreamWriter(index))
                {
                    writer.Write(playlist.SelectedIndex);
                }

                woe.Init(afr);
                woe.Play();

                pauseButton.Enabled = true;
                is_paused = false;

                title.Text = Path.GetFileNameWithoutExtension(afr.FileName);

                timer1.Enabled = true;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (playlist.SelectedIndex != -1)
            {
                _play();
            }
            else
            {
                if (_list.Count != 0)
                {
                    try
                    {
                        using StreamReader reader = new StreamReader(index);
                        string? line = reader.ReadLine();

                        playlist.SelectedIndex = int.Parse(line!);
                    }
                    catch (FileNotFoundException)
                    {
                        playlist.SelectedIndex = 0;
                    }

                    _play();
                }
            }
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
        }

        private void time_Scroll(object sender, EventArgs e)
        {
            if (afr != null)
            {
                afr.CurrentTime = TimeSpan.FromSeconds(time.Value);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Maximum = (int)afr!.TotalTime.TotalSeconds;
            time.Value = (int)afr.CurrentTime.TotalSeconds;

            dur.Text = afr.TotalTime.ToString("mm\\:ss");
            curTime.Text = afr.CurrentTime.ToString("mm\\:ss");

            if (time.Value == time.Maximum && playlist.Items.Count > 0)
            {
                if (is_queue)
                {
                    using (StreamReader reader = new StreamReader(index))
                    {
                        int num = int.Parse(reader.ReadLine()!);

                        if (num < playlist.Items.Count - 1)
                        {
                            playlist.SelectedIndex = num + 1;
                        }
                    }

                    _play();
                }
                else if (is_autorepeat)
                {
                    playButton_Click(sender, e);
                }
            }
        }

        private void playlist_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;

            for (int i = 0; i < files.Length; i++)
            {
                if (!_list.Contains(files[i]))
                {
                    if (files[i].Contains(".mp3", StringComparison.OrdinalIgnoreCase) || files[i].Contains(".wav", StringComparison.OrdinalIgnoreCase))
                    {
                        using (StreamWriter writer = new StreamWriter(list, true))
                        {
                            writer.WriteLine(files[i]);
                        }

                        _list.Add(files[i]);

                        playlist.Items.Add(Path.GetFileNameWithoutExtension(files[i].ToString()));
                    }
                }
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

                using StreamWriter writer = new StreamWriter(image);
                writer.WriteLine(ofd.FileName);
            }
        }

        private void queueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_queue)
            {
                is_queue = true;
                is_autorepeat = false;
            }
            else
            {
                is_queue = false;
                is_autorepeat = true;
            }
        }

        private void autorepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_autorepeat)
            {
                is_queue = false;
                is_autorepeat = true;
            }
            else
            {
                is_queue = true;
                is_autorepeat = false;
            }
        }
    }
}
