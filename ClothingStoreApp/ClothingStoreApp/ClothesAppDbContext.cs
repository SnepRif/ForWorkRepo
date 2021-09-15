using ClothingStoreApp.Models;
using System.Data.Entity;

namespace ClothingStoreApp
{
    public class ClothesAppDbContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

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
            db.Clothes.Add(new Clothes { BrandName = "Nike", KindOf = "Sneakers", Price = 199, Size = "10.5" });

            base.Seed(db);
        }
    }
}