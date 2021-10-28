namespace RestaurantProject.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Customers { get; set; }
        public int Employees { get; set; }
        public int MeniuId { get; set; }

        public Meniu Meniu { get; set; }

    }
}
