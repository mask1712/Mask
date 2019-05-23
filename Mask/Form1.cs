using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceText.Text))
            {
                MessageBox.Show("没数据加毛密-_-!");
                return;
            }
            else
            {
                txtResultText.Text = AESEncryptHelper.Encrypt(txtSourceText.Text);
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceText.Text))
            {
                MessageBox.Show("没数据解毛密-_-!");
                return;
            }
            else if (!IsBase64Formatted(txtSourceText.Text))
            {
                MessageBox.Show("别逗了,我只认识被我加过密的？");
                return;
            }
            else
            {
                txtResultText.Text = AESEncryptHelper.Decrypt(txtSourceText.Text);
            }
        }

        public static bool IsBase64Formatted(string input)
        {
            try
            {
                Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
