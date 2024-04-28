namespace CraftIQ.Inventory.API
{
    public static class Routes
    {
        public class CategoriesRoutes
        {
            public const string BaseUrl = "/category";
            public const string Delete = BaseUrl + "{categoryId}";

            // Cars
            // POST baseUrl/Cars
            // GET baseUrl/Cars
            // GET BY ID baseUrl/Cars/{id}
            // UPDATE baseUrl/Cars/{id}
            // DELETE baseUrl/Cars/{id}

            // Engines
            //POST baseUrl/Cars/Engines
            // PUT baseUrl/Cars/Engines/{Id}
            // DELETE baseUrl/Cars/Engines/{Id}
            // GET baseUrl/Cars/Engines
            // GET baseUrl/Cars/{id}/Engines
            // GET baseUrl/Cars/{id}/Engines/{Id}
        }
    }
}
