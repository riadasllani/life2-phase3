using Interface.IUnitOfWork;

namespace MatchingApp.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MatchService> _logger;
        public MatchService(IUnitOfWork unitOfWork, ILogger<MatchService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        





    }
}
