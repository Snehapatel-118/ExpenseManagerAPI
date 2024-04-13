using ExpenseManagement;
using ExpenseManagement.Repository;
using ExpenseManagement.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionDict = new Dictionary<ConnectionStrings, string>
            {
                {ConnectionStrings.expenseManagement, builder.Configuration.GetConnectionString("expenseManagement") },
            };

builder.Services.AddSingleton<IDictionary<ConnectionStrings, string>>(connectionDict);
builder.Services.AddSingleton<IExpenseService, ExpenseRepo>();
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

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.WithExposedHeaders("Content-Disposition");
});


app.UseAuthorization();

app.MapControllers();

app.Run();
