using Api_SalesTaxesTest.Models;

namespace Api_SalesTaxesTest.Controllers
{
    public static class ArticlesStorage
    {
        private static readonly Article[] articles = new Article[]
        {
            new Article { Id = 1, Name = "Book", Category="Books", Price = 12.49 },
            new Article { Id = 2, Name = "Music CD", Category="General",  Price = 14.99, IsBasicSales = true },
            new Article { Id = 3, Name = "Chocolate Bar", Category="Food", Price = 0.85 },

            new Article { Id = 4, Name = "Box of Chocolates", Category="Food", Price = 10.00, IsImported = true },
            new Article { Id = 5, Name = "Bottle of Perfume", Category="General", Price = 47.50, IsBasicSales = true, IsImported = true },

            new Article { Id = 6, Name = "Bottle of Perfume", Category="General", Price = 27.99, IsBasicSales = true, IsImported = true },
            new Article { Id = 7, Name = "Bottle of Perfume", Category="General", Price = 18.99, IsBasicSales = true },
            new Article { Id = 8, Name = "Packet of Headache Pills ", Category="Medical", Price = 9.75 },
            new Article { Id = 9, Name = "Box of Chocolates", Category="Food", Price = 11.25, IsImported = true }
        };

        public static IEnumerable<Article> GetArticles()
        {
            return articles;
        }

        public static Article? GetArticlesDetails(int id)
        {
            return articles.FirstOrDefault((p) => p.Id == id);
        }
    }
}
