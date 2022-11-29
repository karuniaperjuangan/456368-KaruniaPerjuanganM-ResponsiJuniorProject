using Npgsql;
using System.Data;

namespace ResponsiJuniorProject
{
    public partial class Awal : Form
    {
        NpgsqlConnection conn= new NpgsqlConnection("Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=respongsijuang");
        
        public Awal()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT \"id_karyawan\",\"nama\",\"nama_dep\" FROM \"karyawan\" LEFT JOIN departemen ON departemen.id_dep = \"karyawan\".id_dept;";
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void InsertData()
        {
            try
            {
                
                var karyawan = new Karyawan(txtName.Text, txtDept.Text);
                if (string.IsNullOrEmpty(karyawan.Name) || string.IsNullOrEmpty(karyawan.IdDept)) { MessageBox.Show("Semua kolom wajib diisi"); return; }
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO \"karyawan\" (nama,id_dept) VALUES ('{karyawan.Name}','{karyawan.IdDept}');";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }

        private void EditData()
        {
            try
            {
                var karyawanID = int.Parse(txtID.Text);

                var karyawan = new Karyawan(txtName.Text, txtDept.Text);
                if (string.IsNullOrEmpty(karyawan.Name) || string.IsNullOrEmpty(karyawan.IdDept)) { MessageBox.Show("Semua kolom wajib diisi"); return; }
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE \"karyawan\" SET nama='{karyawan.Name}',id_dept='{karyawan.IdDept}' WHERE \"karyawan\".id_karyawan={karyawanID};";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }

        private void DeleteData()
        {
            try
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"DELETE FROM \"karyawan\" WHERE \"karyawan\".id_karyawan={txtID.Text};";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                LoadData();
            }
        }

        private void Awal_Load(object sender, EventArgs e)
        {
            

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();   
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
    }
}