namespace TodoListQL.GraphQL.Item
{
    public record AddItemInput(int listid, string title, string description, bool isDone);
}
