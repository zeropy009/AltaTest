namespace AltaTest.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Gender { get; set; }
        public ICollection<Points> Points { get; set; } = new List<Points>();
    }
}
