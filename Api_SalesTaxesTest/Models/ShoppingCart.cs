namespace Api_SalesTaxesTest.Models
{
    public class ShoppingCart
    {

        public int Id { get; set; }

        public List<ShArt> Arts { get; set; }

        public double TotSalesTaxes { get; set; }
        public double TotPrice { get; set; }

        public ShoppingCart()
        {
            Id= 1;
            Arts = new List<ShArt>();
            TotPrice = 0; 
            TotSalesTaxes = 0;
        }

        public int Add(Article art, int qty, int counter)
        {
            int idx = Arts.FindIndex(x => x.Art.Id == art.Id);

            if (idx == -1)
                Arts.Add(new ShArt(counter++, art, qty));
            else
                Arts[idx].Qty += qty;

            UpdateTotals();
            return counter;
        }

        public Boolean Remove(ShArt shoppedArticle, int qty)
        {
            if (shoppedArticle.Qty < qty)
                return false;

            int idx = Arts.IndexOf(shoppedArticle);
            if (idx < 0)
                return false;

            if (shoppedArticle.Qty == qty)
            {
                Arts.Remove(shoppedArticle);
                UpdateTotals();
                return true;
            }

            Arts[idx].Qty -= qty;
            UpdateTotals();

            return true;
        }

        public ShArt? Get(int idArtShCart)
        {
            return Arts.FirstOrDefault((p) => p.Id == idArtShCart);
        }

        private void UpdateTotals()
        {
            TotSalesTaxes = 0;
            TotPrice = 0;
            foreach (ShArt a in Arts)
            {
                TotSalesTaxes += a.SubTotSalesTaxes;
                TotPrice += a.SubTotPrice + a.SubTotSalesTaxes;
            }
        }

        /*-------------*\
         * Inner class *
        \*-------------*/
        // Shopped Articles
        public class ShArt
        {
            public int Id { get; set; }
            public Article Art { get; set; }
            public int Qty { get; set; }
            public double SubTotSalesTaxes => Art.SalesTaxes * Qty;
            public double SubTotPrice => Art.Price * Qty;

            public ShArt(int id, Article art, int qty)
            {
                Id = id;
                Art = art;
                Qty = qty;
            }
        }
    }

}
