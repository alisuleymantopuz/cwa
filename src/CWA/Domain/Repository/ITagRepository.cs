using Domain.Pagination;
using System; 
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        Task<PagedList<Tag>> GetTagsAsync(TagParameters tagsParameters);
        Task<Tag> GetTagByIdAsync(Guid tagId);
        Task<Tag> GetTagWithDetailsAsync(Guid tagId);
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
    }
}
