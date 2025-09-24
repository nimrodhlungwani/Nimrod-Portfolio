using System.ComponentModel.DataAnnotations;

namespace Nimrod_Portfolio.Models
{
    public class Mail
    {
        public string Name { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }
        [RegularExpression(@"^\+?(\d{1,3})?[-.\s]?(\(?\d{3}\)?[-.\s]?)?(\d[-.\s]?){6,9}\d$", ErrorMessage = "Enter a valid contact number")]
        public string Contact { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
