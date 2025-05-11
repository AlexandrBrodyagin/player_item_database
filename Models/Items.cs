namespace NewProject.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}