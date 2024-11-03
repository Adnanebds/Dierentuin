namespace EindOpdrachtC_Goede.Models
{
    public class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>();

    }
}
