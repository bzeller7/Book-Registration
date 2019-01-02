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
    public partial class FrmAddBook : Form
    {
        public FrmAddBook()
        {
            InitializeComponent();
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.ISBN = txtISBN.Text;

            BookDB.AddBook(book);
            MessageBox.Show("Book Added!");
            New_Book = book;

            DialogResult = DialogResult.OK;
            Close();
        }

        public Book New_Book { get; set; }
    }
}
