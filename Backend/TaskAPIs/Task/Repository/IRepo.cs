namespace Task.Context
{
    public interface IRepo
    {
        string EncryptAES(string plainText, string key, string iv);
        string DecryptAES(string encryptedText, string key, string iv);
    }
}
