using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Queries;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;
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
    
    [Fact]
    public  void InvoiceQueryServiceMustToReturnTheSameInvoice()
    {
        //Arrange
        var invoice = new Invoice(1,100,DateTime.Now);
        var invoiceQueryService = new Mock<IInvoiceQueryService>();

        //SetUp
       invoiceQueryService.Setup(x => x.Handle(new GetInvoiceByIdQuery(invoice.Id))).ReturnsAsync(invoice);
       var invoiceToCompare = invoiceQueryService.Object.Handle(new GetInvoiceByIdQuery(invoice.Id));
        //Assert
        Assert.Equal(invoice, invoiceToCompare.Result);
    }
}