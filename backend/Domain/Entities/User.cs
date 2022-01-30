namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string ?Name { get; set; }
        public string ?Usuario { get; set; }
        public string  ?Email  { get; set; }
        public string ?Senha {get; set;}  
    }
}