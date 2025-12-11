using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.Dto.Document;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public class DocumentServiceUnitTest : WebShopSetup
    {
        private readonly IDocumentService documentService;
        public DocumentServiceUnitTest()
        {
            this.documentService = GetDocumentService();
        }

        [Fact]
        public async Task SaveDocumentAsync_AddsNewDocumentToDb_ReturnsAddedNewDocumetAsViewModel()
        {


            var ivnoice = new InvoiceDto
            {
                    Order = new OrderViewModel
                {
                    Id = 1,
                    Total = 150.00m,
                    Created = DateTime.UtcNow,
                    OrderStatus = WebShop_Shared.Model.Dto.OrderStatus.Pending,
                    Buyer = Mapper.Map<WebShop_Shared.Model.ViewModel.UserModel.ApplicationUserViewModel>(Buyer),
                    OrderItems = new List<WebShop_Shared.Model.ViewModel.OrderModels.OrderItemViewModel>
                    {
                        new WebShop_Shared.Model.ViewModel.OrderModels.OrderItemViewModel
                        {
                            ProductId = 1,
                            Quantity = 2,
                            Price = 75.00m
                        }
                    }
                },
            };

            var result = await documentService.SaveDocumentAsync(Buyer, DocumentType.Invoice, DocumentStatus.Active, ivnoice);


            Assert.NotNull(result);
            Assert.Equal(DocumentType.Invoice, result.DocumentType);
            Assert.Equal(DocumentStatus.Active, result.DocumentStatus);
        }


    }
}
