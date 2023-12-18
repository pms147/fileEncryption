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
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if(FilePath.Text == "File giải mã: ")
            {
                MessageBox.Show("Bạn chưa chọn file giải mã");
                return;
            }
            if(KeyPath.Text == "File Kprivate: ")
            {
                MessageBox.Show("Bạn chưa chọn file Key");
                return;
            }
            // Load Kprivate từ file
            RSAParameters Kprivate = new RSAParameters();
            string path = KeyPath.Text.Remove(0, "File Kprivate: ".Length);
            XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
            using (StreamReader reader = new StreamReader(path))
            {
                Kprivate = (RSAParameters)serializer.Deserialize(reader);
            }

            // So sánh Giá trị hash SHA-1 của Kprivate và HKprivate
            if (!CompareByteArray(Program.HKprivate, SHA.SHA_1(Kprivate.D)))
            {
                MessageBox.Show("Giá trị hash SHA-1 của Kprivate không trùng với HKprivate");
                return;
            }

            // Giải mã ciphertext (C)
            path = FilePath.Text.Remove(0, "File giải mã: ".Length);

            byte[] C = File.ReadAllBytes(path);

            byte[] Ks = Rsa.decrypt_RSA(Program.Kx, Kprivate);
            string P = AES.decrypt_AES(C, Ks, Program.IV);

            // Lưu file đã được giải mã
            path = FilePath.Text.Remove(0, "File giải mã: ".Length);
            int i = path.Length - 1;
            while (path[i] != '.')
            {
                --i;
            }
            path = path.Insert(i, "_decrypt");
            File.WriteAllText(path, P);

            MessageBox.Show("Giải mã thành công");
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath.Text = "File giải mã: " + ofd.FileName;
            }
        }

        private void ChooseKey(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                KeyPath.Text = "File Kprivate: " + ofd.FileName;
            }
        }


        public bool CompareByteArray(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                return false;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                    return false;
            }
            return true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
