using System;
using Zen.Domain.Entities.Attributes;
using Zen.Domain.Events;

namespace ZenAchitecture.Domain.Events
{
    [ProcessedByEventProcessor]
    public class ApplicationAppliedEmailEvent : DomainEvent
    {
        public ApplicationAppliedEmailEvent(int activityId, int applicationId, Guid tenatId) : base(streamId: applicationId.ToString())
        {
            ApplicationId = applicationId;
            ActivityId = activityId;
            CompanyId = tenatId;
        }

        public int ApplicationId { get; set; }

        public int ActivityId { get; set; }

        public Guid CompanyId { get; set; }

    }
}
