using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using DemoAppPortable.BusinessLayer.Contracts;
using DemoAppPortable.BusinessLayer.Entities;
using SQLite;

namespace DemoAppPortable.DataLayer
{
    public class AppDatabase
    {
        private readonly SQLiteConnection _db;
        public static string DbName = "DemoAppDatabase.db3";

        private static readonly object LOCKER = new object();

        public AppDatabase(string databaseFolderPath) //: base(path)
        {
            lock (LOCKER) //lock gerekir mi?
            {
                var dbFullPath = Path.Combine(databaseFolderPath, DbName);
                try
                {
                    _db = new SQLiteConnection(dbFullPath);

                    _db.CreateTable<TaskEntity>();
                    _db.CreateTable<Person>();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public virtual List<T> GetRecordList<T>() where T : IEntity, new()
        {
            lock (LOCKER)
            {
                return _db.Table<T>().ToList();
            }
        }

        public virtual T GetRecord<T>(int id) where T : IEntity, new()
        {
            lock (LOCKER)
            {
                //bu şekilde func dışarda tanımlanmazsa : NotSupportedException hatası alınıyor.
                Func<T, bool> where = x => x.Id == id;

                return _db.Table<T>().FirstOrDefault(where);
            }
        }

        /// <summary>
        /// if new record: Returns saved item's id 
        /// Else id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int SaveRecord<T>(T item) where T : IEntity, new()
        {
            lock (LOCKER)
            {
                if (item.Id > 0)
                {
                    _db.Update(item);
                    return item.Id;
                }
                else
                {
                    var itemId = _db.Insert(item);
                    return itemId;
                }
            }
        }

        public virtual bool DeleteRecord<T>(int id) where T : IEntity, new()
        {
            lock (LOCKER)
            {
                var success = false;
                if (id > 0)
                {
                    _db.Delete(id);
                    success = true;
                }
                return success;
            }
        }

    }
}
