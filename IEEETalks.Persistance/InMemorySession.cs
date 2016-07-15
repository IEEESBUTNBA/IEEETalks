using System;
using System.Collections.Generic;
using System.Linq;

namespace IEEETalks.Persistance
{
    public class InMemorySession : ISession
    {
        private readonly string _boundedContext;
        private static Dictionary<string, Dictionary<string, dynamic>> _collections;

        public InMemorySession(string boundedContext = "IEEETalks-Default")
        {
            _boundedContext = boundedContext;
            if (_collections == null)
            {
                _collections = new Dictionary<string, Dictionary<string, dynamic>>();
            }
        }

        private void EnsureCollectionExist<T>()
        {
            var exist = _collections.ContainsKey(GetCollectionName<T>());
            if (!exist)
                _collections.Add(GetCollectionName<T>(), new Dictionary<string, dynamic>());
        }

        public string GetCollectionName<T>()
        {
            return _boundedContext + "_" + typeof(T).Name;
        }

        public void Store<T>(string id, T item)
        {
            this.EnsureCollectionExist<T>();

            var result = (from x in _collections[GetCollectionName<T>()]
                          where x.Key == id
                          select x.Value).FirstOrDefault();

            if (result != null)
                this.Remove<T>(result.Id);

            _collections[GetCollectionName<T>()].Add(id, item);
        }

        public void Store<T>(Guid id, T item)
        {
            Store<T>(id.ToString(), item);
        }

        public void Remove<T>(string id)
        {
            this.EnsureCollectionExist<T>();

            var result = (from x in _collections[GetCollectionName<T>()]
                          where x.Key == id
                          select x.Value).FirstOrDefault();

            if (result != null)
                _collections[GetCollectionName<T>()].Remove(result);
        }

        public void Remove<T>(Guid id)
        {
            Remove<T>(id.ToString());
        }

        public T GetById<T>(string id)
        {
            this.EnsureCollectionExist<T>();

            var result = (from x in _collections[GetCollectionName<T>()]
                          where x.Key == id
                          select x.Value).FirstOrDefault();

            return result;
        }

        public T GetById<T>(Guid id)
        {
            return GetById<T>(id.ToString());
        }

        public IQueryable<T> GetQueryable<T>()
        {
            this.EnsureCollectionExist<T>();

            return _collections[GetCollectionName<T>()].Values.Cast<T>().AsQueryable();
        }
    }
}
