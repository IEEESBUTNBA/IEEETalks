using System;
using System.Linq;
using MongoDB.Driver;
using IEEETalks.Common;
using MongoDB.Bson;

namespace IEEETalks.CQS.Infrastructure
{
    public class Session : ISession
    {
        private readonly IMongoDatabase _database;

        public Session(string boundedContext = "IEEETalks-Default")
        {
            var client = new MongoClient(ApplicationSettings.DbConnectionString);

            _database = client.GetDatabase(boundedContext);
        }

        public void Store<T>(string id, T item)
        {
            //var filter = Builders<T>.Filter.Eq(s => s.Id, id);
            //var filter = Builders<T>.Filter.Eq("Id", id);
            var filter = new BsonDocument { { "_id", id } };
            CurrentCollection<T>().ReplaceOne(filter, item, new UpdateOptions() { IsUpsert = true });
        }

        public void Store<T>(Guid id, T item)
        {
            this.Store<T>(id.ToString(), item);
        }

        public void Remove<T>(string id)
        {
            var filter = new BsonDocument { { "_id", id } };
            CurrentCollection<T>().DeleteOne(filter);
        }

        public void Remove<T>(Guid id)
        {
            Remove<T>(id.ToString());
        }

        public T GetById<T>(string id)
        {
            var filter = new BsonDocument { { "_id", id } };
            return CurrentCollection<T>().Find(filter).FirstOrDefault();
        }

        public T GetById<T>(Guid id)
        {
            return GetById<T>(id.ToString());
        }

        private string GetCollectionName<T>()
        {
            return typeof(T).Name;
        }

        //public TOutput Aggregate<T, TOutput>(IEnumerable<BsonDocument> pipeline)
        //{
        //    var pipe = new AggregateArgs();

        //    pipe.Pipeline = pipeline;

        //    var result = CurrentCollection<T>().Aggregate(pipe);

        //    return BsonSerializer.Deserialize<TOutput>(result.ToJson());

        //}

        //public IEnumerable<BsonDocument> MapReduce<T>(string map, string reduce)
        //{
        //    var arg = new MapReduceArgs();

        //    arg.MapFunction = map;
        //    arg.ReduceFunction = reduce;
        //    //var result = CurrentCollection<T>().MapReduce(map, reduce).GetResults();

        //    return CurrentCollection<T>().MapReduce(arg).GetResults();//.GetResultsAs<TResult>().ToList();
        //}

        public IQueryable<T> GetQueryable<T>()
        {
            return CurrentCollection<T>().AsQueryable<T>();
        }

        private IMongoCollection<T> CurrentCollection<T>()
        {
            return _database.GetCollection<T>(GetCollectionName<T>());
        }
    }
}
