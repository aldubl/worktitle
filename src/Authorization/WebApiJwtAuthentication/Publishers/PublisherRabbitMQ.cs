using MassTransit;
using RabbitMQ.Events;
using WebApiJwtAuthentication.Publishers.Interfaces;

namespace WebApiJwtAuthentication.Publishers
{
    public class PublisherRabbitMQ : IPublisherRabbitMQ
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublisherRabbitMQ(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendUpdateUser(string email)
        {
            await _publishEndpoint.Publish<UserUpdated>(new
            {
                Email = email
            });
        }
    }
}
