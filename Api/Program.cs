using Microsoft.AspNetCore.Mvc; //готовая библиотека для странички документации

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UserService>();


//var app = WebApplication.CreateBuilder(args).Build();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

/*app.MapGet("/seta", (int value) => a = value); //MapGet - вызывает функцию
app.MapDelete("/seta", () => a=0);
app.MapGet("/setb", (int value) => b = value);
app.MapGet("/sum", () => a+b);
app.MapGet("/mul", () => a*b);*/

//app.MapGet("/", () => "some text");

app.MapPost("/user/{id}", ([FromServices] UserService svc, int id)       => svc.Get(id) );
app.MapPost("/user", ([FromServices] UserService svc, UserCreate user) => svc.Create(user)); // в качестве аргумента передан класс
app.MapDelete("/user/{id}", ???); //написать функцию, которая удаляет пользователя
app.Run();

/*User GetUser (UserService svc, int id) {
    return new UserCreate(); 
}

void CreateUser (UserCreate user) {

}*/

//http://localhost:5023/swagger/index.html