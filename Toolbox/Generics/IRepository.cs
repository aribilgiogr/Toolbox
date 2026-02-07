using System.Linq.Expressions;
using Utilities.Bases;

namespace Utilities.Generics
{
    // Asenkron kodlama, yapmak istediğimiz işlemleri paralel (eşzamanlı) olarak yapmamızı sağlar, bu sayede bu işlemler yapılırken diğer işlemler etkilenmez.
    // Task -> void metot olarak çalışır.
    // Task<T> -> return type metot olarak çalışır
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        // CRUD İşlemleri:
        Task CreateAsync(TEntity entity);
        Task CreateManyAsync(IEnumerable<TEntity> entities);

        Task<TEntity?> FindByIdAsync(object entityKey);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<IQueryable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);

        Task UpdateAsync(TEntity entity);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity, bool soft_delete = true);
        Task DeleteManyAsync(IEnumerable<TEntity> entities, bool soft_delete = true);

        // Kontrol ve Sayma İşlemleri
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
