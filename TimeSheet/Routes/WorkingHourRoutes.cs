namespace TimeSheet.WebAPI.Routes
{
    public class WorkingHourRoutes
    {
        public const string WorkingHourGetAll = "/workingHours";
        public const string WorkingHourReport = "/workingHour/report";
        public const string WorkingHourFindByName = "/workingHour/findByName/{name}";
        public const string WorkingHourFindById = "/workingHour/{id}";
        public const string WorkingHourCreate = "/workingHour/create";
        public const string WorkingHourUpdate = "/workingHour/update";
        public const string WorkingHourDelete = "/workingHour/delete/{id}";
    }
}
