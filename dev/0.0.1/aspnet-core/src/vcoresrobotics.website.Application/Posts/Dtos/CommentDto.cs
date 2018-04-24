using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace vcoresrobotics.website.Posts.Dtos
{
    [AutoMapFrom(typeof(Comment))]
    public class CommentDto: FullAuditedEntityDto<Guid>
    {
        public virtual Guid PostId { get; set; }

        public long UserId { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

        public DateTime Date { get; set; }
        
    }
}
