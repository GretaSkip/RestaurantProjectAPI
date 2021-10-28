namespace RestaurantProject.Entities
{
    public class Meniu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public int Meat { get; set; }
        public string About { get; set; }

        //public List<Restaurant> Restaurants { get; set; }

    }
}
