namespace ToDoList
{

    public class TodoListContext : DbContext
    {

        public DbSet<TodoItem>? TodoItems {get; set;}
        public DbSet<Account>? Accounts {get; set;}
        public DbSet<User>? Users { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        optionsBuilder.UseMySql("server=localhost;database=sahabt;user=root;port=3306;password=toortoor", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
        AccountDatabaseBuilder.TableBuilder(modelBuilder);
        TodoItemDatabaseBuilder.TableBuilder(modelBuilder);

        }
    }
}