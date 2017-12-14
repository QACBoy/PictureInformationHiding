using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TPtest
{
    public partial class Form1 : Form
    {
        Bitmap map;
        byte[] pix;
        string sss;
        static char key;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BMP Files(*.bmp)|*.bmp|JPG File(*.jpg;*.jpeg)|*.jpg;*.jpeg|ALL Files(*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                map = new Bitmap(ofd.FileName);
                if (map == null)
                {
                    MessageBox.Show("图片加载失败！", "错误");
                    return;
                }
                pictureBox1.Image = map;
                ofd.Dispose();
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (map == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP Files(*.bmp)|*.bmp|JPG File(*.jpg;*.jpeg)|*.jpg;*.jpeg|ALL Files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("图片保存成功！", "提示");
                sfd.Dispose();
            }

        }
        public static byte[] GetImagePixel(Bitmap img)
        {

            byte[] result = new byte[img.Width * img.Height * 3];
            int n = 0;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    result[n] = img.GetPixel(i, j).R;
                    result[n + 1] = img.GetPixel(i, j).G;
                    result[n + 2] = img.GetPixel(i, j).B;
                    n += 3;
                }
            }
            return result;
        }

        private void btn_readPix_Click(object sender, EventArgs e)
        {
            pix = GetImagePixel(this.map);
            this.richTextBox1.Clear();
            foreach (byte pixle in pix)
            {
                this.richTextBox1.AppendText(pixle + " ");
            }
        }

        private void btn_changePix_Click(object sender, EventArgs e)
        {
            if (map == null)
            {
                return;
            }
            int n = 0;
            pix = GetImagePixel(this.map);
            for (int i = 0; i < pix.Length; i++)
            {
                if (pix[i] % 2 != 0)
                {
                    pix[i] -= 1;
                }
            }
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    Color c = Color.FromArgb(pix[n], pix[n + 1], pix[n + 2]);
                    map.SetPixel(i, j, c);
                    n += 3;
                }
            }
            this.richTextBox1.Clear();
            foreach (byte pixle1 in pix)
            {
                this.richTextBox1.AppendText(pixle1 + " ");
            }
        }

        // 将字符串转成二进制
        public static string bianma(string bms)
        {
          byte[] data = Encoding.Unicode.GetBytes(bms);
          StringBuilder result = new StringBuilder(data.Length * 8);
  
          foreach (byte b in data)
          {
              result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
          }
          return result.ToString();
        }

      // 将二进制转成字符串
      public static String jiema(String js)
      {
            System.Text.RegularExpressions.CaptureCollection cs =
              System.Text.RegularExpressions.Regex.Match(js, @"([01]{8})+").Groups[1].Captures;
          byte[] data = new byte[cs.Count];
          for (int i = 0; i<cs.Count; i++)
          {
              data[i] = Convert.ToByte(cs[i].Value, 2);
          }
          return Encoding.Unicode.GetString(data, 0, data.Length);
        }
      

        /// 异或的加密解密
        public static String BCutEncrypt(String str)
        {
            char emblem = key;//密钥
            StringBuilder buffer = new StringBuilder();
            char[] chars = str.ToCharArray();
            foreach (char ch in chars)
            {
                char temp = (char)(ch ^ emblem);
                buffer.Append(temp);
            }
            return buffer.ToString();
        }

        
        private void btn_hideText_Click(object sender, EventArgs e)
        {
            String s = inputText.Text;
            String es = BCutEncrypt(s);
            String bs = bianma(es);
            this.richTextBox1.Clear();
            if (map != null)
            {
                for (int i = 0; i < bs.Length; i++)
                {
                    int pixle = Convert.ToInt32(pix[i]) + Convert.ToInt32(bs[i]) - 48;
                    pix[i] = Convert.ToByte(pixle);
                    //pixle[i] = Convert.ToByte(Convert.ToInt32(bs[i])-48);
                }
                for (int i = 0, n = 0; i < map.Width; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        Color c = Color.FromArgb(pix[n], pix[n + 1], pix[n + 2]);
                        map.SetPixel(i, j, c);
                        n += 3;
                    }
                }
                foreach (byte pixle1 in pix)
                {
                    this.richTextBox1.AppendText(pixle1 + " ");
                }
                //richTextBox1.AppendText("jiami：" + es + "    2jinzhi:" + bs );
            }
            else
            {
                this.richTextBox1.AppendText(sss);
            }

        }











        private void btn_showText_Click(object sender, EventArgs e)
        {
            string rs = null;
            this.richTextBox1.Clear();
            if (map != null)
            {
                int p = 0;//判断后面是否有 1 个全为 0 的十六位二进制数，如果有，说明密码文本读取结束
                for (int i = 0; i < pix.Length; )
                {
                    if (p != 16)
                    {
                        p = 0;
                        for (int j = 0; j < 16; j++)
                        {
                            int pixle = Convert.ToInt32(pix[i]);
                            if (pixle % 2 == 1) rs += "1";
                            else
                            {
                                rs += "0";
                                p++;
                            }
                            i++;
                        }
                    }
                    else {
                        rs=rs.Substring(0, rs.Length - 16);
                        break;
                    }
                }
                String es = jiema(rs);
                String bs = BCutEncrypt(es);
                this.richTextBox1.AppendText(bs);
                //this.richTextBox1.AppendText("     rs" + rs + "       jiamma:" + es + "     jiemi:" + bs);
            }
            else
            {
                rs = BCutEncrypt(sss);
                this.richTextBox1.AppendText("jiemi:"+rs);
            }
        }









        private void inputText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_hintImg_Click(object sender, EventArgs e)
        {

            String es = BCutEncrypt(inputText.Text);
            String bs = bianma(es);
            sss = bs;
            this.richTextBox1.Clear();
            richTextBox1.AppendText("jiami：" + es+"    2jinzhi:"+bs+"     sss"+sss);
            //if (map == null) return;
            //String t4 = bianma("5",1);
            //int kk = 10 ^ 1;
            //int l = t4.Length;
            //byte tt = 0;
            //String tk = Convert.ToString(kk, 2).PadLeft(16, '0');
            //richTextBox1.AppendText("t4的16位二进制：" + t4 + "      长度：" + l + "      t4转换后："+Convert.ToInt32(t4,2));
            //richTextBox1.AppendText("t4的16位二进制：" + t4);
            //String tk1 = Convert.ToString(kk, 2).PadLeft(16, '0');
            //richTextBox1.AppendText("     16位二进制为：" + tk + "      tk.length:" + tk.Length);
            //int i = Convert.ToInt32(t4, 2);
            //int t3 = 2 ^ 13;
            //char key = 'n';
            //richTextBox1.AppendText(Convert.ToString(2, 2).PadLeft(16, '0') + "   "+ Convert.ToString(13, 2).PadLeft(16, '0') + "   "+"t3：" + Convert.ToString(t3,2).PadLeft(16, '0'));
            //string s = BCutEncrypt(t4, key);
            //string ss = BCutEncrypt(s, key);
            //richTextBox1.AppendText(t4.PadLeft(16, '0')+"    jiami :" +s+"   jiemi:"+ ss);

            //richTextBox1.AppendText("t4：" + Convert.ToString(i));
        }

        private void btn_showImg_Click(object sender, EventArgs e)
        {
            //if (map == null) return;
            String es = jiema(sss);
            String bs = BCutEncrypt(es);
            this.richTextBox1.AppendText("     sss" + sss+"       jiamma:" +es+"     jiemi:"+bs);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void input_key_TextChanged(object sender, EventArgs e)
        {
            key = Convert.ToChar(input_key.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /* private void Form1_Load(object sender, EventArgs e)
{

}*/

    }
    
}
