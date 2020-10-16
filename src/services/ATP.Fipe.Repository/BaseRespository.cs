using ATP.Fipe.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATP.Fipe.Repository
{
    public class BaseRespository<T> : IBaseRepository<T> where T : class
    {
        protected static IMongoClient Client => new MongoClient("mongodb+srv://admin:admin@clusterllpontes.isnb2.gcp.mongodb.net/fipe?retryWrites=true&w=majority");
        protected static IMongoDatabase Db => Client.GetDatabase("fipe");

        protected static IMongoCollection<T> Colecao;

        public BaseRespository(string colecao)
        {
            Colecao = Db.GetCollection<T>(colecao);
        }

        public virtual T Obter(string id)
        {
            return Colecao.Find(FiltroPorId(id)).FirstOrDefault();
        }

        public virtual IQueryable<T> Obter()
        {
            return Colecao.AsQueryable();
        }
        
        public virtual void Inserir(IList<T> modelo)
        {
            Colecao.InsertMany(modelo);
        }
        
        public virtual void Inserir(T modelo)
        {
            Colecao.InsertOne(modelo);
        }

        public virtual async Task InserirAsync(IList<T> modelo)
        {
            await Colecao.InsertManyAsync(modelo);
        }

        public virtual async Task InserirAsync(T modelo)
        {
            await Colecao.InsertOneAsync(modelo);
        }

        public virtual void Atualizar(T modelo)
        {
            Colecao.ReplaceOne(FiltroPorId(BsonTypeMapper.MapToDotNetValue(modelo.ToBsonDocument().GetElement("_id").Value).ToString()), modelo);
        }

        public virtual void Remover(string id)
        {
            Colecao.DeleteOne(FiltroPorId(id));
        }

        protected FilterDefinition<T> FiltroPorId(string id)
        {
            return Builders<T>.Filter.Eq("_id", new ObjectId(id));
        }
    }
}
