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

namespace TinHocDaiCuong.GUI
{
    
    public partial class Add : Form
    {
        public DeThi_BLL DeThi { get; set; }
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = textBox1.Text;
                DeThi.addQuestion(filePath);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Đã thêm thành công!.");
            }
        }
    }
}
