namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public class Invoice
{
    public int Id { get; private set; }
    public float Amount { get; private set; }
    public DateTime Date { get; private set; }
    public int SubscriptionId { get; set; }

    public Invoice(int subscriptionId, float amount, DateTime date)
    {
        SubscriptionId = subscriptionId;
        Amount = amount;
        Date = date;
    }
}