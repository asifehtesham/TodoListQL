using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemListDto> GetList([ScopedService] ApiDbContext context) 
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemDto> GetItem([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}
