using System;
using System.Collections.Generic;
using DemoAppPortable.BusinessLayer.Entities;
using DemoAppPortable.DataLayer;

namespace DemoAppPortable.DataAccessLayer
{
    public class TaskRepository
    {
        private readonly AppDatabase _db;

        public TaskRepository(string databaseFolderPath)
        {
            this._db = new AppDatabase(databaseFolderPath);
        }

        public TaskEntity GetTask(int id)
        {
            return this._db.GetRecord<TaskEntity>(id);
        }

        public List<TaskEntity> GetTaskList()
        {
            return this._db.GetRecordList<TaskEntity>();
        }

        public bool DeleteTask(int id)
        {
            return this._db.DeleteRecord<TaskEntity>(id);
        }

        public int SaveTask(TaskEntity record)
        {
            return this._db.SaveRecord(record);
        }
    }
}
