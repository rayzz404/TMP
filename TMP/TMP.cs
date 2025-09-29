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
        private string color;
        private string width;
        private string height;
        private string lang;

        #endregion

        private List<string> _list;

        private AudioFileReader? afr;
        private WaveOutEvent woe;

        private bool is_paused;
        private bool is_queue;
        private bool is_autorepeat;

        private Size orgSize;
        private Rectangle[] rects = new Rectangle[11];
        public TMP()
        {
            InitializeComponent();

            #region files

            list = Path.Combine(Application.LocalUserAppDataPath, "list");
            index = Path.Combine(Application.LocalUserAppDataPath, "index");
            image = Path.Combine(Application.LocalUserAppDataPath, "image");
            data = Path.Combine(Application.LocalUserAppDataPath, "data");
            color = Path.Combine(Application.LocalUserAppDataPath, "color");
            width = Path.Combine(Application.LocalUserAppDataPath, "width");
            height = Path.Combine(Application.LocalUserAppDataPath, "height");
            lang = Path.Combine(Application.LocalUserAppDataPath, "lang");

            #endregion

            if (playlist.Items.Count == 0)
            {
                playButton.Enabled = false;
            }

            try
            {
                using StreamReader reader = new StreamReader(image);
                pictureBox1.ImageLocation = reader.ReadLine();
            }
            catch (FileNotFoundException)
            {
                setStandartImage();
            }

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
            rects[0] = new Rectangle(loadButton.Location, loadButton.Size);
            rects[1] = new Rectangle(playButton.Location, playButton.Size);
            rects[2] = new Rectangle(pauseButton.Location, pauseButton.Size);
            rects[3] = new Rectangle(Volume.Location, Volume.Size);
            rects[4] = new Rectangle(playlist.Location, playlist.Size);
            rects[5] = new Rectangle(title.Location, title.Size);
            rects[6] = new Rectangle(time.Location, time.Size);
            rects[7] = new Rectangle(curTime.Location, curTime.Size);
            rects[8] = new Rectangle(dur.Location, dur.Size);
            rects[9] = new Rectangle(slash.Location, slash.Size);
            rects[10] = new Rectangle(pictureBox1.Location, pictureBox1.Size);

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

            try
            {
                afr!.CurrentTime = TimeSpan.FromSeconds(time.Value);

                dur.Text = afr.TotalTime.ToString("mm\\:ss");
                curTime.Text = afr.CurrentTime.ToString("mm\\:ss");
            }
            catch (NullReferenceException) { }

            try
            {
                using StreamReader reader = new StreamReader(color);
                string line = reader.ReadLine()!;

                switch (line)
                {
                    case "red":
                        BackColor = Color.IndianRed;
                        playlist.BackColor = Color.IndianRed;
                        break;
                    case "yellow":
                        BackColor = Color.LightYellow;
                        playlist.BackColor = Color.LightYellow;
                        break;
                    case "green":
                        BackColor = Color.LightGreen;
                        playlist.BackColor = Color.LightGreen;
                        break;
                    case "blue":
                        BackColor = Color.LightBlue;
                        playlist.BackColor = Color.LightBlue;
                        break;
                    case "pink":
                        BackColor = Color.LightPink;
                        playlist.BackColor = Color.LightPink;
                        break;
                    case "white":
                        BackColor = Color.White;
                        playlist.BackColor = Color.White;
                        break;
                }
            }
            catch (FileNotFoundException) { }

            try
            {
                using (StreamReader reader1 = new StreamReader(width))
                {
                    int w = int.Parse(reader1.ReadLine()!);
                    Width = w;
                }

                using StreamReader reader2 = new StreamReader(height);
                int h = int.Parse(reader2.ReadLine()!);
                Height = h;
            }
            catch (FileNotFoundException) { }

            try
            {
                using StreamReader reader = new StreamReader(lang);
                string line = reader.ReadLine()!;
                if (line == "ru")
                {
                    loadButton.Text = "загрузить";
                    playButton.Text = "играть";
                    pauseButton.Text = "пауза";
                }
            }
            catch (FileNotFoundException) { }
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
            resize(curTime, rects[7]);
            resize(dur, rects[8]);
            resize(slash, rects[9]);
            resize(pictureBox1, rects[10]);
        }

        private void TMP_ResizeEnd(object sender, EventArgs e)
        {
            using (StreamWriter writer1 = new StreamWriter(width))
            {
                writer1.WriteLine(Width);
            }

            using StreamWriter writer2 = new StreamWriter(height);
            writer2.WriteLine(Height);
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

        private void TMP_FormClosed(object sender, FormClosedEventArgs e)
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

            try
            {
                File.Delete(index);
            }
            catch (FileNotFoundException) { }

            try
            {
                File.Delete(list);
            }
            catch (FileNotFoundException) { }

            playButton.Enabled = false;
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

                if (playlist.Items.Count == 0)
                {
                    playButton.Enabled = false;
                }
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

                playButton.Enabled = true;
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

                if (playlist.Items.Count > 0)
                {
                    playButton.Enabled = true;
                }
            }
        }

        private void _play()
        {
            if (_list.Count != 0)
            {
                woe.Stop();
                woe.Dispose();

                try
                {
                    afr!.Dispose();
                }
                catch (NullReferenceException) { }

                try
                {
                    try
                    {
                        afr = new AudioFileReader(_list[playlist.SelectedIndex]);

                        woe = new WaveOutEvent();
                    }
                    catch (FileNotFoundException) { }
                }
                catch (ArgumentOutOfRangeException)
                {
                    afr?.Dispose();
                    woe.Dispose();

                    playlist.SelectedIndex = 0;

                    afr = new AudioFileReader(_list[playlist.SelectedIndex]);
                }

                using (StreamWriter writer = new StreamWriter(index))
                {
                    writer.Write(playlist.SelectedIndex);
                }

                pauseButton.Enabled = true;
                is_paused = false;

                if (afr != null)
                {
                    woe.Init(afr);
                    woe.Play();

                    title.Text = Path.GetFileNameWithoutExtension(afr.FileName);
                }

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
            try
            {
                afr!.CurrentTime = TimeSpan.FromSeconds(time.Value);
            }
            catch (NullReferenceException) { }
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

                        playButton.Enabled = true;
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

        private void red_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("red");

            BackColor = Color.IndianRed;
            playlist.BackColor = Color.IndianRed;
        }

        private void yellow_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("yellow");

            BackColor = Color.LightYellow;
            playlist.BackColor = Color.LightYellow;
        }

        private void green_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("green");

            BackColor = Color.LightGreen;
            playlist.BackColor = Color.LightGreen;
        }

        private void blue_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("blue");

            BackColor = Color.LightBlue;
            playlist.BackColor = Color.LightBlue;
        }

        private void pink_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("pink");

            BackColor = Color.LightPink;
            playlist.BackColor = Color.LightPink;
        }

        private void white_Click(object? sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter(color);
            sw.WriteLine("white");

            BackColor = Color.White;
            playlist.BackColor = Color.White;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 500;
            Height = 500;

            using (StreamWriter writer1 = new StreamWriter(width))
            {
                writer1.WriteLine(Width);
            }

            using StreamWriter writer2 = new StreamWriter(height);
            writer2.WriteLine(Height);
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 700;
            Height = 700;

            using (StreamWriter writer1 = new StreamWriter(width))
            {
                writer1.WriteLine(Width);
            }

            using StreamWriter writer2 = new StreamWriter(height);
            writer2.WriteLine(Height);
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 400;
            Height = 400;

            using (StreamWriter writer1 = new StreamWriter(width))
            {
                writer1.WriteLine(Width);
            }

            using StreamWriter writer2 = new StreamWriter(height);
            writer2.WriteLine(Height);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            settings.size.Click += ShowContextMenu2;
            settings.colors.Click += ShowColorPallete;
            settings.language.Click += ShowLanguages;
        }

        private void ShowContextMenu2(object? sender, EventArgs e)
        {
            contextMenuStrip2.Show(Cursor.Position);
        }

        private void ShowColorPallete(object? sender, EventArgs e)
        {
            ColorPalette colorPalette = new ColorPalette();
            colorPalette.Show();
            colorPalette.red.Click += red_Click;
            colorPalette.yellow.Click += yellow_Click;
            colorPalette.green.Click += green_Click;
            colorPalette.blue.Click += blue_Click;
            colorPalette.pink.Click += pink_Click;
            colorPalette.white.Click += white_Click;
        }

        private void ShowLanguages(object? sender, EventArgs e)
        {
            Languages languages = new Languages();
            languages.Show();
            languages.EN.Click += SetToEnglish;
            languages.RU.Click += SetToRussian;
        }

        private void SetToEnglish(object? sender, EventArgs e)
        {
            loadButton.Text = "load";
            playButton.Text = "play";
            pauseButton.Text = "pause";

            using StreamWriter streamWriter = new StreamWriter(lang);
            streamWriter.WriteLine("en");
        }

        private void SetToRussian(object? sender, EventArgs e)
        {
            loadButton.Text = "загрузить";
            playButton.Text = "играть";
            pauseButton.Text = "пауза";

            using StreamWriter streamWriter = new StreamWriter(lang);
            streamWriter.WriteLine("ru");
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

        private void setStandartImage()
        {
            string path = Path.Combine(Application.StartupPath, "orgpic.png");

            try
            {
                pictureBox1.ImageLocation = path;

                using (StreamWriter writer = new StreamWriter(image))
                {
                    writer.Write(path);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Image not found at {path}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setStandartImage();
        }
    }
}
