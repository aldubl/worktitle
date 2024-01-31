using AutoMapper;
using MassTransit;
using MediatR;
using RabbitMQ.Events;
using WorkTitle.Application.UserService.Commands;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Consumers
{
    public class UserUpdateConsumer : IConsumer<UserUpdated>
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public UserUpdateConsumer(IMapper mapper, ISender sender)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Uninitialized property");
            _sender = sender ?? throw new ArgumentNullException(nameof(sender), "Uninitialized property");
        }
        public async Task Consume(ConsumeContext<UserUpdated> context)
        {
            var userDto = _mapper.Map<UserDto>(context.Message);
           
            await _sender.Send(new AddUserAsyncCommand(userDto));
        }
    }
}
