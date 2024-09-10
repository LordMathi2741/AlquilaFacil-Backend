using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; }
    
    public int UserId { get; set; }
    
    public int SubscriptionStatusId { get; set; }
    
    public ICollection<Invoice> Invoices { get; }
    
    public Plan Plan { get; internal set; }
    public int PlanId { get; private set; }

    public Subscription(int planId)
    {
        PlanId = planId;
        SubscriptionStatusId = 2;
    }
    
}