using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class UserClaims
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public int HoursPerWeek { get; set; }

        public UserClaims(string id, string role, string hoursPerWeek)
        {
            Id = int.Parse(id);
            Role = (Role)Enum.Parse(typeof(Role), role);
            HoursPerWeek = int.Parse(hoursPerWeek);
        }

        public UserClaims(int id, Role role, int hoursPerWeek)
        {
            Id = id;
            Role = role;
            HoursPerWeek = hoursPerWeek;
        }
    }
}
