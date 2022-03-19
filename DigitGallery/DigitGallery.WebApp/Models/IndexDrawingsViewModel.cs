using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitGallery.WebApp.Models
{
    public class IndexDrawingsViewModel
    {
        public ICollection<IndexDrawingViewModel> Drawings { get; set; }
        public int DrawingsCount { get; set; }
    }
}
