using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImageStore.Models
{
    public class PicturesContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }

        public PicturesContext(DbContextOptions<PicturesContext> options)
            : base(options)
        { }
        
    }
} 
