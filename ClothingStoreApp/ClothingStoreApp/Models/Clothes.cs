using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ClothingStoreApp.Models
{
    public class Clothes
    {
        [HiddenInput(DisplayValue = false)]
        public int ClothesId { get; set; }

        [Display(Name = "Бренд")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string BrandName { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string KindOf { get; set; }

        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Size { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public decimal Price { get; set; }



    }
}