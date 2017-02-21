using System.Collections.Generic;
using System.Linq;
using DemoAppPortable.BusinessLayer.Entities;
using DemoAppPortable.DataAccessLayer;

namespace DemoAppPortable.BusinessLayer.Managers
{
    public class TaskManager : BaseManager
    {
        private readonly TaskRepository _repository;

        public TaskManager(string databaseFilePath)
        {
            _repository = new TaskRepository(databaseFilePath);
        }

        public TaskEntity GetTask(int id)
        {
            return _repository.GetTask(id);
        }

        public List<TaskEntity> GetTaskList()
        {
            return _repository.GetTaskList();
        }

        public bool DeleteTask(int id)
        {
            return _repository.DeleteTask(id);
        }

        public int SaveTask(TaskEntity record)
        {
            return _repository.SaveTask(record);
        }

    }
}
