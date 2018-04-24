using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Posts
{
    public interface IPostManager:IDomainService
    {
        Task<Post> GetAsync(Guid Id);

        Task CreatePostAsync(Post @post);

        Task CreateCommentAsync(Comment @comment);
    }
}
