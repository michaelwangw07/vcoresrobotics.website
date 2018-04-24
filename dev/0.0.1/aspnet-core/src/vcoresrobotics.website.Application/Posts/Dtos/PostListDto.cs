using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace vcoresrobotics.website.Posts.Dtos
{
    [AutoMapFrom(typeof(Post))]
    public class PostListDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public int CommentsCount { get; set; }
    }
}
