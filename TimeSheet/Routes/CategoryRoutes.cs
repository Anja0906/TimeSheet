namespace TimeSheet.Service.Routes
{
    public class CategoryRoutes
    {
        public const string CategoryGetAll = "/categories";
        public const string CategoryFindByName = "/category/findByName/{name}";
        public const string CategoryFindById = "/category/{id}";
        public const string CategoryCreate = "/category/create";
        public const string CategoryUpdate = "/category/update";
        public const string CategoryDelete = "/category/delete/{id}";
    }
}
