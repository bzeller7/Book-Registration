﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string BookInfo => Title;
        };
    }

