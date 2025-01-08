using System.ComponentModel.DataAnnotations;

namespace IoTAPI
{
    public class PubSub
    {
        [Required(ErrorMessage = "O campo host é obrigatorio.")]
        public string Host { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Port é obrigatorio.")]
        public decimal Port { get; set; }

        [Required(ErrorMessage = "O campo User é obrigatorio.")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Password é obrigatorio.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Topic é obrigatorio.")]
        public string Topic { get; set; } = string.Empty;

        // Construtor
        public PubSub(string host, decimal port, string user, string password, string topic)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
            Topic = topic;
        }
    }
}
