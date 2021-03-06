﻿using DAL;
using DL.Entities;
using DL.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly DataContext _context;

        public PhotoService(DataContext context)
        {
            _context = context;
        }

        public async Task AddPhoto(Photo photo)
        {
            _context.Photos.Add(photo);

            await _context.SaveChangesAsync();
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await _context.Photos.FindAsync(id);
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }
    }
}