using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);
            if (isUserNameExist) {
                return OperationResult.Error("نام کاربری تکراری است.");
            }
            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new DataLayer.Entities.User()
             {
                UserName = registerDto.UserName,
                IsDelete = false,
                FullName = registerDto.FullName,
                Role = DataLayer.Entities.UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash,
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }
        public UserDto LoginUser(LoginDto loginDto) 
        { 
            var hashedPassword = loginDto.Password.EncodeToMd5();
            var user = _context.Users.FirstOrDefault(u=>u.UserName == loginDto.UserName && u.Password == hashedPassword);
            
            if (user == null)
                return null;

            var userDto = new UserDto()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserId = user.Id            
            };
            return userDto;
        }
    }
}
