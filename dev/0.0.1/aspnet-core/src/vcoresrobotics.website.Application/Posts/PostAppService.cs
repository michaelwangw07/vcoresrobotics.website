using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Posts.Dtos;

namespace vcoresrobotics.website.Posts
{
    [AbpAuthorize]
    public class PostAppService: websiteAppServiceBase,IPostAppService
    {
        private readonly IPostManager _postManager;
        private readonly IRepository<Post, Guid> _postRepository;
        private readonly IRepository<Comment, Guid> _CommentRepository;

        public PostAppService(
            IPostManager postManager,
            IRepository<Post,Guid> postRepository,
            IRepository<Comment,Guid> commentRepository
            )
        {
            _postManager = postManager;
            _postRepository = postRepository;
            _CommentRepository = commentRepository;

        }

        public async Task<ListResultDto<PostListDto>> GetPostListAsync()
        {
            var posts = await _postRepository
                .GetAll()
                .Include(p=>p.Comments)
                .ThenInclude(r=>r.Author)
                .OrderByDescending(p => p.CreationTime)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<PostListDto>(posts.MapTo<List<PostListDto>>());
        }

        public async Task<PostDetailOutput> GetPostDetailAsync(EntityDto<Guid> input)
        {
            var @post = await _postRepository
                .GetAll()
                .Include(p => p.Comments)
                .Where(p=>p.Id==input.Id)
                .FirstOrDefaultAsync();

            if (@post == null)
            {
                throw new UserFriendlyException("获取失败，该文章或已删除！");
            }

            return @post.MapTo<PostDetailOutput>();
        }

        public async Task CreatePostAsync(CreatePostInput input)
        {
            var @post = Post.Create(AbpSession.GetTenantId(),input.Title, AbpSession.GetUserId(),input.Summary,input.Tags,input.Content,input.CatagoryId);
            await _postManager.CreatePostAsync(@post);
        }

        public async Task CreateCommentAsync(CreateCommentInput input)
        {
            var @post =await _postManager.GetAsync(input.PostId);
            var @comment = Comment.Create(@post, AbpSession.GetUserId(),input.Text);
            await _postManager.CreateCommentAsync(@comment);
        }
    }
}
