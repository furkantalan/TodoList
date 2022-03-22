using ToDoList;
public static class AccountDatabaseBuilder
{

    static void SetDataToDB(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
        new Account
        {
            Id = 1,
            Email = "furkan.talan@sahabt.com",
            Password = "123",
        });
    }

    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.HasOne(e => e.user);


        });
        SetDataToDB(modelBuilder);
    }
}