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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulatecmbCustomers();
            PopulateBooksList();

        }

        private void PopulateBooksList()
        {
            List<Book> booksList = BookDB.GetAllBooks();
            cmbBooks.DataSource = booksList;
            cmbBooks.DisplayMember = nameof(Book.Title);
        }

        private void PopulatecmbCustomers()
        {
            List<Customer> customersList = CustomerDB.GetAllCustomers();
            cmbCustomers.DataSource = customersList;
            cmbCustomers.DisplayMember = nameof(Customer.FullName);
        }



        private void btnAddCust_Click(object sender, EventArgs e)
        {
            AddCstFrm addCust = new AddCstFrm();
            DialogResult result = addCust.ShowDialog();

            if (result == DialogResult.OK)
            {
                PopulatecmbCustomers();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FrmAddBook addBook = new FrmAddBook();
            DialogResult result = addBook.ShowDialog();

            if (result == DialogResult.OK)
            {
                PopulateBooksList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Book selbook =
                cmbBooks.SelectedItem as Book;
            if (BookDB.DeleteBook(selbook.BookInfo))
            {
                PopulateBooksList();
            }
        }

        private void btnRegBook_Click_1(object sender, EventArgs e)
        {
            
            Book selbook =
               cmbBooks.SelectedItem as Book;
            Customer selCust =
                cmbCustomers.SelectedItem as Customer;
            BookRegistration selReg =
                new BookRegistration();
            selReg.CustomerID = selCust.CustomerID;
            selReg.ISBN = selbook.ISBN;
            selReg.RegDate = dtpDate.Value;

            BookRegistrationDB.Registration(selReg);
            MessageBox.Show("Registration completed!");


        }

      
    }
}
