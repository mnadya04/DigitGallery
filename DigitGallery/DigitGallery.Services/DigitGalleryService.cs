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

        public Drawing GetDrawing(int id)
        {
            return appContext.Drawings.Find(id);
        }

        public Artist GetArtist(int id)
        {
            return appContext.Artists.Find(id);
        }

        public int DrawingCount()
        {
            return this.appContext.Drawings.Count();
        }

        public void AddArtist(string artistName, string bio)
        {
            if (string.IsNullOrWhiteSpace(artistName))
            {
                throw new ArgumentException("Invalid artist name!");
            }
            //Artist artist = appContext.Artists.FirstOrDefault(x => x.Name == artistName);
            Artist artist = new Artist()
            {
                Name = artistName,
                Bio=bio
            };
            appContext.Artists.Add(artist);
            appContext.SaveChanges();
        }

        public void AddDrawing(string name, string price, string artistName, string imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid drawing name!");
            }
            if (!double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid drawing price!");
            }
            if (string.IsNullOrWhiteSpace(artistName))
            {
                throw new ArgumentException("Invalid artist!");
            }
            Artist artist = appContext.Artists.FirstOrDefault(x => x.Name == artistName);
            if (artist == null)
            {
                artist = new Artist() { Name = artistName };
            }
            Drawing drawing = new Drawing()
            {
                Name = name,
                Price = double.Parse(price),
                Artist = artist,
                ImageUrl = imageUrl
            };
            appContext.Drawings.Add(drawing);
            appContext.SaveChanges();
        }

        public void UpdateDrawingImageUrl(int drawingId, string url)
        {
            Drawing drawing = GetDrawing(drawingId);
            if (drawing == null)
            {
                throw new ArgumentException("Invalid drawing id!");
            }
            drawing.ImageUrl = url;
            appContext.Drawings.Update(drawing);
            appContext.SaveChanges();
        }

        public void UpdateProductPrice(int drawingId, string price)
        {
            Drawing drawing = GetDrawing(drawingId);
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

        public void UpdateArtistBio(int artistId, string bio)
        {
            Artist artist = GetArtist(artistId);
            if (artist==null)
            {
                throw new ArgumentException("Invalid artist id!");
            }
            artist.Bio = bio;
            appContext.Artists.Update(artist);
            appContext.SaveChanges();
        }

        public void DeleteDrawing(int drawingId)
        {
            Drawing drawing = GetDrawing(drawingId);
            if (drawing == null)
            {
                throw new ArgumentException("Invalid drawing id!");
            }
            appContext.Drawings.Remove(drawing);
            appContext.SaveChanges();
        }

    }
}
