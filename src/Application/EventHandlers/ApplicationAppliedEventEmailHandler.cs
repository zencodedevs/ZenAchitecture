using ZenAchitecture.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Zen.Domain.Events;

namespace ZenAchitecture.Application.EventHandlers
{
    public class ApplicationAppliedEventEmailHandler : INotificationHandler<DomainEventNotification<ApplicationAppliedEmailEvent>>
    {

        public ApplicationAppliedEventEmailHandler()
        {

        }

        public async Task Handle(DomainEventNotification<ApplicationAppliedEmailEvent> notification, CancellationToken cancellationToken)
        {

        }


    }
}
