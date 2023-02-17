using static Api_SalesTaxesTest.Models.ShoppingCart;

namespace Api_SalesTaxesTest.Models
{
    public class Receipt
    {

        public List<ReceiptRow> Rows { get; set; }

        public double TotPrice { get; set; }
        public double TotSalesTaxes { get; set; }

        public Receipt(ShoppingCart shCart)
        {
            Rows = new();
            shCart.Arts.ForEach(a => Rows.Add(new ReceiptRow(a)));
            TotPrice = Math.Round(shCart.TotPrice * 20) / 20; 
            TotSalesTaxes = Math.Round(shCart.TotSalesTaxes * 20) / 20;
        }


        /*-------------*\
         * Inner class *
        \*-------------*/
        public class ReceiptRow
        {
            public string Text { get; set; }
            public int Qty { get; set; }

            public double SubTotPrice { get; set; }

            public ReceiptRow(ShArt shArt)
            {
                Text = (shArt.Art.IsImported == true ? "Imported " : "") + shArt.Art.Name;
                Qty = shArt.Qty;
                SubTotPrice = Math.Round((shArt.SubTotPrice + shArt.SubTotSalesTaxes) * 100 ) / 100;
            }
        }
    }

}
