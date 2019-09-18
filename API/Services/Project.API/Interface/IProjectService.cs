using ProjectManagementService.DTOs;
using ProjectManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Interface
{
    public interface IProjectService
    {
        ProjectDTO ProjectCard(string projectCode);
        List<ProjectDTO>GetDataProject();
        Task<string> CreateProject(ProjectDTO addProject);
        void UpdateProject(ProjectDTO dataedit);
        void DeleteProject(string deletedata);
    }
}
