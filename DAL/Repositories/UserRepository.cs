using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.DAL.Repositories.Interfaces;
using University.Domain.Entity;
using University.Dto;

namespace University.DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UniversityDbContext _db;
        private string secretKey;

        public UserRepository(UniversityDbContext db,IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");//инициализация ключа
        }

        public bool IsUiqueUser(string username)
        {
            var user =_db.User.FirstOrDefault(x=>x.UserName == username);//поиск информации о пользователе с UserName, который введён

            if (user == null) //пользователь ещё не зарегистрирован в базе данных
            
            { 
                return true;   //подтверждение того, что пользователь уникален         
            } 
            return false;//пользователь с таким UserName уже зарегистрирован в базе данных

        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = _db.User.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower()//поиск юзера в базе
            && u.Password == loginRequest.Password);

            if (user == null) //пользователь не был найден
            {
                return new LoginResponse()

                {
                    Token = "",
                    User = null//возвращаем null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();//иначе пользователь найден, генерируем jwt-токен
            var key = Encoding.ASCII.GetBytes(secretKey);//пеобразование ключа в массив байт и сохранение в переменной
            var tokenDescriptor = new SecurityTokenDescriptor// описаание токена
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),//токен содержит Id пользователя
                    new Claim(ClaimTypes.Role,user.Role)//токен содержит роль пользователя
                }),
                Expires = DateTime.UtcNow.AddDays(7),//период действия токена 
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)//симм. защит. ключ, шифр. подпись
            };
            var token=tokenHandler.CreateToken(tokenDescriptor);// создаём токен
            LoginResponse loginResponse = new LoginResponse()// возвращаемое значение
            {
                Token = tokenHandler.WriteToken(token),//сериализация токена
                User = user
            };
            return loginResponse;
        }

        public async Task<User> Register(RegisterUserRequest registertUserRequest)
        {
            User user = new User() // создаём нового пользователя
            {
                UserName = registertUserRequest.UserName,//заносим в базу данных инфо о новом пользователе
                Password = registertUserRequest.Password,
                Email = registertUserRequest.Email,
                Role = registertUserRequest.Role,

            };
            _db.User.Add(user);//добавляем пользователя в базу данных
            await _db.SaveChangesAsync();//сохраняем инфо в базе
            user.Password = "";
            return user;

        }
    }

   
}

