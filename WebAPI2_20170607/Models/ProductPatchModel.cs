using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2_20170607.Models
{
    public class ProductPatchModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}