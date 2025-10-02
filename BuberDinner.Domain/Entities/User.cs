namespace BuberDinner.Domain.Entities
{
    // Using primary constructor
    public class User(string firstName, string lastName, string email, string password)
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //  open to change
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
