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

namespace Library_K300
{
    public partial class LibraryForm : Form
    {
        public LibraryForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            cmbFaculity.Items.Add("Iqtisadiyyat");
            cmbFaculity.Items.Add("Tarix");
            cmbFaculity.Items.Add("Komp.ELmleri");
            cmbFaculity.Items.Add("Tebiet ELmleri");
            cmbFaculity.Items.Add("Psixologiya");
        }

        private void BtnReader_Click(object sender, EventArgs e)
        {
            string firstName = txtFrstName.Text;
            string lastName = txtLastName.Text;
            string phone = txtPhone.Text;
            string faculity = cmbFaculity.Text;
            long newPhone;
            if(firstName!="" && lastName!="" && phone!="" && faculity != "")
            {
                if(long.TryParse(phone,out newPhone))
                {
                    SqlConnection Cont = new SqlConnection(@"Data Source=USER\VQFSQL;Initial Catalog=Library;Integrated Security=True");
                    string comdQuery = $"Insert into Readers Values('{firstName}','{lastName}','{phone}',{2})";
                    SqlCommand Comd = new SqlCommand(comdQuery, Cont);
                    Cont.Open();
                   int result =  Comd.ExecuteNonQuery();
                    if (result >= 1)
                    {
                        MessageBox.Show($"{firstName} was created successfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                    Cont.Close();
                }
                else
                {
                    MessageBox.Show("Phone should be numeric charachter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Butun xanalari doldurun sora basdiyaq","Error", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }
        }
    }
}
