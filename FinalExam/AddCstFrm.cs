using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalExam
{
    public partial class AddCstFrm : Form
    {
        public AddCstFrm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        
            {
                
                Customer cust = new Customer();
                cust.Title = cmbTitle.Text;
                cust.FirstName = txtFirstName.Text;
                cust.LastName = txtLastName.Text;
                cust.DateOfBirth = dtpBirthDate.Value;

                CustomerDB.AddCustomer(cust);
                MessageBox.Show("Customer Add!");
                New_Customer = cust;

                DialogResult = DialogResult.OK;
                Close();
            }
        public Customer New_Customer { get; set; }
    }
 }
