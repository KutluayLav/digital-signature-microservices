namespace SignatureService.Security;

public interface IHashService
{
    string ComputeHash(string input);
}
