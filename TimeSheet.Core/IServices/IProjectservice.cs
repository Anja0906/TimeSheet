﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface IProjectservice
    {
        Task<Project> GetByName(string name);
        Task<Project> UpdateProject(Project project);
        Task<List<Project>> GetAll(UserClaims userClaims);
        Task<Project> GetById(int id);
        Task<Project> AddProject(Project project);
        void DeleteProject(int id);
    }
}
