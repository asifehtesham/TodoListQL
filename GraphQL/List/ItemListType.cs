using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL.List
{
    public class ItemListType : ObjectType<ItemListDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemListDto> descriptor)
        {
            descriptor.Description("This model is used as item from the list");
            descriptor.Field(x => x.Items)
                .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the items belongs to list");
        }

        private class Resolvers
        {
            public IQueryable<ItemDto> GetItems([Parent] ItemListDto ItemList, [ScopedService] ApiDbContext context)
            {
                return context.Items.Where(x => x.ListId == ItemList.Id);
            }
        }
    }
}
