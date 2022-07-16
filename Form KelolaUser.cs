using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_LKS_2022
{
    public partial class Form_KelolaUser : Form
    {
        Function func = new Function();
        public Form_KelolaUser()
        {
            InitializeComponent();
        }
        new void Show()
        {
            dgv_User.DataSource = func.ShowData("SELECT * FROM Tbl_User");
        }

        private void Form_KelolaUser_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbx_TipeUser.Text = dgv_User.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgv_User.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTelpon.Text = dgv_User.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAlamat.Text = dgv_User.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUserName.Text = dgv_User.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPassword.Text = dgv_User.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(cbx_TipeUser.Text == "" || txtName.Text == "" || txtTelpon.Text == "" || txtAlamat.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Seluruh kolom harus di isi!");
            }
            else
            {
                func.Command("INSERT INTO Tbl_User ([Tipe_User], [Nama_User], [Telepon], [Alamat], [Username], [Password]) VAlUES ('" + cbx_TipeUser.Text + "', '" + txtName.Text + "', '" + txtTelpon.Text + "', '" + txtAlamat.Text + "', '" + txtUserName.Text + "', '" + txtPassword.Text + "')");
            }
        }
    }
}
