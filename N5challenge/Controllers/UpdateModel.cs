namespace N5challenge.Controllers
{
    public class UpdateModel
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Date { get; set; }
        public int TypeId { get; set; }
    }
}