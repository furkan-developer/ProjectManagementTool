using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore.Repositories;

namespace ProjectManagement.DataAccess.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IJobRepository _jobRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ISubJobRepository _subJobRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IStageRepository _stageRepository;
        private readonly IBoardRepository _boardRepository;

        public UnitOfWork(AppDbContext context,
            IJobRepository jobRepository,
            IProjectRepository projectRepository,
            ISubJobRepository subJobRepository,
            IBoardRepository boardRepository,
            ICommentRepository commentRepository,
            IStageRepository stageRepository)
        {
            _context = context;
            _jobRepository = jobRepository;
            _projectRepository = projectRepository;
            _subJobRepository = subJobRepository;
            _commentRepository = commentRepository;
            _stageRepository = stageRepository;
            _boardRepository = boardRepository;
        }

        public IJobRepository JobRepository => _jobRepository;

        public IProjectRepository ProjectRepository => _projectRepository;

        public ISubJobRepository SubJobRepository => _subJobRepository;

        public ICommentRepository CommentRepository => _commentRepository;

        public IBoardRepository BoardRepository => _boardRepository;

        public IStageRepository StageRepository => _stageRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}