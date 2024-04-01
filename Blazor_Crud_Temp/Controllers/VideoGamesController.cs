using Blazor_Crud_Temp.Data;
using Blazor_Crud_Temp.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Crud_Temp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly DataContext _db;
        public VideoGamesController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAll()
        {
            return await _db.VideoGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> Get(int id)
        {
            var result = await _db.VideoGames.FindAsync(id);
            if(result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _db.VideoGames.FindAsync(id);
            if (result is null)
                return NotFound();

            _db.Remove(result);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<VideoGame>> Update(int id, VideoGame request)
        {
            var result = await _db.VideoGames.FindAsync(id);
            if (result is null)
                return NotFound();

            result.Title = request.Title ?? result.Title;
            result.Publisher = request.Publisher ?? result.Publisher;
            result.ReleaseYear = request.ReleaseYear ?? result.ReleaseYear;

            await _db.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<VideoGame>> Create(VideoGame request)
        {
            _db.Add(request);
            await _db.SaveChangesAsync();
            return Ok(request);
        }
    }
}
