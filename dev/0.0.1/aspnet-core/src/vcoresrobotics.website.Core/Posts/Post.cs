using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Posts
{
    
    [Table("AppPosts")]
    public class Post: FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;

        public const int MaxSummaryLength = 256;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        public virtual long UserId { get; set; }

        [StringLength(MaxSummaryLength)]
        public virtual string Summary { get; set; }

        public virtual string Tags { get; set; }

        public virtual string Content { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int TenantId { get; set; } 

        public virtual int Likes { get; set; }

        [ForeignKey("PostId")]
        public virtual ICollection<Comment> Comments { get; set; }


        protected Post()
        {

        }

        public static Post Create(int tenantId, string title, long userId, string summary, string tags, string content, int categoryId, int likes = 0)
        {
            var @post = new Post
            {
                Id=Guid.NewGuid(),
                Title=title,
                UserId= userId,
                Summary=summary,
                Tags=tags,
                Content=content,
                CategoryId=categoryId,
                Likes=likes,
                TenantId=tenantId,
                Date=System.DateTime.Now
            };

            @post.Comments = new Collection<Comment>();

            return @post;
        }
    }
}
