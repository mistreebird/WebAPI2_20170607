using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI2_20170607.Models
{
    public class ProductPatchModel
    {
        public int ProductId { get; set; }
        [StringLength(30,ErrorMessage = "名稱請勿超過30個字")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}