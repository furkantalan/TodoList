using ToDoList;

public class AccountRepository : IAccountRepository
{


    private readonly TodoListContext _context;
    public AccountRepository(TodoListContext context)
    {
        _context = context;
    }
    public AccountRepository()
    {                                                                       
    }

    public async Task<Account> CreateAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public Account findAccountById(int id)
    {
        Account accountByID = (from x in _context.Accounts
                               where x.Id == id
                               select x).FirstOrDefault();
        return accountByID;
    }


    public async Task<Account> GetAccountByEmail(string email)
    {
        return await  _context.Set<Account>().SingleOrDefaultAsync(a=>a.Email==email);
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _context.Set<Account>().ToListAsync();
    }

    public async Task<Account> UpdateAccountByEmail(string email, Account account)
    {
        _context.Update(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> UpdateAccountPassword(Account account, string oldpassword, string newpassword)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
        return account;
    }
}
