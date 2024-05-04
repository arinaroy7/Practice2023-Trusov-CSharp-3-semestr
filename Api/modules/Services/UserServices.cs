/*using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;*/

public class UserService {

    int id = 0;
    Dictionary<int,User> users = new Dictionary<int, User> ();

    public int Create(UserCreate user)
    {
        users[++id] = new User() { Name = user.Name, Email = user.Email, Login = user.Login};
        return id;
    }

    public User Get (int id) {
        return users[id];
    }
}
