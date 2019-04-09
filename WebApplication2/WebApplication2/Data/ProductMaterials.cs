namespace WebApplication2.Models

{
    public class ProductMaterials
    {
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        /// <summary>
        /// poso perioktikotitas
        /// </summary>
        public decimal Percentage { get; set; }
    }
}