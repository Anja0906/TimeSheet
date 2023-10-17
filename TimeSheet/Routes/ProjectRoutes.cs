namespace TimeSheet.WebAPI.Routes
{
    public class ProjectRoutes
    {
        public const string ProjectGetAll = "/projects";
        public const string ProjectFindByName = "/project/findByName/{name}";
        public const string ProjectFindById = "/project/{id}";
        public const string ProjectCreate = "/project/create";
        public const string ProjectUpdate = "/project/update";
        public const string ProjectDelete = "/project/delete/{id}";
        public const string LeadingProjects = "/project/leading";
    }
}
