namespace TimeSheet.WebAPI.Routes
{
    public class ClientRoutes
    {
        public const string ClientGetAll = "/clienties";
        public const string ClientFindByName = "/client/findByName/{name}";
        public const string ClientFindById = "/client/{id}";
        public const string ClientCreate = "/client/create";
        public const string ClientUpdate = "/client/update";
        public const string ClientDelete = "/client/delete/{id}";
    }
}
