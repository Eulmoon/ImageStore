using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImageStore.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ImageStore.Controllers
{
    public class HomeController : Controller
    {

        PicturesContext _context;
        IHostingEnvironment _appEnvironment;

        public HomeController(PicturesContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        /*[HttpGet("set/{data}")]
        public IActionResult setsession(string data)
        {
            HttpContext.Session.SetString("MyCookie", data);
            return Ok("session data set");
        }

        [HttpGet("get")]
        public IActionResult getsessiondata()
        {
            var sessionData = HttpContext.Session.GetString("MyCookie");
            return Ok(sessionData);
        }*/

        public IActionResult Index()
        {
            var User = UserStore.GetCart(this.HttpContext);
            return View(_context.Pictures.Where(
              Picture => Picture.UserId == User.GetCartId(this.HttpContext)).ToList());
        }

        public ActionResult AddFile()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult AddFile(PictureViewModel PicV)
        {
            Picture picture = new Picture { };
            if (PicV.Image != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(PicV.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)PicV.Image.Length);
                }
                picture.Image = imageData;

                _context.Pictures.Add(picture);
                _context.SaveChanges();
            }

            return RedirectToAction("AddFile");
        }*/

        /*[HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedImage)
        {
            if (uploadedImage != null)
            {
                string path = "/Gallery/" + uploadedImage.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }
                Picture pic = new Picture { Name = uploadedImage.FileName, Path = path };
                //pic.PictureId = HttpContext.Session.GetString("MyCookie");
                _context.Pictures.Add(pic);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }*/

        public IActionResult Error()
        {
            return View();
        }
    }
}
