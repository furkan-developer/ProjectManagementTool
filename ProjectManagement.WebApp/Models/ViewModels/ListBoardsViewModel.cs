using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTOs;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class ListBoardsViewModel
    {
       public Guid WorkspaceId { get; set; }
       public string ProjectName { get; set; }
       public List<ListBoardWithIdandTitleDTO> Boards { get; set; }
    }
}