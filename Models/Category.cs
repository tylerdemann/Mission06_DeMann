namespace Mission06_DeMann.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}