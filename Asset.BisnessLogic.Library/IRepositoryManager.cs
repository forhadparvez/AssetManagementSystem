using System.Collections.Generic;

namespace Asset.BisnessLogic.Library
{
    interface IRepositoryManager<TEntity> where TEntity : class
    {

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        int Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);

    }
}
