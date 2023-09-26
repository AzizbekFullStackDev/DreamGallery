﻿using DreamGallery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamGallery.Service.DTOs.Artwork
{
    public class ArtworkForCreationDto
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Desciption { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public ArtCategory Category { get; set; }
    }
}
