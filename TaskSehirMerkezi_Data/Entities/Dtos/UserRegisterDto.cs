namespace TaskSehirTeknolojileri_Data.Entities.Dtos
{
    public class UserRegisterDto:EntityBaseDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
