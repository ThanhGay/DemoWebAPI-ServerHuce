﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Order.Dtos.CartManagerModule
{
    public class CartDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
