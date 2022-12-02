using AutoMapper;
using MapTool.Core.Common.Exceptions;
using MapTool.Core.Types;
using MapTool.Domain.Types;
using MapTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<bool> CreateProject(string name, string author, string description, string version = "0.0.1");
        Task<bool> DeleteProject(string name);
    }

    public class ProjectService : IProjectService
    {
        private readonly IDatabaseManagementService _dbService;
        private readonly IMapper _mapper;
        public ProjectService(IDatabaseManagementService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            if (IDatabaseManagementService.CurrentContext == null)
            {
                throw new DatabaseNotInitializedException("Failed to get projects because IDatabaseManagementService.CurrentContext was null. Call ImportDatabase or CreateDatabase first.");
            }

            var projectDtos = await IDatabaseManagementService.CurrentContext.Projects.ToListAsync();

            return _mapper.Map<IEnumerable<ProjectDto>, IEnumerable<Project>>(projectDtos);
        }

        public async Task<bool> CreateProject(string name, string author, string description, string version = "0.0.1")
        {
            if (IDatabaseManagementService.CurrentContext == null)
            {
                throw new DatabaseNotInitializedException("Failed to add a project because IDatabaseManagementService.CurrentContext was null. Call ImportDatabase or CreateDatabase first.");
            }

            // Add the project to the change tracker.
            await IDatabaseManagementService.CurrentContext.Projects.AddAsync(new()
            {
                Name = name,
                Author = author,
                Description = description,
                VersionString = version
            });

            // Write the change to the db.
            return await IDatabaseManagementService.CurrentContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<bool> DeleteProject(string name)
        {
            if (IDatabaseManagementService.CurrentContext == null)
            {
                throw new DatabaseNotInitializedException("Failed to delete a project because IDatabaseManagementService.CurrentContext was null. Call ImportDatabase or CreateDatabase first.");
            }

            var project = await IDatabaseManagementService.CurrentContext.Projects.SingleOrDefaultAsync(p => p.Name == name);

            if (project == null)
            {
                return false;
            }

            IDatabaseManagementService.CurrentContext.Projects.Remove(project);

            return await IDatabaseManagementService.CurrentContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
