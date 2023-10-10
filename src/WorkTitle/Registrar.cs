using AutoMapper;
using MediatR;
using WorkTitle.Api.Mapping;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.Mapping;
using WorkTitle.Application.RoleService.CommandHandlers;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Application.RoleService.Queries;
using WorkTitle.Application.RoleService.QueriesHandlers;
using WorkTitle.Domain.EntitiesDto;
using WorkTitle.Infrastructure.Implementation.Repositories;
using WorkTitle.Infrastructure;
using WorkTitle.Application.UserService.CommandHandlers;
using WorkTitle.Application.UserService.Commands;
using WorkTitle.Application.UserService.Queries;
using WorkTitle.Application.UserService.QueriesHandlers;
using WorkTitle.Application.UsersService.QueriesHandlers;

namespace WorkTitle.Api
{
    internal static class Registrar
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton((IConfigurationRoot)configuration)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
                .AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()))
                .AddInfrastructureServices(configuration)
                .InstallHandlers()
                .InstallRepositories();
        }

        private static IServiceCollection InstallHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection
                //role
                .AddTransient<IRequestHandler<GetRolesAsyncQuery, IEnumerable<RoleDto>>, GetRolesHandler>()
                .AddTransient<IRequestHandler<GetRoleByIdAsyncQuery, RoleDto>, GetRoleByIdHandler>()
                .AddTransient<IRequestHandler<AddRoleAsyncCommand, RoleDto>, AddRoleHandler>()
                .AddTransient<IRequestHandler<UpdateRoleAsyncCommand, RoleDto>, UpdateRoleHandler>()
                .AddTransient<IRequestHandler<DeleteRoleAsyncCommand, Guid>, DeleteRoleHandler>()
                //user
                .AddTransient<IRequestHandler<GetUsersAsyncQuery, IEnumerable<UserDto>>, GetUsersHandler>()
                .AddTransient<IRequestHandler<GetUserByIdAsyncQuery, UserDto>, GetUserByIdHandler>()
                .AddTransient<IRequestHandler<AddUserAsyncCommand, UserDto>, AddUserHandler>()
                .AddTransient<IRequestHandler<UpdateUserAsyncCommand, UserDto>, UpdateUserHandler>()
                .AddTransient<IRequestHandler<DeleteUserAsyncCommand, Guid>, DeleteUserHandler>()
                ;
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IUserRepository, UserRepository>();
                ;
            return serviceCollection;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<RoleUiProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
