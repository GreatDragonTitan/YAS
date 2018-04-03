using System.Linq;
using System.Threading.Tasks;
using YAS.Models.Records;

namespace YAS.Models.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<PostRecord> Posts { get; }

        Task Post(PostRecord post);

        Task Put(PostRecord post);

        Task Delete(int post);
    }
}