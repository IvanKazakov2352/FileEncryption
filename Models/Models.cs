namespace FileEncryption.Models
{
    public interface ICryptoService
    {
        byte[] GenerateRandomBytes(int length);
        byte[] EncryptData(byte[] data, byte[] key, byte[] iv);
        byte[] DecryptData(byte[] data, byte[] key, byte[] iv);
    }

    public interface IFileService
    {
        Task<IResult> EncryptFile(IFormFile file);
    }
}
