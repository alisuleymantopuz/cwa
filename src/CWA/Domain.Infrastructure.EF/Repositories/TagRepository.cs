using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateTag(Tag tag)
        {
            Create(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Delete(tag);
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await FindAll()
                        .OrderBy(p => p.Name)
                        .ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(Guid tagId)
        {
            return await FindByCondition(Tag => Tag.Id.Equals(tagId))
                        .FirstOrDefaultAsync();
        }

        public async Task<Tag> GetTagWithDetailsAsync(Guid tagId)
        {
            return await FindByCondition(Tag => Tag.Id.Equals(tagId))
                        .Include(ac => ac.ProductsTags)
                        .ThenInclude(x => x.Product)
                        .FirstOrDefaultAsync();
        }

        public void UpdateTag(Tag tag)
        {
            Update(tag);
        }
    }
}
