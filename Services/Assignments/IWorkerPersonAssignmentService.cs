using DataRepository.Entities;
using DataRepository.Entities.People;
using System.Collections.Generic;

namespace Services.Assignments
{
    public interface IWorkerPersonAssignmentService
    {
        List<Worker> GetAllowedForAssignWorkers(int administrationId);
        WorkerPersonAssignment Create(WorkerPersonAssignment assignment);
        bool IsWorkerFree(int workerUserId);

        Worker GetAssignedWorkerUser(int customerId);
    }
}
