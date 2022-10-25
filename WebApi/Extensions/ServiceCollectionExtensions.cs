using CRUDUserFeature.Validators;

using FluentValidation;
using PipelineBehaviors;

using MediatR;
using CRUDUserFeature.Commands;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediatRDependency(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateUserCommand).Assembly);

            services.AddValidatorsFromAssembly(typeof(CreateUserDtoValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
