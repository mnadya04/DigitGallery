using DigitGallery.Models;
using DigitGallery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitGallery.DataProcessor
{
    public class DataSeeder
    {
        private DigitGalleryService service = new DigitGalleryService();

        public DataSeeder()
        {

            SeedDrawings();
        }
        public void SeedDrawings()
        {
            string imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmD5Fh7TZlWTT4wiY5lcnuBH4f1v_zU74bcA&usqp=CAU";

            if (service.GetDrawings().Any())
            {
                Console.WriteLine("Database is not empty!");
                return;
            }

            List<Artist> artists = new List<Artist>();
            for (int i = 0; i < 10; i++)
            {
                artists.Add(new Artist() { Name = $"Artist {i}" });
            }

            for (int i = 0; i < 30; i++)
            {
                Random random = new Random();
                string name = $"Drawing {i}";
                string price = $"{random.Next(1, 2000) * random.NextDouble()}";
                string artist = artists[random.Next(0, artists.Count - 1)].Name;
                service.AddDrawing(name, price, artist, imageUrl);
                Console.WriteLine($"Add drawing: {name}, price: {price}, category: {artist}");
            }
        }
    }
}
