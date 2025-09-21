using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;

namespace ShopTARge24.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARge24Context _context;
        public KindergartenServices(ShopTARge24Context context) => _context = context;

        public async Task<IEnumerable<KindergartenDto>> IndexAsync() =>
            await _context.Kindergartens
                .OrderBy(k => k.Id)
                .Select(k => new KindergartenDto
                {
                    Id = k.Id,
                    GroupName = k.GroupName,
                    ChildrenCount = k.ChildrenCount,
                    KindergartenName = k.KindergartenName,
                    TeacherName = k.TeacherName,
                    CreatedAt = k.CreatedAt,
                    UpdatedAt = k.UpdatedAt
                })
                .ToListAsync();

        public async Task<KindergartenDto?> DetailsAsync(int id) =>
            await _context.Kindergartens
                .Where(k => k.Id == id)
                .Select(k => new KindergartenDto
                {
                    Id = k.Id,
                    GroupName = k.GroupName,
                    ChildrenCount = k.ChildrenCount,
                    KindergartenName = k.KindergartenName,
                    TeacherName = k.TeacherName,
                    CreatedAt = k.CreatedAt,
                    UpdatedAt = k.UpdatedAt
                })
                .FirstOrDefaultAsync();

        public async Task<KindergartenDto> CreateAsync(KindergartenDto dto)
        {
            var entity = new Kindergarten
            {
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                TeacherName = dto.TeacherName,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = null
            };

            _context.Kindergartens.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            return dto;
        }

        public async Task<KindergartenDto?> UpdateAsync(KindergartenDto dto)
        {
            var entity = await _context.Kindergartens.FindAsync(dto.Id);
            if (entity == null) return null;

            entity.GroupName = dto.GroupName;
            entity.ChildrenCount = dto.ChildrenCount;
            entity.KindergartenName = dto.KindergartenName;
            entity.TeacherName = dto.TeacherName;
            entity.UpdatedAt = System.DateTime.Now;

            await _context.SaveChangesAsync();
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Kindergartens.FindAsync(id);
            if (entity == null) return false;

            _context.Kindergartens.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
