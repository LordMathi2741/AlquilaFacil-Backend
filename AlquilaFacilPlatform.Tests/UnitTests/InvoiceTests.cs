using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using Moq;

namespace AlquilaFacilPlatform.Tests.UnitTests;

public class InvoiceTests
{
    [Fact]
    public void InvoiceRepositoryMustToReturnAValidInvoice()
    {
        //Arrange
        var invoice = new Invoice(1,100,DateTime.Now);
        var invoiceRepository = new Mock<IInvoiceRepository>();

        //SetUp
        invoiceRepository.Setup(x => x.FindByIdAsync(invoice.Id)).ReturnsAsync(invoice);
        //Assert
        Assert.NotNull(invoiceRepository.Object.FindByIdAsync(invoice.Id));
    }
}