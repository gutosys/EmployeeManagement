using EmployeeManagement.Api;
using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();

//OBS:Camada de Segurança, comentado para fins de verificação de implementação
builder.AddValidation();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();

app.Run(); 
