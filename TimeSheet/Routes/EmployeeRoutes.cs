namespace TimeSheet.WebAPI.Routes
{
    public class EmployeeRoutes
    {
        public const string EmployeeGetAll = "/employees";
        public const string EmployeeFindByName = "/employee/findByName/{name}";
        public const string EmployeeFindById = "/employee/{id}";
        public const string EmployeeCreate = "/employee/create";
        public const string EmployeeUpdate = "/employee/update";
        public const string EmployeeSetProject = "/employee/setProject";
        public const string EmployeeDelete = "/employee/delete/{id}";
    }
}
