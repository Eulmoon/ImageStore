using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImageStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageStore.Controllers
{
    public class AddFileController : Controller
    {
        PicturesContext _storedb;
        IHostingEnvironment _appEnvironment;

        public AddFileController(PicturesContext storedb, IHostingEnvironment appEnvironment)
        {
            _storedb = storedb;
            _appEnvironment = appEnvironment;
        }

        // GET: /<controller>/
        public IActionResult AddFile()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedImage)
        {
            if (uploadedImage != null)
            {
                Random rnd = new Random();
                string path = "/Gallery/" + rnd.Next(0, 10000) + uploadedImage.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }
                Picture pic = new Picture { Name = uploadedImage.FileName, Path = path };
                var User = UserStore.GetCart(this.HttpContext);
                pic.UserId = User.GetCartId(this.HttpContext);
                _storedb.Pictures.Add(pic);               
                _storedb.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
