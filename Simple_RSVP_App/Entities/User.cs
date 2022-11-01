namespace Simple_RSVP_App.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public State Status { get; set; }
    }
}
