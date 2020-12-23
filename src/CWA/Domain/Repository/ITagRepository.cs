using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(Guid tagId);
        Task<Tag> GetTagWithDetailsAsync(Guid tagId);
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
    }
}
