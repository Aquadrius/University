using University.Domain.Entity;
using University.Dto;
using LoginRequest = University.Dto.LoginRequest;

namespace University.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {

        bool IsUiqueUser(string username);//проверка уникальности идентификатора

        Task<LoginResponse> Login (LoginRequest loginRequest);//метод для входа зарегистрированного пользователя

        Task <User> Register (RegisterUserRequest registertUserRequest);//метод регистрации нового пользователя
    }
}