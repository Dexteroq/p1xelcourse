using System.Threading.Tasks;
using CourseWork.Areas.Identity.Data;
using CourseWork.Data;

namespace CourseWork.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _commentContext;

        public UserService(ApplicationDbContext commentContext)
        {
            _commentContext = commentContext;
        }

        public async Task AddUser(ApplicationUser user)
        {
            var newUser = new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
                // другие свойства, если нужно
            };

            _commentContext.ApplicationUser.Add(newUser);
            await _commentContext.SaveChangesAsync();
        }

        public async Task SyncUser(ApplicationUser user)
        {
            var existingUser = await _commentContext.ApplicationUser.FindAsync(user.Id);

            if (existingUser == null)
            {
                // Если пользователя нет в базе данных, добавляем его
                _commentContext.ApplicationUser.Add(user);
            }
            else
            {
                // Если пользователь уже есть в базе данных, обновляем его свойства
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                // Добавьте другие свойства, которые нужно синхронизировать
            }

            await _commentContext.SaveChangesAsync();
        }


    }
}
