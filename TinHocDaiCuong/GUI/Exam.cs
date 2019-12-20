using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinHocDaiCuong.BLL;
using TinHocDaiCuong.DTO;

namespace TinHocDaiCuong.GUI
{
    public partial class Exam : Form
    {
        public SV_BLL bll { get; set; }
        public DeThi_BLL DeThi_BLL { get; set; }

        private int h = 0;
        private int m = 30;
        private int s = 0;
        public const int COOL_DOWN_STEP = 1000;
        public const int COOL_DOWN_TIME = (30 * 60 *1000);
        public const int COOL_DOWN_INTERVAL = 100;
        private int viTri, nopBai = 0;
        private ArrayList ranCauHoi = new ArrayList();
        private string[] chon = new string[20];
        private string[,] ranDapAn = new string[20, 4];
        private float diem;
        private DataTable dt;

        


        public delegate void DD(string Message);
        public DD d;

        public Exam()
        {
            InitializeComponent();
            //CreateButton_CH();
            //Xu_Li_To_Mau();

            bll = new SV_BLL();
            DeThi_BLL = new DeThi_BLL();
            dt = DeThi_BLL.Get_DeThi_BLL();
            d = new DD(LoadLabel);

            pgCountDown.Step = COOL_DOWN_STEP;
            pgCountDown.Maximum = COOL_DOWN_TIME;
            pgCountDown.Value = 0;
            

            timer1.Interval = 1000;

            timer2.Interval = 1000;

            timer1.Start();
            timer2.Start();


            Load_DeThi(1);


        }
        private void Load_DeThi(int type)
        {

            button_NEXT.Enabled = viTri == 19 ? false : true;
            Random ran = new Random();
            while (ranCauHoi.Count < 20)
            {
                int i = ran.Next(0, dt.Rows.Count);

                if (i % 4 == 0)
                {
                    if (!ranCauHoi.Contains(i))
                    {
                        ranCauHoi.Add(i);
                    }
                }
            }
            //blCauHoi.Text = lblCauHoi.Text.Remove(lblCauHoi.Text.IndexOf(""));
            //lblCauHoi.Text = lblCauHoi.Text.Remove(lblCauHoi.Text.IndexOf(" ") + 1);
            lblSTT.Text = "Câu : "+(viTri + 1).ToString();
            lblCauHoi.Text = dt.Rows[(Int32)ranCauHoi[viTri]]["Nội dung"].ToString();
            /*ArrayList da = new ArrayList();
            while (da.Count < 4)
            {
                int a = ran.Next(0, 4);
              
                    if (!da.Contains(a))
                    {
                        da.Add(a);
                    }
                
            }*/

            radDapAn1.Text = dt.Rows[(Int32)ranCauHoi[viTri]+0]["Nội dung đáp án"].ToString();
            ranDapAn[viTri, 0] = dt.Rows[(Int32)ranCauHoi[viTri] + 0]["Mã đáp án"].ToString();
            //radDapAn1.Checked = false;

            radDapAn2.Text = dt.Rows[(Int32)ranCauHoi[viTri]+1]["Nội dung đáp án"].ToString();
            ranDapAn[viTri, 1] = dt.Rows[(Int32)ranCauHoi[viTri] + 1]["Mã đáp án"].ToString();
            //radDapAn2.Checked = false;

            radDapAn3.Text = dt.Rows[(Int32)ranCauHoi[viTri]+2]["Nội dung đáp án"].ToString();
            ranDapAn[viTri, 2] = dt.Rows[(Int32)ranCauHoi[viTri] + 2]["Mã đáp án"].ToString();
            //radDapAn3.Checked = false;

            radDapAn4.Text = dt.Rows[(Int32)ranCauHoi[viTri]+3]["Nội dung đáp án"].ToString();
            ranDapAn[viTri, 3] = dt.Rows[(Int32)ranCauHoi[viTri] + 3]["Mã đáp án"].ToString();
            //radDapAn4.Checked = false;

            Xu_Ly_Da_Chon();
            //CreateButton_CH();
            
           
        }
        

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            //MessageBox.Show(chon[viTri].ToString() + " " + dt.Rows[(Int32)ranCauHoi[viTri]]["Mã đáp án đúng"].ToString());

            string mssv = lblMSSV_E.Text;
            int mch = Convert.ToInt32(lblMaDeThi_E.Text);
            DeThi_BLL.Luu_diem_BLL(mssv, diem = TinhDiem());
            ket_Thuc_Thi();
            
            
        }
        
        public void LoadLabel(string s)
        {
            SV sv = bll.GetSVbyName_BLL(s);
            lblMSSV_E.Text = sv.MSSV;
            lblTen_E.Text = sv.Ten;
            lblLop_E.Text = sv.Lop;
            lblMaDeThi_E.Text = dt.Rows[1]["Đề Thi"].ToString();
        }
        

        private void lblThoiGian_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pgCountDown.PerformStep();
            if (pgCountDown.Value >= pgCountDown.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Hết giờ!");
                string mssv = lblMSSV_E.Text;
                int mch = Convert.ToInt32(lblMaDeThi_E.Text);
                DeThi_BLL.Luu_diem_BLL(mssv, diem = TinhDiem());
                ket_Thuc_Thi();
            }
            
        }

        /*private void CreateButton_CH()
        {
            int Top = 10;
            for(int i = 0; i < 2; i++)
            {
                int Left = 10;
                for(int j = 0; j < 10; j++)
                {
                    Button button = new Button();
                    button.Name = string.Format("bt_{0}", i * 10 + j + 1);
                    button.Tag = string.Format("[{0}, {1}]", i, j);
                    button.Text = string.Format("{0}", i * 10 + j + 1);
                    button.Size = new Size(50, 30);
                    if (chon[viTri] != null)
                        button.BackColor = Color.Green;
                    else
                        button.BackColor = Color.Gray;
                    
                    

                    button.ForeColor = Color.White;
                    

                    button.Top = Top;
                    button.Left = Left;
                    Left += 52;

                    button.Click += new EventHandler(button_Click);

                    groupBox_CH.Controls.Add(button);
                }
                Top += 30;
            }
        }*/

        private void button_NEXT_Click(object sender, EventArgs e)
        {
            viTri++;
            Load_DeThi(0);
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            

            if (h== 0 && m== 0 && s == 0)
            {
                timer2.Stop();
                
            }
            else
            {
                if (s< 1)
                {
                    s = 59;
                    if (m< 1)
                    {
                        m= 59;
                        if (h != 0)
                            h -= 1;
                    }
                    else m-= 1;

                }
                else s -= 1;
                if (h > 9)
                    lb_hour.Text = h.ToString();
                else lb_hour.Text = "0" + h.ToString();
                if (m > 9)
                    lb_min.Text = m.ToString();
                else lb_min.Text = "0" + m.ToString();
                if (s > 9)
                    lb_sec.Text = s.ToString();
                else lb_sec.Text = "0" + s.ToString();
            }



        }

        /*private void button_Click(object sender, EventArgs e)
        {
            viTri = Convert.ToInt32(((Button)sender).Text) - 1;
            Load_DeThi(2);
           
        }*/

        private float TinhDiem()
        {
            int cauDung = 0;
            float diem = 0;
            for(int i = 0; i < 20; i++)
            {
                if (chon[i] == null)
                    continue;
                if (dt.Rows[(Int32)ranCauHoi[i]]["Mã đáp án đúng"].ToString().Equals(chon[i]))
                    cauDung++;
            }
            diem = ((float)cauDung * 10) / 20;
            return diem;

            
        }

        private void Xu_Ly_Da_Chon()
        {
            if (chon[viTri] != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (ranDapAn[viTri, i].Equals(chon[viTri]))
                    {
                        switch (i)
                        {
                            case 0:
                                radDapAn1.Checked = true;
                                break;
                            case 1:
                                radDapAn2.Checked = true;
                                break;
                            case 2:
                                radDapAn3.Checked = true;
                                break;
                            case 3:
                                radDapAn4.Checked = true;
                                break;
                        }
                    }
                }
            }
            else
            {
                radDapAn1.Checked = false;
                radDapAn2.Checked = false;
                radDapAn3.Checked = false;
                radDapAn4.Checked = false;

            }
        }

        private void Xu_Li_To_Mau()
        {
            if (chon[0] != null)
                button1.BackColor = Color.Green;
            if (chon[1] != null)
                button2.BackColor = Color.Green;
            if (chon[2] != null)
                button3.BackColor = Color.Green;
            if (chon[3] != null)
                button4.BackColor = Color.Green;
            if (chon[4] != null)
                button5.BackColor = Color.Green;
            if (chon[5] != null)
                button6.BackColor = Color.Green;
            if (chon[6] != null)
                button7.BackColor = Color.Green;
            if (chon[7] != null)
                button8.BackColor = Color.Green;
            if (chon[8] != null)
                button9.BackColor = Color.Green;
            if (chon[9] != null)
                button10.BackColor = Color.Green;
            if (chon[10] != null)
                button11.BackColor = Color.Green;
            if (chon[11] != null)
                button12.BackColor = Color.Green;
            if (chon[12] != null)
                button13.BackColor = Color.Green;
            if (chon[13] != null)
                button14.BackColor = Color.Green;
            if (chon[14] != null)
                button15.BackColor = Color.Green;
            if (chon[15] != null)
                button16.BackColor = Color.Green;
            if (chon[16] != null)
                button17.BackColor = Color.Green;
            if (chon[17] != null)
                button18.BackColor = Color.Green;
            if (chon[18] != null)
                button19.BackColor = Color.Green;
            if (chon[19] != null)
                button20.BackColor = Color.Green;

        }


        private void ket_Thuc_Thi()
        {
            this.Hide();
            diem = TinhDiem();
            //MainForm main = new MainForm(diem);
            SV sv = new SV();
            sv.MSSV = lblMSSV_E.Text;
            //main.d(sv.MSSV);
            //main.ShowDialog();
        }

        #region RadChecked
        private void radDapAn1_CheckedChanged(object sender, EventArgs e)
        {
            chon[viTri] = dt.Rows[(Int32)ranCauHoi[viTri] + 0]["Mã đáp án"].ToString();
            //MessageBox.Show(chon[viTri].ToString());
        }

        private void radDapAn2_CheckedChanged(object sender, EventArgs e)
        {
            chon[viTri] = dt.Rows[(Int32)ranCauHoi[viTri] + 1]["Mã đáp án"].ToString();
            //MessageBox.Show(chon[viTri].ToString());

        }

        private void radDapAn3_CheckedChanged(object sender, EventArgs e)
        {
            chon[viTri] = dt.Rows[(Int32)ranCauHoi[viTri] + 2]["Mã đáp án"].ToString();
            //MessageBox.Show(chon[viTri].ToString());

        }

        private void radDapAn4_CheckedChanged(object sender, EventArgs e)
        {
            chon[viTri] = dt.Rows[(Int32)ranCauHoi[viTri] + 3]["Mã đáp án"].ToString();
            //MessageBox.Show(chon[viTri].ToString());

        }
        #endregion
        #region xulibutton
        private void button1_Click(object sender, EventArgs e)
        {
            viTri = 1-1;
            Load_DeThi(0);
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            viTri = 2-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viTri = 3-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            viTri = 4-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viTri = 5-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viTri = 6-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viTri = 7-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            viTri = 8-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = false;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            viTri = 9-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = false;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            viTri = 10-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = false;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            viTri = 11-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = false;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            viTri = 12-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = false;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            viTri = 13-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = false;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            viTri = 14-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = false;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            viTri = 15-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = false;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            viTri = 16-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = false;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            viTri = 17-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = false;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            viTri = 18-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = false;
            button19.Enabled = true;
            button20.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            viTri = 19-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = false;
            button20.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            viTri = 20-1;
            Load_DeThi(0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = false;
        }
        #endregion
      
    }
}
