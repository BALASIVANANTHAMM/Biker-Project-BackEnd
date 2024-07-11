namespace ApiGeneration.Model
{
    public class ModelClass
    {
        public String IdNation { get; set; }
        public String Nation { get; set; }
        public int IdYear { get; set; }
        public String Year { get; set; }
        public int Population { get; set; }
        public String SlugNation { get; set; }
    }
    public class Addresses
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
    public class employee
    {
        public int eid { get; set; }
        public string place { get; set; }
        public string role { get; set; }
        public int salery { get; set; }
    }
}
