using AutoMapper;
using MapTool.Core.Common.Exceptions;
using MapTool.Core.Types;
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
        Task<IEnumerable<Project>> GetAllProjects();
    }

    public class ProjectService
    {
        private readonly IDatabaseManagementService _dbService;
        private readonly IMapper _mapper;
        public ProjectService(IDatabaseManagementService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public async Task<List<Project>> GetProjects()
        {
            if (IDatabaseManagementService.CurrentContext == null)
            {
                throw new DatabaseNotInitializedException("Failed to get projects because IDatabaseManagementService.CurrentContext was null. Call ImportDatabase or CreateDatabase first.");
            }

            var projectDtos = IDatabaseManagementService.CurrentContext.Projects;

            return await _mapper.ProjectTo<Project>(projectDtos).ToListAsync();
        }
    }
}
