namespace DreamGallery.Data.IRepositories
{
    public interface IRepository<TEntity>
    {
        public Task<TEntity> InsertAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(long Id);
        public Task<TEntity> SelectByIdAsync(long Id);
        public Task<List<TEntity>> SelectAllAsync();
    }
}
