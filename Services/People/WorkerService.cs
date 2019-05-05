using System.Linq;
using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;

namespace Services.People
{
    public class WorkerService : IWorkerService
    {
        private readonly IRepository<Worker> _workerRepository;
        private readonly IRepository<User> _userRepository;


        public WorkerService(IRepository<User> userRepository,
            IRepository<Worker> workerRepository)
        {
            _userRepository = userRepository;
            _workerRepository = workerRepository;
        }

        public Worker GetWorkerByUserId(int userId)
        {
            return _workerRepository.TableNoTracking.Single(x => x.User.Id == userId);
        }

        public Worker GetWorkerById(int workerId)
        {
            return _workerRepository.GetById(workerId);
        }
    }
}
