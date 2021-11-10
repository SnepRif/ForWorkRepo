using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ClothingStoreApp.Models
{
    public class Clothes
    {
        [HiddenInput(DisplayValue = false)]
        public int ClothesId { get; set; }

        [Display(Name = "Бренд")]
        public string BrandName { get; set; }

        [Display(Name = "Наименование")]
        public string KindOf { get; set; }

        [Display(Name = "Размер")]
        public string Size { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }



    }
}