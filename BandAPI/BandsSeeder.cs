using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandAPI.Entities;

using Microsoft.EntityFrameworkCore;


namespace BandAPI
{
    public class BandsSeeder
    {
        private readonly BandDbContext _dbContext;

        public BandsSeeder(BandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (_dbContext.Database.IsRelational())
                {
                    var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                    if (pendingMigrations != null && pendingMigrations.Any())
                    {
                        _dbContext.Database.Migrate();
                    }
                }
        

                if (!_dbContext.Bands.Any())
                {
                    var bands = GetBands();
                    _dbContext.Bands.AddRange(bands);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Band> GetBands()
        {
            var bands = new List<Band>()
            {
                new Band()
                {
                    Name = "Tool",
                    DateOfFoundation = 1990,
                    IsActive = false,
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "Opiate",
                            DateOfRelease = 1990,
                        },

                        new Album()
                        {
                            Title = "Lateralus",
                            DateOfRelease = 2002,
                        },
                    },
                    Description = new Description()
                    {
                        Genres = "Alternative metal, progressive rock.",
            
                    },
                    Musicians = new List<Musician> 
                    { 
                        new Musician(){Name = "James Maynard Keenan", Role = "Vocal"},
                        new Musician(){Name = "Adam Jones", Role = "Guitar"}

                    },
                },
                new Band()
                {
                    Name = "Napalm Death",
                    DateOfFoundation = 1982,
                    IsActive = false,
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "Scum",
                            DateOfRelease = 1982,
                        },

                        new Album()
                        {
                            Title = "Utopia Banished",
                            DateOfRelease = 1994,
                        },
                    },

                     Description = new Description()
                    {
                        Genres = "Death metal, hardcore punk, grind core.",

                    },
                    Musicians = new List<Musician>
                    {
                        new Musician(){Name = "Mark Greenway ", Role = "Vocal"},
                        new Musician(){Name = "Lee Dorian", Role = "Vocal"}

                    },
                }
            };

            return bands;
        }
    }
}
