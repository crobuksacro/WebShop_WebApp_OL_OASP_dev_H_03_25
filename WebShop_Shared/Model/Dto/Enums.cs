namespace WebShop_Shared.Model.Dto
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Buyer = "Buyer";
    }

    public enum OrderStatus
    {
        /// <summary>
        /// Narudžba je primljena, ali još nije obrađena
        /// </summary>
        Pending,
        /// <summary>
        /// Narudžba se obrađuje
        /// </summary>
        Processing,
        /// <summary>
        /// Narudžba je poslana
        /// </summary>
        Shipped,
        /// <summary>
        /// Narudžba je isporučena
        /// </summary>
        Delivered,
        /// <summary>
        /// Narudžba je otkazana
        /// </summary>
        Canceled,
        /// <summary>
        /// Narudžba je vraćena
        /// </summary>
        Returned,
        /// <summary>
        /// Narudžba je refundirana
        /// </summary>
        Refunded
    }

    public enum DocumentType
    {
        Invoice,
        Offer,

        Receipt,
        DeliveryNote,
        WarrantyCertificate,
        ReturnForm,




    }

    public enum DocumentStatus
    {
        Active,
        Canceled,
        Paid
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery
    }



}
