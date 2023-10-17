using BusinessLogicLayer;
using DAL.Interfaces;
using DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<ICustomerBusiness,CustomerBusiness>();
builder.Services.AddTransient<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddTransient<IAuthorsBusiness, AuthorsBusiness>();
builder.Services.AddTransient<IGenresRepository, GenresRepository>();
builder.Services.AddTransient<IGenresBusiness, GenresBusiness>();
builder.Services.AddTransient<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddTransient<ISuppliersBusiness, SuppliersBusiness>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersBusiness, UsersBusiness>();
builder.Services.AddTransient<IBooksRepository, BooksRepository>();
builder.Services.AddTransient<IBooksBusiness, BooksBusiness>();
builder.Services.AddTransient<INotificationsRepository, NotificationsRepository>();
builder.Services.AddTransient<INotificationsBusiness, NotificationsBusiness>();
builder.Services.AddTransient<ICartsRepository, CartsRepository>();
builder.Services.AddTransient<ICartsBusiness, CartsBusiness>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<IOrdersBusiness, OrdersBusiness>();
builder.Services.AddControllers();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
