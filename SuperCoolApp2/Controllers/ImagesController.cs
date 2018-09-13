using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperCoolApp2.Models;

namespace SuperCoolApp2.Controllers
{
    [Produces("application/json")]
    [Route("api/Images")]
    public class ImagesController : Controller
    {
        private readonly SuperCoolApp2Context _context;

        public ImagesController(SuperCoolApp2Context context)
        {
            _context = context;
        }

        // GET: api/Images
        // C#6.0 expression-bodied method
        [HttpGet("[action]")]
        public IEnumerable<Image> GetImages() => _context.Images;

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _context.Images.SingleOrDefaultAsync(m => m.ImageId == id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        [HttpPost]
        [Route("/api/upload")]
        public async Task<IActionResult> Upload(IFormFile fileForController)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fileForController == null) throw new Exception("File is null");
            if (fileForController.Length == 0) throw new Exception("File is empty");

            var theImage = new Image();
            var path = Path.Combine("~\\ClientApp\\app\\assets\\images\\", fileForController.FileName);

            theImage.Url = path + fileForController.FileName;
            theImage.Title = fileForController.Name + "_" + fileForController.FileName;
            theImage.Caption = fileForController.Name + " and then a Surprice Caption";

            using (Stream stream = fileForController.OpenReadStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    var fileContent = reader.ReadBytes((int)fileForController.Length);
                    //await _uploadService.AddFile(fileContent, fileForController.FileName, fileForController.ContentType);
                    theImage.ImageFileContent = fileContent;
                    _context.Images.Add(theImage);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return Ok(theImage);
        }
        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage([FromRoute] int id, [FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> PostImage([FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.ImageId }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _context.Images.SingleOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return Ok(image);
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
}