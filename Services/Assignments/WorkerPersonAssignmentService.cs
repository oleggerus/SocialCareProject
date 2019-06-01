using System;
using DataRepository.Entities;
using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;
using DataRepository.Enums;

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
                .Select(x => x.Key.Id).ToList();

            return _workerRepository.TableNoTracking.Where(x => excludedWorkers.Contains(x.Id)).ToList();
        }

        public WorkerPersonAssignment Create(WorkerPersonAssignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException();
            }
            _assignmentRepository.Insert(assignment);

            return assignment;
        }

        public bool IsWorkerFree(int workerUserId)
        {
            return _assignmentRepository.TableNoTracking.Count(x => x.Worker.UserId == workerUserId &&
                                                                    x.AssignmentStatusId ==
                                                                    (int) WorkerPersonAssignmentStatuses
                                                                        .Активно) < 6;


        }
    }
}
