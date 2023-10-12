namespace TimeSheet.WebAPI.Routes
{
    public class CountryRoutes
    {
        public const string CountryGetAll = "/countries";
        public const string CountryFindByName = "/country/findByName/{name}";
        public const string CountryFindById = "/country/{id}";
        public const string CountryCreate = "/country/create";
        public const string CountryUpdate = "/country/update";
        public const string CountryDelete = "/country/delete/{id}";
    }
}
