using System;
using DataRepository.Entities;
using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;
using DataRepository.Enums;

namespace Services.Assignments
{
    /// <summary>
    /// Class implemented IWorkerPersonAssignmentService interface
    /// </summary>
    public class WorkerPersonAssignmentService : IWorkerPersonAssignmentService
    {
        /// <summary>
        /// The assignment repository
        /// </summary>
        private readonly IRepository<WorkerPersonAssignment> _assignmentRepository;

        /// <summary>
        /// The worker repository
        /// </summary>
        private readonly IRepository<Worker> _workerRepository;

        /// <summary>
        /// The maximum amount of active assignments for social worker
        /// </summary>
        private const int MaxAmountOfActiveAssignments = 6;
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerPersonAssignmentService"/> class.
        /// </summary>
        /// <param name="assignmentRepository">The assignment repository.</param>
        /// <param name="workerRepository">The worker repository.</param>
        public WorkerPersonAssignmentService(
            IRepository<WorkerPersonAssignment> assignmentRepository,
            IRepository<Worker> workerRepository)
        {
            _workerRepository = workerRepository;
            _assignmentRepository = assignmentRepository;
        }

        /// <summary>
        /// Gets the allowed for assign workers.
        /// </summary>
        /// <param name="administrationId">The administration identifier.</param>
        /// <returns></returns>
        public List<Worker> GetAllowedForAssignWorkers(int administrationId)
        {
            var excludedWorkers = _assignmentRepository.TableNoTracking
                .Where(x => x.Worker.Administration.Id == administrationId)
                .GroupBy(x => x.Worker)
                .Where(x => x.Count() > MaxAmountOfActiveAssignments)
                .Select(x => x.Key.Id).ToList();

            return _workerRepository.TableNoTracking
                .Where(x => x.Administration.Id == administrationId && !excludedWorkers.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// Creates the specified assignment.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        /// <returns></returns>
        public WorkerPersonAssignment Create(WorkerPersonAssignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }
            _assignmentRepository.Insert(assignment);

            return assignment;
        }

        /// <summary>
        /// Determines whether is worker free by specified worker user identifier.
        /// </summary>
        /// <param name="workerUserId">The worker user identifier.</param>
        /// <returns>
        /// true if worker is free; otherwise, false.
        /// </returns>
        public bool IsWorkerFree(int workerUserId)
        {
            return _assignmentRepository.TableNoTracking.Count(x => x.Worker.UserId == workerUserId &&
                                                                    x.AssignmentStatusId ==
                                                                    (int) WorkerPersonAssignmentStatuses
                                                                        .Активно) < MaxAmountOfActiveAssignments;


        }
    }
}
