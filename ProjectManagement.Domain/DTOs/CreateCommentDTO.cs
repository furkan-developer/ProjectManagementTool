using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Domain.DTOs;

public class CreateCommentDTO
{
    [Required]
    public string Content { get; set; }

    [Required]
    public Guid ToJob { get; set; }
}