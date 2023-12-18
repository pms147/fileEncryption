using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace WindowsFormsApp1
{
    public partial class EncrpytForm : Form
    {
        public (RSAParameters, RSAParameters) FKprivate;
        public EncrpytForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Choose_file(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                label1.Text = "File mã hóa: " + ofd.FileName;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if(label1.Text == "File mã hóa: ")
            {
                MessageBox.Show("Bạn chưa chọn file");
                return;
            }

            // Key AES 
            byte[] Ks = AES.generate_AES_key();
            byte[] IV = AES.generate_AES_IV();
            Program.IV = IV;

            string P = "";
            string path = label1.Text.Remove(0,13);

            // Đọc file Plain text
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    P += temp.GetString(b);
                }
            }

            // AES Encrypt
            byte[] C = AES.encrypt_AES(P, Ks, IV);

            // Lưu file đã mã hóa vào thư mục giống như file Plain text (.../P_encrypt)
            string pathC = label1.Text.Remove(0, 13);
            int i = pathC.Length - 1;
            while (pathC[i] != '.')
            {
                --i;
            }
            pathC = pathC.Insert(i, "_encrypt");
            using (var fs = new FileStream(pathC, FileMode.Create, FileAccess.Write))
            {
                fs.Write(C, 0, C.Length);
            }

            // Key RSA
            (RSAParameters, RSAParameters) Kpublic_Kprivate = Rsa.generate_RSA_key();
            FKprivate = Kpublic_Kprivate;
            byte[] Kx = Rsa.encrypt_RSA(Ks, Kpublic_Kprivate.Item1);
            Program.Kx = Kx;

       

            // Hash SHA-1
            byte[] HKprivate = SHA.SHA_1(Kpublic_Kprivate.Item2.D);
            Program.HKprivate = HKprivate;

            MessageBox.Show("Mã hóa thành công");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "File mã hóa: ")
            {
                MessageBox.Show("Bạn chưa chọn file");
                return;
            }
            if (FKprivate.Item2.D == null)
            {
                MessageBox.Show("Bạn chưa chọn mã hóa");
                return;
            }


            // Lưu Kprivate vào thư mục giống như file Plain text (.../P_Kprivate.xml)
            string path = label1.Text.Remove(0, 13);
            XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
            int i = path.Length - 1;
            while (path[i] != '.')
            {
                --i;
            }
            string keyFilePath = path.Remove(i, path.Length - i) + "_Kprivate.xml";
            using (StreamWriter writer = new StreamWriter(keyFilePath))
            {
                serializer.Serialize(writer, FKprivate.Item2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "File mã hóa: ")
            {
                MessageBox.Show("Bạn chưa chọn file");
                return;
            }
            if (FKprivate.Item2.D == null)
            {
                MessageBox.Show("Bạn chưa chọn mã hóa");
                return;
            }

            // Lưu Kx + HKprivate vào thư mục giống như file Plain text (.../P_Kx+HKprivate)
            string path = label1.Text.Remove(0, 13);
            int i = path.Length - 1;
            while (path[i] != '.')
            {
                --i;
            }
            path = path.Insert(i, "_Kx+HKprivate");

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(Program.Kx, 0, Program.Kx.Length);
                fs.Write(Program.HKprivate, 0, Program.HKprivate.Length);
            }
        }
    }
}
