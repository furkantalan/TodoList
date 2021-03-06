using ToDoList;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository; 
    }

    public async Task<Account> CreateNewAccount(Account account)
    {
        return await _accountRepository.CreateAccount(account);
    }

    public async Task<Account> GetAccountByEmail(string email)
    {
        return await _accountRepository.GetAccountByEmail(email);
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _accountRepository.GetAllAccounts();
    }

    public async Task<Account> UpdateAccountByEmail(Account account, string email)
    {
        return await _accountRepository.UpdateAccountByEmail(email, account);
    }

    public async Task<Account> UpdateAccountPassword(Account account, string oldpassword, string newpassword)
    {
        return await _accountRepository.UpdateAccountPassword(account, oldpassword, newpassword);
    }
}
