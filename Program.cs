using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TodoListQL.Data;
using TodoListQL.GraphQL;
using TodoListQL.GraphQL.List;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddPooledDbContextFactory<ApiDbContext>(optionsBuilder =>
{    
    optionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}); 

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ItemListType>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-ui", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
