using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_LKS_2022
{
    public partial class Form_Login : Form
    {
        public static string url = @"Data Source=localhost;Initial Catalog=apotek_db;Integrated Security=True";
        SqlConnection con = new SqlConnection(url);
        public Form_Login()
        {
            InitializeComponent();
        }
        void Login()
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Id_User, Tipa_User, Nama_User FROM Tbl_User WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ClassPegawai.NamaPegawai = dr["Nama_User"].ToString();
                        ClassPegawai.IdPegawai = dr["Id_User"].ToString();
                        if (dr["Tipe_User"].ToString() == "admin")
                        {
                            new Form_Admin().Show();
                            this.Hide();
                        }
                        else if (dr["Tipe_User"].ToString() == "apoteker")
                        {

                        }
                        else if (dr["Tipe_User"].ToString() == "kasir")
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Maaf data tidak valid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Harap mengisi username dan password");
            }
            else
            {
                Login();
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Tbl_Log ([waktu], [aktifitas], [Id_User]) VALUES (getDate(), 'login', @id)", con);
                    com.Parameters.AddWithValue("@id", ClassPegawai.IdPegawai);
                    com.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
