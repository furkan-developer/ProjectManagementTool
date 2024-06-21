using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Contracts
{

    public interface IUnitOfWork
    {
        IJobRepository JobRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ISubJobRepository SubJobRepository { get; }
        ICommentRepository CommentRepository { get; }
        IBoardRepository BoardRepository { get; }
        IStageRepository StageRepository { get; }
        Task SaveChangesAsync();
    }
}