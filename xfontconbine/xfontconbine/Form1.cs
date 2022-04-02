using System;
using System.IO;
using System.Windows.Forms;

namespace xfontconvine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static int IPLROM_SIZE = 0x20000;

        private void conbine_Click(object sender, EventArgs e)
        {
            Cursor precursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                byte[] fntbin = new byte[3047];
                using (FileStream fnt = new FileStream(fontRomPath.Text, FileMode.Open, FileAccess.Read))
                {
                    int len = (int)fnt.Length;
                    if (IPLROM_SIZE != len)
                    {
                        MessageBox.Show("ごめんね、IPL-ROMではないみたい...(´・ω・｀)");
                        return;
                    }
                    byte[] buf = new byte[len];
                    fnt.Read(buf, 0, len);
                    int fntaddr = 0;
                    switch (buf[0x1000a])
                    {
                        case 0x10:
                            fntaddr = 0x1d018;
                            break;
                        case 0x11:
                            fntaddr = 0x1d344;
                            break;
                        case 0x12:
                            fntaddr = 0x1d45e;
                            break;
                        default:
                            MessageBox.Show("ROMが違う...(´Д｀)");
                            return;
                    }

                    Array.Copy(buf, fntaddr, fntbin, 0, fntbin.Length);
                }

                for (int cnt = 0; cnt < 253; ++cnt)
                {
                    string buf = string.Empty;
                    for (int i = 0; i < 12; ++i)
                    {
                        buf += Convert.ToString(fntbin[cnt * 12 + i], 2).PadLeft(8, '0') + "\r\n";
                    }
                    fontImage.Text += buf.Replace('0', '　').Replace('1', '■') + "\r\n";
                }

                byte[] iplbin = new byte[IPLROM_SIZE];
                using (FileStream ipl = new FileStream(ipl13RomPath.Text, FileMode.Open, FileAccess.Read))
                {
                    int len = (int)ipl.Length;
                    byte[] buf = new byte[len];
                    ipl.Read(buf, 0, len);
                    Array.Copy(buf, 0, iplbin, 0, iplbin.Length);
                }

                for (int i = 0; i < fntbin.Length; ++i)
                {
                    if (0xff != iplbin[0xf400 + i])
                    {
                        MessageBox.Show("フォントを入れる領域が空ではないっす( ;∀;)");
                        return;
                    }
                }

                Array.Copy(fntbin, 0, iplbin, 0xf400, fntbin.Length);

                using (FileStream fntipl = new FileStream(ipl13RomPath.Text, FileMode.Create, FileAccess.Write))
                {
                    fntipl.Write(iplbin, 0, iplbin.Length);
                }

                MessageBox.Show("終わったよ(´▽｀)");
            }
            catch
            {
                MessageBox.Show("なんか失敗したみたい(´Д｀)");
            }
            finally
            {
                Cursor.Current = precursor;
            }
        }

        private void fontRomPath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ipl13RomPath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void fontRomPath_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                fontRomPath.Text = filePath;
                break;
            }
        }

        private void ipl13RomPath_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                ipl13RomPath.Text = filePath;
                break;
            }
        }
    }
}
