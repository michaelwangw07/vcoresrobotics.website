using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Posts
{
    public class PostManager:IPostManager
    {
        public IEventBus EventBus { get; set; }

        public IRepository<Post,Guid> _postRepository;

        public IRepository<Comment, Guid> _commentRepository;

        public PostManager(
            IRepository<Post,Guid> postRepository,
            IRepository<Comment,Guid> commentRepository
            )
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Post> GetAsync(Guid Id)
        {
            var @post =await _postRepository.FirstOrDefaultAsync(Id);
            if (@post == null) { throw new UserFriendlyException("无法获取，该文章或已删除！"); }
            return @post;
        }

        public async Task CreatePostAsync(Post @post)
        {
            await _postRepository.InsertAsync(@post);
        }

        public async Task CreateCommentAsync(Comment @comment)
        {
            await _commentRepository.InsertAsync(@comment);
        }
    }
}
