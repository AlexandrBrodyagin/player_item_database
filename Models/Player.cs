namespace NewProject.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Items>? Items { get; set; }
    }
}