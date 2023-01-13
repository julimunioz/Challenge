namespace Challenge.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Advisorid { get; set; }
        public string NameAdvisor { get; set; }
        public DateTime Created { get; set; }
    }
}
