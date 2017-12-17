using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//支持 特殊符号，中英文信息 的加解密，但是 所需加密的信息 不能含有与 秘钥 相同的字符，否则加密会失败
namespace TPtest
{
    public partial class Form1 : Form
    {

        Bitmap map; //图像信息
        byte[] pix; //图像的像素信息
        static char key; //解密信息的密钥

        string sss; //用于临时的测试用，并没有实际用途

        public Form1()
        {
            InitializeComponent();
        }
        
        //打开新图片
        private void openPic()
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


        //获取图片像素
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

        //修改图像像素（将图像像素偶数化），存储信息前的必要操作
        private void changePix()
        {
            //pix = GetImagePixel(this.map);
            for (int i = 0; i < pix.Length; i++)
            {
                if (pix[i] % 2 != 0)
                {
                    pix[i] -= 1;
                }
            }
            //this.richTextBox1.AppendText("\n 像素已修改 \n");
        }

        //在当前的状态下保存图像的信息
        private void savePix()
        {
            for (int i = 0, n = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    Color c = Color.FromArgb(pix[n], pix[n + 1], pix[n + 2]);
                    map.SetPixel(i, j, c);
                    n += 3;
                }
            }
            //this.richTextBox1.AppendText("\n 图像信息已保存 \n");
        }

        //显示图片的像素信息
        private void showPix()
        {
            foreach (byte pixle in pix)
            {
                this.richTextBox1.AppendText(pixle + " ");
            }
        }

        //隐藏信息的初始化操作
        private void HInitialization()
        {
            //判断是否已经打开了图片
            if (map == null) openPic();
            if (map != null)
            {
                pix = GetImagePixel(this.map);
                changePix();
                savePix();
            }

        }

        //解密信息的初始化
        private void RInitialization()
        {
            //判断是否已经打开了图片
            if (map == null) openPic();
            if (map != null)
            {
                pix = GetImagePixel(this.map);
                savePix();
            }
        }

        // 将字符串转成二进制
        public static string bianma(string bms)
        {
            byte[] data = Encoding.Unicode.GetBytes(bms);
            StringBuilder result = new StringBuilder(data.Length * 8);
            //补全为 16 位的二进制数
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
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }

        // 异或操作的加密解密运算
        public static string BCutEncrypt(string str)
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

        //监听秘钥输入框
        private void input_key_TextChanged(object sender, EventArgs e)
        {
            if (!(input_key.Text).Equals(""))
            {
                key = Convert.ToChar(input_key.Text);
            }
        }

        //打开图像按钮
        private void btn_open_Click(object sender, EventArgs e)
        {
            openPic();
        }

        //保存图像按钮
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

        // 读取并显示像素信息
        private void btn_readPix_Click(object sender, EventArgs e)
        {
            if (map == null || pix == null) RInitialization();
            if (map != null)
            {
                this.richTextBox1.Clear();
                showPix();
            }

        }

        //隐藏文本信息
        // 注意：由于使用的是 亦或操作 进行文本的加密的，所以 所要隐藏的文本信息 不能与 秘钥 相同
        private void btn_hideText_Click(object sender, EventArgs e)
        {
            String s = inputText.Text;
            this.richTextBox1.Clear();
            if (map == null || pix == null) HInitialization();
            if (map != null)
            {
                if ((inputText.Text).Equals("") || (input_key.Text).Equals(""))
                {
                    this.richTextBox1.AppendText("请检查所需隐藏的信息和密钥，两者都不能为空！！！"+'\n');
                    this.richTextBox1.AppendText("请输入完所需隐藏的信息和密钥后，重新点击【隐藏文本】按钮，进行加密！！！");
                }
                else
                {
                    String es = BCutEncrypt(s);
                    String bs = bianma(es);
                    for (int i = 0; i < bs.Length; i++)
                    {
                        int pixle = Convert.ToInt32(pix[i]) + Convert.ToInt32(bs[i]) - 48;
                        pix[i] = Convert.ToByte(pixle);
                        //pixle[i] = Convert.ToByte(Convert.ToInt32(bs[i])-48);
                    }
                    savePix();
                    this.richTextBox1.AppendText("信息隐藏成功！"+'\n');
                    //this.richTextBox1.AppendText("您隐藏的信息为：" + s + "\t 异或后：" + es + "\t 编码后：" + bs + '\n');
                    this.richTextBox1.AppendText("您隐藏的信息为：" + s);
                    //showPix();
                }
            }

        }

        //显示文本信息
        private void btn_showText_Click(object sender, EventArgs e)
        {
            string rs = null;
            this.richTextBox1.Clear();
            if (map == null || pix == null) RInitialization();
            if (map != null)
            {
                if ((input_key.Text).Equals(""))
                {
                    this.richTextBox1.Clear();
                    this.richTextBox1.AppendText("密钥不能为空！！！");
                }
                else
                {
                    int p = 0;//判断后面是否有 1 个全为 0 的十六位二进制数，如果有，说明密码文本读取结束
                    for (int i = 0; i < pix.Length;)
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
                        else
                        {
                            rs = rs.Substring(0, rs.Length - 16);
                            break;
                        }
                    }
                    //String es = jiema(rs);
                    //String bs = BCutEncrypt(es);
                    //this.richTextBox1.AppendText("您隐藏的信息为：" + bs + "\t 解码后：" + es + "\t 取码后：" + rs + '\n');
                    this.richTextBox1.AppendText("图像解密的结果为：" + BCutEncrypt(jiema(rs)));
                }
            }
        }

        //隐藏图像信息
        private void btn_hintImg_Click(object sender, EventArgs e)
        {

            //String es = BCutEncrypt(inputText.Text);
            //sss = bianma(es);
            //richTextBox1.AppendText("文本：" + inputText.Text + "异或：" + es+"\t 编码:"+sss+'\n');
           
        }

        //显示图像信息
        private void btn_showImg_Click(object sender, EventArgs e)
        {

            //String js = jiema(sss);
            //String es = BCutEncrypt(js);
            //richTextBox1.AppendText("编码：" + sss +"解码：" + js + "\t 异或:" + es + '\n');
        }

    }
    
}
