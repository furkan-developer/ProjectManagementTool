using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTOs;

public class ListBoardWithIdandTitleDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}