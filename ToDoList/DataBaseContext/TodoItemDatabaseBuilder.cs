using ToDoList;
public static class TodoItemDatabaseBuilder
{

    static void SetDataToDB(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasData(
        new TodoItem
        {
            Id = 1,
            Title = "Günlük Temizlik",
            Description = "Oda Temizlenecek...",
        });
    }

    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.HasOne(e => e.account);

        });
        SetDataToDB(modelBuilder);
    }
}