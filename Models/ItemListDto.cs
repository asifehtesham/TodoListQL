namespace TodoListQL.Models
{
    public class ItemListDto
    {
        public ItemListDto() { 
            //Items = new HashSet<ItemDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
