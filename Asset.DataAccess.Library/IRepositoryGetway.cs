
using System.Collections.Generic;

namespace Asset.DataAccess.Library
{
    interface IRepositoryGetway<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        //IEnumerable<TEntity> Find();
        //TEntity SingleOrDefault();

        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        int Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);
    }
}
