using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Posts.Dtos;

namespace vcoresrobotics.website.Posts
{
    public interface IPostAppService:IApplicationService
    {
        Task<ListResultDto<PostListDto>> GetPostListAsync();

        Task<PostDetailOutput> GetPostDetailAsync(EntityDto<Guid> input);

        Task CreatePostAsync(CreatePostInput input);

        Task CreateCommentAsync(CreateCommentInput input);
    }
}
