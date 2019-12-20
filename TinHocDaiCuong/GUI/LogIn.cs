using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinHocDaiCuong.BLL;
using TinHocDaiCuong.DAL;
using TinHocDaiCuong.DTO;

namespace TinHocDaiCuong.GUI
{
    public partial class LogIn : Form
    {
        public SV_BLL bll { get; set; }
        public delegate void delPassData(string text);

        

        public LogIn()
        {
            this.bll = new SV_BLL();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SV s = new SV();
            s.MSSV = txtMSSV_LI.Text;
            s.MatKhau = txtMatKhau_LI.Text;
            
            if (bll.checkSV_BLL(s) == 1)
            {
                this.Hide();
                MainForm mf = new MainForm();
                mf.d(s.MSSV);
                mf.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại");
                //txtMSSV_LI.Text = "";
                txtMatKhau_LI.Text = "";
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtMatKhau_LI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (checkAdmin())
                {
                    this.Close();
                    MainForm mainForm = new MainForm(true);
                    //delPassData del = new delPassData(mainForm.loadFormAdmin);
                    //del(this.txtMSSV_LI.Text.ToString());
                    mainForm.Show();
                    //Application.DoEvents();
                }
                else if (checkUser())
                {
                    //MessageBox.Show(txtMSSV_LI.Text);

                    //MessageBox.Show();
                    SV sV = bll.getSV_BLL(txtMSSV_LI.Text);
                    //MessageBox.Show(sV.Ten);
                    this.Close();
                    MainForm mainForm = new MainForm(false);
                    delPassData del = new delPassData(mainForm.loadForm);
                    del(sV.Ten);
                    mainForm.Show();
                    //Application.DoEvents();

                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai!\n Vui lòng nhập lại.");
                }
            }
        }

        private void button_xemDiem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form_EXCEL eXCEL = new Form_EXCEL();
            eXCEL.ShowDialog();
        }

        Admin admin = new Admin();
        private bool checkAdmin()
        {
            if (txtMSSV_LI.Text.ToUpper() == admin.TenDangNhap.ToString().ToUpper())
            {
                if (txtMatKhau_LI.Text.ToUpper() == admin.MatKhau.ToString().ToUpper())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private bool checkUser()
        {
            SV s = new SV();
            s.MSSV = txtMSSV_LI.Text;
            s.MatKhau = txtMatKhau_LI.Text;

            if (bll.checkSV_BLL(s) == 1)
            {
                //MessageBox.Show("");
                return true;
            }
            else
            {
                //MessageBox.Show("Sai");
                return false;
            }

        }
        private void simpleButton_Login_Click(object sender, EventArgs e)
        {
            if (checkAdmin())
            {
                this.Close();
                MainForm mainForm = new MainForm(true);
                //delPassData del = new delPassData(mainForm.loadFormAdmin);
                //del(this.txtMSSV_LI.Text.ToString());
                mainForm.Show();
                //Application.DoEvents();
            }
            else if (checkUser())
            {
                //MessageBox.Show(txtMSSV_LI.Text);
                
                //MessageBox.Show();
                SV sV = bll.getSV_BLL(txtMSSV_LI.Text);
                //MessageBox.Show(sV.Ten);
                this.Close();
                MainForm mainForm = new MainForm(false);
                delPassData del = new delPassData(mainForm.loadForm);
                del(sV.Ten);
                
                mainForm.Show();
                //Application.DoEvents();
                
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai!\n Vui lòng nhập lại.");
            }

        }
    }
}
