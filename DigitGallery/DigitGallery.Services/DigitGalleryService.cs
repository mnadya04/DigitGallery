namespace DigitGallery.Services
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class DigitGalleryService
    {
        private AppDbContext appContext = new AppDbContext();

        public ICollection<Drawing> GetDrawings (int page=1, int drawingsPerPage=8)
        {
            return appContext.Drawings.Skip((page-1)*drawingsPerPage).Take(drawingsPerPage).ToList();
        }

        public ICollection<Artist> GetArtists(int page = 1, int artistsPerPage = 8)
        {
            return appContext.Artists.Skip((page - 1) * artistsPerPage).Take(artistsPerPage).ToList();
        }

        public int DrawingsCount()
        {
            return this.appContext.Drawings.Count();
        }

        public Drawing GetDrawing(string name)
        {
            return appContext.Drawings.Find(name);
        }

        public Artist GetArtist(string name)
        {
           return appContext.Artists.Find(name);
            
        }
        public bool Login(string username, string password)
        {
            Artist user= appContext.Artists
                .FirstOrDefault(x => x.Name == username);
            
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }
        public int DrawingCount()
        {
            return this.appContext.Drawings.Count();
        }

        public void AddArtist(string artistName, string password)
        {
            if (string.IsNullOrWhiteSpace(artistName))
            {
                throw new ArgumentException("Invalid artist name!");
            }
            //Artist artist = appContext.Artists.FirstOrDefault(x => x.Name == artistName);
            Artist artist = new Artist()
            {
                Name = artistName,
                Password=password
            };
            appContext.Artists.Add(artist);
            appContext.SaveChanges();
        }

        public void AddDrawing(string name, double price, string artistName, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid drawing name!");
            }
            if (string.IsNullOrWhiteSpace(artistName))
            {
                throw new ArgumentException("Invalid artist!");
            }
            Artist artist = appContext.Artists.FirstOrDefault(x => x.Name == artistName);
            if (artist == null)
            {
                throw new ArgumentException("Invalid artist!");
            }
            Drawing drawing = new Drawing()
            {
                Name = name,
                Price = price,
                Artist = artist,
                ImageUrl = imageUrl
            };
            appContext.Drawings.Add(drawing);
            appContext.SaveChanges();
        }

        public void UpdateDrawingImageUrl(string name, string url)
        {
            Drawing drawing = GetDrawing(name);
            if (drawing == null)
            {
                throw new ArgumentException("Invalid drawing id!");
            }
            drawing.ImageUrl = url;
            appContext.Drawings.Update(drawing);
            appContext.SaveChanges();
        }

        public void UpdateProductPrice(string name, string price)
        {
            Drawing drawing = GetDrawing(name);
            if (drawing == null)
            {
                throw new ArgumentException("Invalid drawing id!");
            }
            if (!double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid drawing price!");
            }
            drawing.Price = double.Parse(price);
            appContext.Drawings.Update(drawing);
            appContext.SaveChanges();
        }

        public void UpdateArtistBio(string name, string bio)
        {
            Artist artist = GetArtist(name);
            if (artist==null)
            {
                throw new ArgumentException("Invalid artist id!");
            }
            artist.Bio = bio;
            appContext.Artists.Update(artist);
            appContext.SaveChanges();
        }

        public void DeleteDrawing(string name)
        {
            Drawing drawing = GetDrawing(name);
            if (drawing == null)
            {
                throw new ArgumentException("Invalid drawing id!");
            }
            appContext.Drawings.Remove(drawing);
            appContext.SaveChanges();
        }

    }
}
