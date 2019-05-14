using DataRepository.Entities;
using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;

namespace Services.Assignments
{
    public class WorkerPersonAssignmentService : IWorkerPersonAssignmentService
    {

        private readonly IRepository<WorkerPersonAssignment> _assignmentRepository;
        private readonly IRepository<Worker> _workerRepository;

        public WorkerPersonAssignmentService(
            IRepository<WorkerPersonAssignment> assignmentRepository,
            IRepository<Worker> workerRepository)
        {
            _workerRepository = workerRepository;
            _assignmentRepository = assignmentRepository;
        }

        public List<Worker> GetAllowedForAssignWorkers(int administrationId)
        {
            var excludedWorkers = _assignmentRepository.TableNoTracking
                .Where(x => x.Worker.Administration.Id == administrationId)
                .GroupBy(x => x.Worker)
                .Where(x => x.Count() < 7)
                .Select(x => x.Key.Id);

            return _workerRepository.TableNoTracking.Where(x => excludedWorkers.Contains(x.Id)).ToList();
        }

    }
}
