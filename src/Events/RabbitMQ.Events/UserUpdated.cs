namespace RabbitMQ.Events
{
    public sealed class UserUpdated
    {
        public required string Email { get; set; }
    }
}
