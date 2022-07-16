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
    public partial class Form_Admin : Form
    {
        Function func = new Function();
        public Form_Admin()
        {
            InitializeComponent();
        }
        new void Show()
        {
            
        }

        private void Form_Admin_Load(object sender, EventArgs e)
        {
            dgv_Log.DataSource = func.ShowData("SELECT Tbl_Log.Id_log, Tbl_User.Username, Tbl_Log.waktu, Tbl_Log.aktifitas FROM Tbl_Log INNER JOIN Tbl_User ON Tbl_Log.Id_User = Tbl_User.Id_User");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgv_Log.DataSource = func.ShowData("SELECT Tbl_Log.Id_log, Tbl_User.Username, Tbl_Log.waktu, Tbl_Log.aktifitas FROM Tbl_Log INNER JOIN Tbl_User ON Tbl_Log.Id_User = Tbl_User.Id_User WHERE waktu = '" + dateTimePicker.Text + "'");
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            new Form_KelolaUser().Show();
            this.Hide();
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
            new Form_KelolaObat().Show();
            this.Hide();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            new Form_Laporan().Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Hide();
        }
    }
}
