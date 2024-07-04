using IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

Api_BusinessLogic.ReglasService(builder.Services);
Api_BusinessLogic.ValidacionesService(builder.Services);
Api_BusinessLogic.LoggerService(builder.Services);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
