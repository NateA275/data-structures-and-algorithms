﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Classes
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }


        //Node constructor
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
