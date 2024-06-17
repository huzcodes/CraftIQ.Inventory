namespace CraftIQ.Inventory.API
{
    public static class Routes
    {
        public class CategoriesRoutes
        {
            public const string BaseUrl = "/category";
            public const string Delete = BaseUrl + "/{categoryId}";
            public const string ReadById = BaseUrl + "/{categoryId}";
            public const string Update = BaseUrl + "/{categoryId}";
        }

        public class ProductsRoutes
        {
            public const string BaseUrl = "/products";
            public const string ReadById = BaseUrl + "/{productId}";
            public const string Update = BaseUrl + "/{productId}";
            public const string Delete = BaseUrl + "/{productId}";
            // categories part
            public const string ReadByCategoryId = CategoriesRoutes.ReadById + BaseUrl;
            public const string ReadSingleByCategoryId = CategoriesRoutes.ReadById + ReadById;
            public const string UpdateProductCategoryId = CategoriesRoutes.BaseUrl + ReadById;
        }

        public class InventoryRoutes
        {
            public const string BaseUrl = "/inventories";
            public const string ReadById = BaseUrl + "/{inventoryId}";
            public const string Update = BaseUrl + "/{inventoryId}";
            public const string Delete = BaseUrl + "/{inventoryId}";
        }
        
        public class TransactionsRoutes
        {
            public const string BaseUrl = "/transactions";
            public const string ReadById = BaseUrl + "/{transactionId}";
            public const string Update = BaseUrl + "/{transactionId}";
            public const string Delete = BaseUrl + "/{transactionId}";
        }
        public class OrdersRoutes
        {
            public const string BaseUrl = "/orders";
            public const string ReadById = BaseUrl + "/{orderId}";
            public const string Update = BaseUrl + "/{orderId}";
            public const string Delete = BaseUrl + "/{orderId}";
        }
        public class OrderDetailsRoutes
        {
            public const string BaseUrl = "/orderDetails";
            public const string ReadById = BaseUrl + "/{orderDetailId}";
            public const string Update = BaseUrl + "/{orderDetailId}";
            public const string Delete = BaseUrl + "/{orderDetailId}";
        }
    }
}
