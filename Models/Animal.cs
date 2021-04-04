namespace CW_4.Controllers
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }

        public override string ToString()
        {
            return $"{IdAnimal} {Name} {Discription} {Category} {Area} \n";
        }
    }
}