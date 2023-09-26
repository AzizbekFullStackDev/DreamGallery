using DreamGallery.Data.IRepositories;
using DreamGallery.Domain.Commons;
using DreamGallery.Domain.Configurations;
using DreamGallery.Domain.Entities;
using Newtonsoft.Json;

namespace DreamGallery.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        public string Path;
        public Repository()
        {
            if(typeof(TEntity) == typeof(Artist))
            {
                this.Path = PathDb.ArtistsDb;
            }
            else if(typeof(TEntity) == typeof(Artwork))
            {
                this.Path = PathDb.ArtworksDb;
            }
            else if(typeof(TEntity) == typeof(Exhibition))
            {
                this.Path = PathDb.ExhibitionsDb;
            }
            else if(typeof(TEntity) == typeof(Purchase))
            {
                this.Path = PathDb.PurchaseDb;
            }
            else if(typeof(TEntity) == typeof(User))
            {
                this.Path = PathDb.UsersDb;
            }
            var str = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(str))
            {
                File.WriteAllText(Path, "[]");
            }
        }
        public async Task<bool> DeleteAsync(long Id)
        {
            var AllData = await SelectAllAsync();
            var RemovedData = AllData.FirstOrDefault(e => e.Id == Id);
            AllData.Remove(RemovedData);
            var result = JsonConvert.SerializeObject(AllData, Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);
            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var AllData = await SelectAllAsync();
            AllData.Add(entity);
            var result = JsonConvert.SerializeObject(AllData, Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);
            return entity;
        }

        public async Task<List<TEntity>> SelectAllAsync()
        {
            var GetData = await File.ReadAllTextAsync(Path);
            var result = JsonConvert.DeserializeObject<List<TEntity>>(GetData);
            return result;
        }

        public async Task<TEntity> SelectByIdAsync(long Id)
        {
            return (await SelectAllAsync()).FirstOrDefault(e => e.Id == Id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var AllData = await SelectAllAsync();
            await File.WriteAllTextAsync(Path, "[]");
            foreach (var item in AllData)
            {
                if(item.Id == entity.Id)
                {
                    await InsertAsync(entity);
                    continue;
                }
                await InsertAsync(item);
            }
            return entity;
        }
    }
}
