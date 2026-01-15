namespace WebShop_Shared.Model.Dto
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Buyer = "Buyer";
    }

    public static class ErrorCodes
    {
        public const string MissingValue = "1";
        public const string NotFound = "2";
        public const string AlreadyExists = "3";
        public const string InvalidFormat = "4";
        public const string InvalidLength = "5";
        public const string NotValidPropertyName = "16";
        public const string InvalidRole = "10";
        /// <summary>
        /// The field cannot be specified and must be empty.
        /// </summary>
        public const string ValueNotAllowed = "12";
        /// <summary>
        /// Entity field is out of range of allowed values.
        /// </summary>
        public const string OutOfAllowedRange = "13";
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
