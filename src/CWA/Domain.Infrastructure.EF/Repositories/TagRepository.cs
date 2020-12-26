using Domain.Pagination;
using Domain.Repository;
using Domain.Sorting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        private ISortHelper<Tag> _sortHelper;

        public TagRepository(RepositoryContext repositoryContext, ISortHelper<Tag> sortHelper)
           : base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }

        public void CreateTag(Tag tag)
        {
            Create(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Delete(tag);
        }
        public async Task<Tag> GetTagByIdAsync(Guid tagId)
        {
            return await this.RepositoryContext.Tags.FirstOrDefaultAsync(tag => tag.Id == tagId);
        }

        public async Task<PagedList<Tag>> GetTagsAsync(TagParameters tagsParameters)
        {
            var tags = FindAll();

            SearchByName(ref tags, tagsParameters.Name);

            var sortedTags = _sortHelper.ApplySort(tags, tagsParameters.OrderBy);

            return await PagedList<Tag>.ToPagedList(sortedTags, tagsParameters.PageNumber, tagsParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Tag> tags, string tagName)
        {
            if (!tags.Any() || string.IsNullOrWhiteSpace(tagName))
                return;

            tags = tags.Where(o => o.Name.ToLower().Contains(tagName.Trim().ToLower()));
        }

        public async Task<Tag> GetTagWithDetailsAsync(Guid tagId)
        {
            return await FindByCondition(Tag => Tag.Id == tagId)
                        .Include(ac => ac.ProductsTags)
                        .ThenInclude(ac => ac.Product)
                        .FirstOrDefaultAsync();
        }

        public void UpdateTag(Tag tag)
        {
            Update(tag);
        }
    }
}
