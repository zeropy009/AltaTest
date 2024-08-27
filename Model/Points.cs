namespace AltaTest.Model
{
    public class Points
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public DateTime DateTime { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
    }
}
