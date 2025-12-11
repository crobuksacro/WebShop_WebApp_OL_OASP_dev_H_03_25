using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.Dto.Document;
using WebShop_Shared.Model.ViewModel.Document;
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
        public async Task GetAllDocumentsAsync_GetsAllDocumentsFromDb_ReturnsListOfDocumentViewModel()
        {
          
            for (int i = 0; i < 5; i++)
            {
                await SaveNewDocumentAsync();
            }

            var req = new GetDocumentBinding
            {
                Active = true,
                DocumentType = DocumentType.Invoice
            };


            var result = await documentService.GetDocumentsAsync(req);
            Assert.NotEmpty(result);
            Assert.Equal(5,result.Count);
        }


        [Fact]
        public async Task GetDocumentByIdAsync_GetsDocumentFromDb_ReturnsDocumentAsViewModel()
        {
            DocumentViewModel document = await SaveNewDocumentAsync();

            InvoiceDto result = await documentService.GetDocumentAsync<InvoiceDto>(document.Id);

            Assert.NotNull(result);
            Assert.Equal(OrderStatus.Pending,result.Order.OrderStatus);
            Assert.Equal(PaymentMethod.CreditCard,result.PaymentMethod);
        }

        [Fact]
        public async Task SaveDocumentAsync_AddsNewDocumentToDb_ReturnsAddedNewDocumetAsViewModel()
        {
            DocumentViewModel result = await SaveNewDocumentAsync();

            Assert.NotNull(result);
            Assert.Equal(DocumentType.Invoice, result.DocumentType);
            Assert.Equal(DocumentStatus.Active, result.DocumentStatus);
        }

        private async Task<DocumentViewModel> SaveNewDocumentAsync()
        {
            var ivnoice = new InvoiceDto
            {
                PaymentMethod = PaymentMethod.CreditCard,
                Order = new OrderViewModel
                {
                    Id = 1,
                    Total = 150.00m,
                    Created = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Pending,
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
            return result;
        }
    }
}
