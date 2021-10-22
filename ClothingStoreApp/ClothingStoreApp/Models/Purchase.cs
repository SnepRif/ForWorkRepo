using System;

namespace ClothingStoreApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public int ClothesId { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

       
    }
}