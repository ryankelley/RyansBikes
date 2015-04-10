namespace BikeStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public long SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ManufacturerId { get; set; }
        public string BrandName { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string ThumbURL { get; set; }
        public string ImageURL { get; set; }
        public decimal SalesPrice { get; set; }

 
    }
}