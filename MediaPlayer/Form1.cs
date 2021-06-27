using System;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;            
            WMP.URL = fileName;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.play();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.pause();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            WMP.settings.volume = trackBar1.Value;
            
        }

        private void WMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            trackBar2.Maximum = Convert.ToInt32(WMP.currentMedia.duration);
            trackBar2.Value = Convert.ToInt32(WMP.Ctlcontrols.currentPosition);

            // Проверка

            if(WMP != null)
            {
                int s = (int)WMP.Ctlcontrols.currentPosition;
                int h = s / 3600;

                int m = (s - (h * 3600)) / 60;

                s = s - (h * 3600 + m * 60);

                label2.Text = String.Format("{0:D}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                label2.Text = "0:00:00";
            }
        }       

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.currentPosition = trackBar2.Value;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы MediaPlayer v.2.0:  ., \nДата релиза: 10.06.2021 г.", "Внимание!!");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
