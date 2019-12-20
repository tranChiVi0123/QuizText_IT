using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using TinHocDaiCuong.BLL;
using TinHocDaiCuong.DTO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Data.OleDb;
using System.IO;

namespace TinHocDaiCuong.GUI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public SV_BLL bll { get; set; }
        public DeThi_BLL DeThi { get; set; }
        public delegate void DD(string Message);
        public delegate void delPassData(string text);
        public DD d;
        private string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dt;
        //private float _diem;


        public MainForm()
        {
           
            InitializeComponent();
            ribbonPage1.Visible = false;
            rib3.Visible = false;
            LoadForm();
            gridControl1.Visible = true;
            
        }

        public MainForm(bool check)
        {
            InitializeComponent();

            if (check == true)
            {
                ribbonPage1.Visible = false;
                rib3.Visible = true;
                barStaticItem_Status.Caption = "Admin";
                btnLogin.Enabled = false;
                LoadForm();
            }
            else
            {
                LoadForm();
            }

        }

        #region Các quyền của ADMIN
        public void loadForm(string nameUser)
        {
            ribbonPage1.Visible = true;
            rib3.Visible = false;
            barStaticItem_Status.Caption = nameUser;
            label6.Text = nameUser;
            btnLogin.Enabled = false;

        }
        
        public void loadID(string ID)
        {
            //label_mssv.Text = ID;
        }


        private void btnThi_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Điểm của bạn là :" +_diem);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            this.Hide();
            li.ShowDialog();
            this.Dispose();
        }
        private void LoadLabel(string s)
        {
            SV sv = bll.getSV_BLL(s);
            //lblMSSV_MF.Text = sv.MSSV;
            //lblTen_MF.Text = sv.Ten;
            //lblLop_MF.Text = sv.Lop;

        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }
        //load form final
        private void LoadForm()
        {
            gridControl1.Visible = false;
            gridControl_cauHoi.Visible = false;
            gridControl_PhienThi.Visible = false;
            gridControl_SV.Visible = false;
            gridControl_diem.Visible = false;
            //gridControl_diem.Visible = false;

            gridControl1.Dock = DockStyle.Fill;
            gridControl_cauHoi.Dock = DockStyle.Fill;
            gridControl_SV.Dock = DockStyle.Fill;
            gridControl_PhienThi.Dock = DockStyle.Fill;
            //gridControl_diem.Dock = DockStyle.Fill;

            groupControl1.Visible = false;
            dateTimePicker1.Visible = false;
            label5.Visible = false;



        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cuoiKiDataSet12.PhienThi' table. You can move, or remove it, as needed.
            this.phienThiTableAdapter4.Fill(this.cuoiKiDataSet12.PhienThi);
            // TODO: This line of code loads data into the 'cuoiKiDataSet11.PhienThi' table. You can move, or remove it, as needed.
            this.phienThiTableAdapter3.Fill(this.cuoiKiDataSet11.PhienThi);
            // TODO: This line of code loads data into the 'cuoiKiDataSet10.PhienThi' table. You can move, or remove it, as needed.
            //this.phienThiTableAdapter2.Fill(this.cuoiKiDataSet10.PhienThi);
            // TODO: This line of code loads data into the 'cuoiKiDataSet9.PhienThi' table. You can move, or remove it, as needed.
            //this.phienThiTableAdapter1.Fill(this.cuoiKiDataSet9.PhienThi);
            // TODO: This line of code loads data into the 'cuoiKiDataSet8.getAllSV' table. You can move, or remove it, as needed.
            this.getAllSVTableAdapter.Fill(this.cuoiKiDataSet8.getAllSV);
            // TODO: This line of code loads data into the 'cuoiKiDataSet6.GetALLDeThi' table. You can move, or remove it, as needed.
            this.getALLDeThiTableAdapter.Fill(this.cuoiKiDataSet6.GetALLDeThi);
            // TODO: This line of code loads data into the 'cuoiKiDataSet5.SV' table. You can move, or remove it, as needed.
            this.sVTableAdapter1.Fill(this.cuoiKiDataSet5.SV);
            // TODO: This line of code loads data into the 'cuoiKiDataSet4.SV' table. You can move, or remove it, as needed.
            this.sVTableAdapter.Fill(this.cuoiKiDataSet4.SV);
            // TODO: This line of code loads data into the 'cuoiKiDataSet3.PhienThi' table. You can move, or remove it, as needed.
            //this.phienThiTableAdapter.Fill(this.cuoiKiDataSet3.PhienThi);
            gridControl1.RefreshDataSource();
            gridControl1.Visible = true;
            gridControl1.Dock = DockStyle.Fill;
            groupControl1.Visible = false;
            gridControl_cauHoi.Visible = false;
            gridControl_SV.Visible = false;
            gridControl_PhienThi.Visible = false;
            string query = "SELECT * FROM PhienThi";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridControl1.DataSource = null;
            gridControl1.DataSource = dt;


        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        //Show Câu Hỏi
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_cauHoi.Visible = true;
        }

        //Show Sinh Viên
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            groupControl1.Visible = true;
            label1.Text = "MSSV";
            label2.Text = "Tên SV";
            label3.Text = "Mã Lớp";
            label4.Text = "Password";
            simpleButton_edit.Text = "EDIT";
            //gridControl_SV.Visible = true;
            //Form_Grid_Load();
            string query = "GetAllSV";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        //Thêm câu hỏi
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        //Thêm sinh viên 
        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            groupControl1.Visible = true;
            label1.Text = "MSSV";
            label2.Text = "Tên SV";
            label3.Text = "Mã Lớp";
            label4.Text = "Password";
            simpleButton_edit.Text = "ADD";
            //gridControl_SV.Visible = true;
            //Form_Grid_Load();
            string query = "GetAllSV";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        //LoadFormSV
        private void Form_Grid_Load()
        {
            string query = "GetAllSV";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dataGridView.Columns.Add(Deletelink);

        }

        //Update
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

        }

        //sừa trên cell datagridview
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                string mssv = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells["MSSV"].Value);
                string name = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells["Tên SV"].Value);
                string lop = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells["Mã Lớp"].Value);
                string matkhau = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells["Password"].Value);
                string query = ("updateSV @name = N'" + name + "' @maLop = " + lop + " @pass= " + matkhau + " @id = " + mssv).ToString();
                SqlConnection connection;
                string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Update(dt);
                dataGridView.DataSource = null;
                dataGridView.DataSource = dt;
            }

        }

        

        //reload
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.RefreshDataSource();
            gridControl1.Visible = true;
            gridControl1.Dock = DockStyle.Fill;
            groupControl1.Visible = false;
            gridControl_cauHoi.Visible = false;
            gridControl_SV.Visible = false;
            gridControl_PhienThi.Visible = false;
            string query = "SELECT * FROM PhienThi";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridControl1.DataSource = null;
            gridControl1.DataSource = dt;

        }

        //public GridViewOptionsFind OptionsFind { get; }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   
            //GridViewOptionsFind gridView = gridControl1.
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_PhienThi.Dock = DockStyle.Fill;
            gridControl1.Visible = false;
            gridControl_SV.Visible = false;
            groupControl1.Visible = true;
            simpleButton_edit.Text = "EDIT";
            //gridControl_PhienThi.Visible = true;

            //groupControl1.Visible = true;
            dateTimePicker1.Visible = true;
            label5.Visible = true;
            label5.Text = "Ngày Thi";
            label1.Text = "Phiên Thi";
            label2.Text = "Mã Lớp";
            label3.Text = "Phòng Thi";
            label4.Text = "Giờ Thi";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;

            string query = "SELECT * FROM PhienThi";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;




        }

        //update tất cả dữ liệu vào sql
        private void barButtonItem_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateGridControl1();
        }

        private void updateGridControl1()
        {
            ColumnView view = (ColumnView)gridControl1.FocusedView;
            if (view.IsEditing)
                view.HideEditor();
            view.CancelUpdateCurrentRow();
        }
        //xem diem
        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            //gridControl_diem.Visible = true;
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //rowcells
        int rowIndex;
        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (!label5.Visible)
            {
                textBox1.Text = dataGridView.SelectedRows[0].Cells["MSSV"].Value.ToString();
                textBox2.Text = dataGridView.SelectedRows[0].Cells["Tên SV"].Value.ToString();
                textBox3.Text = dataGridView.SelectedRows[0].Cells["Mã Lớp"].Value.ToString();
                textBox4.Text = dataGridView.SelectedRows[0].Cells["Password"].Value.ToString();
            }
            else
            {
                textBox1.Text = dataGridView.SelectedRows[0].Cells["Phiên Thi"].Value.ToString();
                textBox2.Text = dataGridView.SelectedRows[0].Cells["Mã Lớp"].Value.ToString();
                textBox3.Text = dataGridView.SelectedRows[0].Cells["Phòng Thi"].Value.ToString();
                textBox4.Text = dataGridView.SelectedRows[0].Cells["Giờ Bắt Đầu"].Value.ToString();
                


            }
        }

        //EDIT & ADD Button
        private void simpleButton_edit_Click(object sender, EventArgs e)
        {
            int r = rowIndex;
            if (!label5.Visible && simpleButton_edit.Text == "EDIT")
            {
                try
                {
                    string query = "capNhatSV @name = N'" + textBox2.Text + "', @class = '" + textBox3.Text + "', @pass = '" + textBox4.Text + "', @id = '" + textBox1.Text + "'";
                    SqlConnection connection;
                    string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch(Exception e1)
                {
                    MessageBox.Show("Không đúng định dạng.");
                }
            }else if(label5.Visible && simpleButton_edit.Text == "EDIT")
            {
                try
                {
                    string query = "capNhatPT @phien = '" + textBox1.Text + "', @class = '" + textBox2.Text + "', @room = '" + textBox3.Text + "', @date = '" + dateTimePicker1.Value + "', @time = '" + textBox4.Text + "'";
                    SqlConnection connection;
                    string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }catch(Exception e2)
                {
                    MessageBox.Show("Không đúng định dạng.");
                }
            }else if (!label5.Visible && simpleButton_edit.Text == "ADD")
            {
                try
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null)
                    {
                        string query = "themSV @id = '" + textBox1.Text + "', @name = N'" + textBox2.Text + "', @class = '" + textBox3.Text + "', @pass = '" + textBox4.Text + "'";
                        SqlConnection connection;
                        string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    }
                }
                catch(Exception e3)
                {
                    MessageBox.Show("Không đúng định dạng.\n Vui lòng kiểm tra lại!");
                }
            }
            else if (label5.Visible && simpleButton_edit.Text == "ADD")
            {
                try
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null)
                    {
                        string query = "themPT @phien = '" + textBox1.Text + "', @class = '" + textBox2.Text + "', @room = '" + textBox3.Text + "', @date = '" + dateTimePicker1.Value.ToString() + "', @time = '"+textBox4.Text+"'";
                        SqlConnection connection;
                        string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    }
                }
                catch (Exception e4)
                {
                    MessageBox.Show("Không đúng định dạng.\n Vui lòng kiểm tra lại!");
                }
            }

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        //int rowIndex;
        private void gridControl_SV_ProcessGridKey(object sender, KeyEventArgs e)
        {
           
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;
            if (e.KeyCode == Keys.Delete && e.Control && view.Editable && view.SelectedRowsCount > 0)
            {
                if (view.ActiveEditor != null) return; //Prevent record deletion when an in-place editor is invoked
                e.Handled = true;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Record deletion", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    view.DeleteSelectedRows();
            }
            
        }

        private void gridViewSV_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            string query = "getAllSV";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
        }

       
        private void gridViewSV_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //rowIndex = e.Handled

        }
        //gán giá trị mặc định cho sinh viên
        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Ngày Thi"].Value = "01-01-2000";
            e.Row.Cells["Giờ Bắt Đầu"].Value = "0 AM";
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        //thêm phiên thi
        private void btnAddSessions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_PhienThi.Dock = DockStyle.Fill;
            gridControl1.Visible = false;
            gridControl_SV.Visible = false;
            groupControl1.Visible = true;
            simpleButton_edit.Text = "ADD";
            //gridControl_PhienThi.Visible = true;

            //groupControl1.Visible = true;
            dateTimePicker1.Visible = true;
            label5.Visible = true;
            label5.Text = "Ngày Thi";
            label1.Text = "Phiên Thi";
            label2.Text = "Mã Lớp";
            label3.Text = "Phòng Thi";
            label4.Text = "Giờ Thi";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }
        #endregion

        #region CacLop
        //16T1
        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '16T1'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;

        }
        //16T2
        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '16T2'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //16T3
        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '16T3'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }

        //15T1
        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '15T1'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //15T2
        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '15T2'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //15T3
        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '15T3'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //14T1
        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '14T1'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //14T2
        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '14T3'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        //14T3
        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            gridControl_diem.Visible = true;
            gridControl_diem.Dock = DockStyle.Fill;
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '14T3'";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            adapter.Fill(dt);

            gridControl_diem.DataSource = dt;
        }
        #endregion

        #region Xữ lý User
        private bool CheckDaThi()
        {
            SV sV = new SV();
            //
            if (sV.diem == null)
            {
                return false;
            }
            else
                return true;
        }
        
        //UserThi
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckDaThi())
            {
                try
                {

                    Exam exam = new Exam();
                    delPassData del = new delPassData(exam.LoadLabel);
                    del(label6.Text);
                    exam.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else
            {
                MessageBox.Show("Bạn đã hoàn thành bài thi!");
            }
        }
        // xem diem tai user
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckDaThi())
            {

            }
            else
            {
                MessageBox.Show("Bạn chưa hoàn thành bài thi!");
            }
        }
        #endregion


        #region Thao tác với EXCEL và thêm một SV
        //export excel
        private void Export(DataTable dt, string sheetName, string title)
        {
            //Tao cac doi tuong Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;
            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range tenTruong = oSheet.get_Range("A1", "B1");
            tenTruong.MergeCells = true;
            tenTruong.Value2 = "ĐẠI HỌC ĐÀ NẴNG";
            tenTruong.Font.Name = "Tahoma";
            tenTruong.Font.Size = "10";
            tenTruong.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range tenBK = oSheet.get_Range("A2", "B2");
            tenBK.MergeCells = true;
            tenBK.Value2 = "TRƯỜNG ĐẠI HỌC BÁCH KHOA";
            tenBK.Font.Name = "Tahoma";
            tenBK.Font.Underline = true;
            tenBK.Font.Size = "10";
            tenBK.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range congHoa = oSheet.get_Range("C1", "E1");
            congHoa.MergeCells = true;
            congHoa.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            congHoa.Font.Name = "Tahoma";
            congHoa.Font.Size = "10";
            congHoa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range docLap = oSheet.get_Range("C2", "E2");
            docLap.MergeCells = true;
            docLap.Value2 = "Độc lập - Tự do - Hạnh phúc";
            docLap.Font.Name = "Tahoma";
            docLap.Font.Underline = true;
            docLap.Font.Size = "10";
            docLap.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A4", "E4");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Lop

            Microsoft.Office.Interop.Excel.Range lop = oSheet.get_Range("A7", "B7");

            lop.MergeCells = true;

            lop.Value2 = "LỚP : .............";

            lop.Font.Bold = false;

            lop.Font.Name = "Tahoma";

            lop.Font.Size = "10";

            lop.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //Giang Vien
            Microsoft.Office.Interop.Excel.Range giangVien = oSheet.get_Range("C7", "E7");
            giangVien.MergeCells = true;
            giangVien.Value2 = "GIẢNG VIÊN: .............";
            giangVien.Font.Name = "Tahoma";
            giangVien.Font.Size = "10";
            giangVien.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Hoc Phan
            Microsoft.Office.Interop.Excel.Range hocPhan = oSheet.get_Range("A8", "B8");
            hocPhan.MergeCells = true;
            hocPhan.Value2 = "HỌC PHẦN: .............";
            hocPhan.Font.Name = "Tahoma";
            hocPhan.Font.Size = "10";
            hocPhan.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //ngay thi
            Microsoft.Office.Interop.Excel.Range ngayThi = oSheet.get_Range("C8", "E8");
            ngayThi.MergeCells = true;
            ngayThi.Value2 = "NGÀY THI: .............";
            ngayThi.Font.Name = "Tahoma";
            ngayThi.Font.Size = "10";
            ngayThi.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Phong Dao Tao
            Microsoft.Office.Interop.Excel.Range phongDaoTao = oSheet.get_Range("A9", "B9");
            phongDaoTao.MergeCells = true;
            phongDaoTao.Value2 = "PHÒNG ĐÀO TẠO: .............";
            phongDaoTao.Font.Name = "Tahoma";
            phongDaoTao.Font.Size = "10";
            phongDaoTao.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Phong Thi
            Microsoft.Office.Interop.Excel.Range phongThi = oSheet.get_Range("C9", "E9");
            phongThi.MergeCells = true;
            phongThi.Value2 = "PHÒNG THI: .............";
            phongThi.Font.Name = "Tahoma";
            phongThi.Font.Size = "10";
            phongThi.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A11", "A11");

            cl1.Value2 = "MSSV";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B11", "B11");

            cl2.Value2 = "Tên Sinh Viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C11", "C11");

            cl3.Value2 = "Mã Lớp";

            cl3.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D11", "D11");

            cl4.Value2 = "Đề Thi";

            cl4.ColumnWidth = 13.5;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E11", "E11");
            cl5.Value2 = "Điểm";

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A11", "E11");

            rowHead.Font.Bold = true;
            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu

            int rowStart = 12;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range truongKhoa = oSheet.get_Range("A40", "B40");
            truongKhoa.MergeCells = true;
            truongKhoa.Value2 = "TRƯỞNG KHOA/BỘ MÔN";
            truongKhoa.Font.Name = "Tahoma";
            truongKhoa.Font.Size = "10";
            truongKhoa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range daNang = oSheet.get_Range("C40", "E40");
            daNang.MergeCells = true;
            daNang.Value2 = "ĐÀ NẴNG, Ngày.......Tháng.......Năm.....";
            daNang.Font.Name = "Tahoma";
            daNang.Font.Size = "10";
            daNang.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range canBo = oSheet.get_Range("C41", "E41");
            canBo.MergeCells = true;
            canBo.Value2 = "CÁN BỘ COI THI";
            canBo.Font.Name = "Tahoma";
            canBo.Font.Size = "10";
            canBo.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        //them vao excel
        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm main = new MainForm();
            DataTable dt = new DataTable();
            dt = gridControl_diem.DataSource as DataTable;
            main.Export(dt, "Danh Sach", "DANH SÁCH THI CUỐI KỲ VÀ BÀI TẬP");
        }

        //Thêm 1 người
        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            groupControl1.Visible = true;
            label1.Text = "MSSV";
            label2.Text = "Tên SV";
            label3.Text = "Mã Lớp";
            label4.Text = "Password";
            simpleButton_edit.Text = "ADD";
            //gridControl_SV.Visible = true;
            //Form_Grid_Load();
            string query = "GetAllSV";
            SqlConnection connection;
            string connectionString = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        // SHow SV từ Excel
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofdSelect = new OpenFileDialog();
            ofdSelect.ShowDialog();
            string filePath = ofdSelect.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = "";
            string sheetName = "";
            switch (extension)
            {
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString();
                    con.Close();
                }
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    con.Close();
                    LoadForm();
                    dataGridView.DataSource = dt;

                }
            }
        }

        //Insert data to Excel
        private void barButtonItem_excelup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4]{
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Tên SV",typeof(string)),
                new DataColumn("Mã Lớp",typeof(string)),
                new DataColumn("Password",typeof(string))
            });
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string ID = Convert.ToString(row.Cells[0].Value);
                string name = Convert.ToString(row.Cells[1].Value);
                string lop = Convert.ToString(row.Cells[2].Value);
                string pass = Convert.ToString(row.Cells[3].Value);
                dt.Rows.Add(ID, name, lop,pass);
            }
            if (dt.Rows.Count > 0)
            {
                //string str = ConfigurationManager.ConnectionStrings[@"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True"].ConnectionString;
                string str = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        try
                        {
                            sqlBulkCopy.DestinationTableName = "dbo.SV";
                            sqlBulkCopy.ColumnMappings.Add("MSSV", "MSSV");
                            sqlBulkCopy.ColumnMappings.Add("Tên SV", "Tên SV");
                            sqlBulkCopy.ColumnMappings.Add("Mã Lớp", "Mã Lớp");
                            sqlBulkCopy.ColumnMappings.Add("Password", "Password");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                            MessageBox.Show("Đã Copy vào SQL_Server.");
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            //MessageBox.Show("Mã sinh viên không hợp lệ.\n Vui lòng kiểm tra lại dữ liệu.");
                        }
                    }
                }
            }
        }
        #endregion
        
        
    }
}
