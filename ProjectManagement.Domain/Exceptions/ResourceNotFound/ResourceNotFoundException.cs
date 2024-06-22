using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Exceptions.ResourceNotFound
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base() { }

        public ResourceNotFoundException(string message) : base(message) { }

        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ProjectNotFoundException : ResourceNotFoundException
    {
        public ProjectNotFoundException() : base("Relevant project resource was not found") { }

        public ProjectNotFoundException(string message) : base(message) { }

    }
}