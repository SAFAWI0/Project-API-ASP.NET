namespace project.Models
{
    public class UserResponse
    {
        public string   Message { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
