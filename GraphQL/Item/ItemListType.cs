using Microsoft.EntityFrameworkCore;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL.List
{
    public class ItemType : ObjectType<ItemDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemDto> descriptor)
        {
            descriptor.Description("This model is used as item");
            descriptor.Field(x => x.ItemList)
                .ResolveWith<Resolvers>(x => x.GetList(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the list item belongs to");
        }

        private class Resolvers
        {
            public ItemListDto GetList(ItemDto item, [ScopedService] ApiDbContext context)
            {
                return context.Lists.Where(x => x.Id == item.ListId).SingleOrDefault();
            }
        }
    }
}
