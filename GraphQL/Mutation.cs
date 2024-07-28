using TodoListQL.Data;
using TodoListQL.GraphQL.Item;
using TodoListQL.GraphQL.List;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
        {

            var list = new ItemListDto
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var item = new ItemDto
            {
                Title = input.title,
                Description = input.description,
                IsDone = input.isDone,
                ListId = input.listid,
//                ItemList = null
            };

            try {
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
            return new AddItemPayload(item);
        }
    }
}
