namespace Theater.Data.Models
{
    public class Place
    {
        public int id { get; set; }
        public int row {get; set; } 
        public int col { get; set; }
		public ScenePart scenePart { get; set; }
    }
}
