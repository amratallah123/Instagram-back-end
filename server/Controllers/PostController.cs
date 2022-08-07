using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using server.Entites;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [Route("api/users/{username}/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IInstagramRepository _repository;
        private readonly IMapper _mapper;
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;


        public PostController(IInstagramRepository repository, IMapper mapper, FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
               ?? throw new System.ArgumentNullException(
                   nameof(fileExtensionContentTypeProvider));
        }

        [HttpPost("{caption}")]
        public async Task<ActionResult> CreatePost(string username, string caption, IList<IFormFile>? files) {
            try
            {
                System.IO.Directory.CreateDirectory(@$"D:\web dev projects\instagram project\Instagram\server\photos\{username}");
                var post = new Post {Caption = caption };
                foreach (var file in files)
                {
                    if (file.Length <= 0)
                        return BadRequest("Empty file");

                    //Strip out any path specifiers (ex: /../)
                    var originalFileName = Path.GetFileName(file.FileName);
                    //Create a unique file path
                    var uniqueFileName = Path.GetRandomFileName();

                    var uniqueFilePath = Path.Combine(@$"D:\web dev projects\instagram project\Instagram\server\photos\{username}", originalFileName);
                    //Save the file to disk
                    using (var stream = System.IO.File.Create(uniqueFilePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var image = new Image { Photo = originalFileName, PostId = post.Id };
                    post.Images.Add(image);
                    
                }
                await  _repository.CreatePostAsync(username, post);
               await _repository.SaveChangesAsync();
               return Ok("post added");
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "OOPS! there is a problem in the server");
            }

        }
        [HttpGet("{postId}")]
        public async Task<ActionResult> GetPost(string username, string postId)
        {
            // look up the actual file, depending on the fileId...
            // demo code
            var post = await _repository.GetPostByIdAync(postId);
            if (post == null)
            {
                return NotFound("Post not found");
            }
            var pathToFile = @$"D:\web dev projects\instagram project\Instagram\server\photos\{username}\{post.Images.FirstOrDefault()}";
            
            // check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
              
                    return NotFound("sorry file not found");
                
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }   

    }
}
