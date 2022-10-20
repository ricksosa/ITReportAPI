using ITReportAPI.Models;

namespace ITReportAPI.Services
{
    public class BaseService<Entity> : IBaseService<Entity>
    {
        ITReportContext context;
        public BaseService(ITReportContext context)
        {
            this.context = context;
        }
        public Entity Create(Entity entity)
        {
            var result = this.context.Add(entity);
            return entity;
        }

        public Entity Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Entity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Entity Put(int id)
        {
            throw new NotImplementedException();
        }
    }
    public interface IBaseService<Entity>
    {
        ICollection<Entity> GetAll();
        Entity GetById(int id);
        Entity Create(Entity entity);
        Entity Put(int id);
        Entity Delete(int id);
    }
}