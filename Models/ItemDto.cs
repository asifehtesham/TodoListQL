namespace TodoListQL.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public bool IsDone{ get; set; }
        public int ListId{ get; set; }
        public virtual ItemListDto? ItemList { get; set; }  = new ItemListDto();
    }
}
