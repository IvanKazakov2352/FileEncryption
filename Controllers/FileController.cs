using Microsoft.AspNetCore.Mvc;
using FileEncryption.Models;

namespace FileEncryption.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class FileController(IFileService fileService) : ControllerBase
    {

        [HttpPost("/file")]
        public async Task<IResult> EncryptFile([FromForm] IFormFile file)
        {
            try
            {
                return await fileService.EncryptFile(file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
