using ToDoList;

public interface IAccountRepository
{
    Task<List<Account>> GetAllAccounts();
    Task<Account> CreateAccount(Account account);
    Task<Account> GetAccountByEmail(string email);
    Task<Account> UpdateAccountByEmail(string email, Account account);
    Task<Account> UpdateAccountPassword(Account account,string oldpassword, string newpassword); 
    Account findAccountById(int id);
}