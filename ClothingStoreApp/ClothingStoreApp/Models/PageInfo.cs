using System;
using System.Collections.Generic;

namespace ClothingStoreApp.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } //номер текущей страницы
        public int PageSize { get; set; } //количество объектов на странице
        public int TotalItems { get; set; } //всего объектов
        public int TotalPages//всего страниц
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }

    }

    public class IndexModels
    {
        public IEnumerable<Clothes> Clothes { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}