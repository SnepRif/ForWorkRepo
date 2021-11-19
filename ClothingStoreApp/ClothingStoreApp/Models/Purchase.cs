using System;
using System.ComponentModel.DataAnnotations;

namespace ClothingStoreApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [Required]
        public string Person { get; set; }

        [Required]
        public int ClothesId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Date { get; set; }

       
    }
}