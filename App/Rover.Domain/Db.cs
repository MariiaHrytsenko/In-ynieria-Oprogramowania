namespace Rover.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNunber { get; set; }
        public string Email { get; set; }
        public string MainCity { get; set; }
        public DateTime Birthday { get; set; }
    }
}
