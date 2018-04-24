using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Posts
{
    [Table("AppComments")]
    public class Comment:FullAuditedEntity<Guid>, IMustHaveTenant
    {
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public virtual Guid PostId { get; set; }


        [ForeignKey("UserId")]
        public virtual User Author { get; set; }
        public virtual long UserId { get; set; }

        [Required]
        public virtual string Text { get; set; }

        public virtual int Likes { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int TenantId { get; set; }

        protected Comment()
        {

        }

        public static Comment Create(Post @post, long userId, string text, int likes=0)
        {
            return new Comment
            {
                Post= @post,
                UserId=userId,
                Text=text,
                Likes=likes,
                TenantId=@post.TenantId,
                Date=System.DateTime.Now
            };
        }
    }

    
}
