using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;

namespace vcoresrobotics.website.Posts.Dtos
{
    [AutoMapFrom(typeof(Post))]
    public class PostDetailOutput : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Summary { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public int CommentsCount { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
