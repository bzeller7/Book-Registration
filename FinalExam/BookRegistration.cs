using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    class BookRegistration
    {
        public int CustomerID { get; set; }
        public string ISBN { get; set; }
        public DateTime RegDate { get; set; }

        public override string ToString()
        {
            return Convert.ToString(CustomerID) ;
        }

    }
}
