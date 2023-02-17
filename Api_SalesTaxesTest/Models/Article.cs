namespace Api_SalesTaxesTest.Models
{

    public class Article
    {
        private readonly double IMPORT_DUTY = 0.05;
        private readonly double BASIC_SALES = 0.1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public Boolean? IsImported { get; set; }
        public Boolean? IsBasicSales { get; set; }

        public double SalesTaxes => 
            (IsImported == true) && (IsBasicSales == true) ? ((Price * IMPORT_DUTY) + (Price * BASIC_SALES)) : // (Price * IMPORT_DUTY * BASIC_SALES):
            IsImported == true ? (Price * IMPORT_DUTY) :
            IsBasicSales == true ? (Price * BASIC_SALES) :
                0;

    }
}