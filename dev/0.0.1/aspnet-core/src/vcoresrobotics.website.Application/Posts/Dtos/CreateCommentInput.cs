using System;
using System.ComponentModel.DataAnnotations;

namespace vcoresrobotics.website.Posts.Dtos
{
    public class CreateCommentInput
    {
        public Guid PostId { get; set; }
        [Required]
        public string Text { get; set; }

    }
}
