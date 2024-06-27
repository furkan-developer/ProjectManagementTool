using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Contracts
{
    public interface IProjectService
    {
        void HasProjectById(Guid projectId);
        string GetNameOfProjectById(Guid projectId);
    }
}