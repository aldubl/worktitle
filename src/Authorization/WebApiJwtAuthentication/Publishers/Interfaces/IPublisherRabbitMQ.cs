namespace WebApiJwtAuthentication.Publishers.Interfaces
{
    public interface IPublisherRabbitMQ
    {
        Task SendUpdateUser(string email);
    }
}
