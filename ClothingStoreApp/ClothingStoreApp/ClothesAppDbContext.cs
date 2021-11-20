using ClothingStoreApp.Models;
using System.Data.Entity;

namespace ClothingStoreApp
{
    public class ClothesAppDbContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Visitor> Visitors { get; set; }


    }

    public class ClothesDbInitializer : DropCreateDatabaseAlways<ClothesAppDbContext>
    {
        protected override void Seed(ClothesAppDbContext db)
        {
            db.Clothes.Add(new Clothes { BrandName = "Supreme", KindOf = "T-Shirt", Price = 70, Size = "L" });
            db.Clothes.Add(new Clothes { BrandName = "Lacoste", KindOf = "Polo", Price = 56, Size = "XL" });
            db.Clothes.Add(new Clothes { BrandName = "Fred Perry", KindOf = "Polo", Price = 99, Size = "M" });
            db.Clothes.Add(new Clothes { BrandName = "Nike", KindOf = "Shorts", Price = 39.99m, Size = "M" });
            db.Clothes.Add(new Clothes { BrandName = "Adidas", KindOf = "Jacket", Price = 120, Size = "L" });
            db.Clothes.Add(new Clothes { BrandName = "Puma", KindOf = "Sneakers", Price = 189, Size = "9" });
            db.Clothes.Add(new Clothes { BrandName = "Tipo", KindOf = "T-Shirt", Price = 19, Size = "XS" });
            db.Clothes.Add(new Clothes { BrandName = "Rynok", KindOf = "Boots", Price = 1, Size = "1" });
            db.Clothes.Add(new Clothes { BrandName = "Crosby", KindOf = "Boots", Price = 99.99m, Size = "11" });
            db.Clothes.Add(new Clothes { BrandName = "Reebok", KindOf = "Shorts", Price = 15, Size = "S" });
            db.Clothes.Add(new Clothes { BrandName = "Anteather", KindOf = "Jacket", Price = 56, Size = "M" });



            base.Seed(db);
        }
    }
}