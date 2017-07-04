using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ImageStore.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        //public byte[] Image { get; set; }
        public string Path { get; set; }
    }
    /*public class PictureViewModel
    {
        public IFormFile Image { get; set; }
    }*/
}

