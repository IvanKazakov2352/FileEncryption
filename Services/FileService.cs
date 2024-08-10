using FileEncryption.Models;

namespace FileEncryption.Services
{
    public class FileService : IFileService
    {
        private readonly ICryptoService _cryptoService;
        public FileService(ICryptoService cryptoService) 
        {
            _cryptoService = cryptoService;
        }
        public async Task<IResult> EncryptFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new FileNotFoundException("File not found");
            }
            byte[] encryptedData;
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();

            byte[] key = _cryptoService.GenerateRandomBytes(32);
            byte[] iv = _cryptoService.GenerateRandomBytes(16);

            encryptedData = _cryptoService.EncryptData(fileData, key, iv);
            return Results.File(encryptedData, "application/octet-stream", "encryptedFile.enc");
        }
    }
}
