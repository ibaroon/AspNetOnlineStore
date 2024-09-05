namespace OnlineStore.Models
{
    public class IndexVm
    {
        public IndexVm()
        { // by using this constructor if results of db query in the controller is null then it will have default value of empty list NOT NULL!! 
            Categories = new List<Catigory>();
            Products = new List<Product>();
            Reviews = new List<Review>();
            LatestProducts = new List<Product>();
            //sts = 0;
        }
        public List<Catigory> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Product> LatestProducts { get; set; }
        //public int sts { get; set; }
    }
}
