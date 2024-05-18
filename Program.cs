using AvidReaderBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// This code here is to create a CORS policy
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: "_allowances",
        policy => 
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>();

var app = builder.Build();

// This code here is to run the validation policy created above
app.UseCors("_allowances");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
