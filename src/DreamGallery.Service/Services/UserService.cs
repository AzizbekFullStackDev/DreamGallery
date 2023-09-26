using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Configurations;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.User;
using DreamGallery.Service.Exceptions;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class UserService : IUserService
    {
        private long _id;
        Repository<User> UserRepository = new Repository<User>();
        public string Path = PathDb.UsersDb;
        public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
        {
            await GenerateIdAsycAsync();
            var Check = (await UserRepository.SelectAllAsync()).FirstOrDefault(e => e.Email == dto.Email && e.Password == dto.Password);
            if(Check != null)
            {
                throw new DreamGalleryException(400, "This user exist in Database");
            }
            User user = new User()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                PhoneNumber = dto.PhoneNumber,
                PaymentMethod = dto.PaymentMethod,
                Role = Domain.Enums.Roles.User,
            };
            await UserRepository.InsertAsync(user);

            UserForResultDto result = new UserForResultDto()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName= dto.LastName,
                Email = dto.Email,
                Password= dto.Password,
                Balance= dto.Balance,
                PhoneNumber = dto.PhoneNumber,
                PaymentMethod = dto.PaymentMethod,
                Role = Domain.Enums.Roles.User,

            };
            return result;

        }

        public async Task<List<UserForResultDto>> GetAllAsync()
        {
            var GetALlData = await UserRepository.SelectAllAsync();
            List<UserForResultDto> ls = new List<UserForResultDto>();
            foreach (var item in GetALlData)
            {
                UserForResultDto dto = new UserForResultDto()
                {
                    Id= item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Balance = item.Balance,
                    PhoneNumber = item.PhoneNumber,
                    PaymentMethod = item.PaymentMethod,
                    Role = Domain.Enums.Roles.User,

                };
                ls.Add(dto);
                
            }
            return ls;
        }

        public async Task<UserForResultDto> GetByIdAsync(long Id)
        {
            var GetData = await UserRepository.SelectByIdAsync(Id);
            if (GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var result = new UserForResultDto()
            {
                Id = GetData.Id,
                FirstName = GetData.FirstName,
                LastName = GetData.LastName,
                Email = GetData.Email,
                Password = GetData.Password,
                PhoneNumber = GetData.PhoneNumber,
                Balance = GetData.Balance,
                PaymentMethod = GetData.PaymentMethod,
                Role = Domain.Enums.Roles.User,

            };
            return result;
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            var GetData = await UserRepository.SelectByIdAsync(Id);
            if (GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var Result = await UserRepository.DeleteAsync(Id);
            return Result;
        }

        public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
        {
            var Check = await UserRepository.SelectByIdAsync(dto.Id);
            if(Check == null)
            {
                throw new DreamGalleryException(404, "Not found");
            }
            var user = new User()
            {
                Id = Check.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                PaymentMethod = dto.PaymentMethod,
                PhoneNumber = dto.PhoneNumber,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = Check.CreatedAt,
                Role = Domain.Enums.Roles.User,

            };
            await UserRepository.UpdateAsync(user);

            var result = new UserForResultDto()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                Balance = dto.Balance,
                PaymentMethod = dto.PaymentMethod,
                Role = Domain.Enums.Roles.User,

            };

            return result;
        }
        public async Task GenerateIdAsycAsync()
        {
            var result = await UserRepository.SelectAllAsync();
            if(result.Count == 0)
            {
                _id = 1;
            }
            else
            {
                var res = result[result.Count-1];
                _id = ++res.Id;
            }
        }
    }
}
