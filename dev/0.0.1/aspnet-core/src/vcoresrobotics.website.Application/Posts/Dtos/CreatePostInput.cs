using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vcoresrobotics.website.Posts.Dtos
{
    public class CreatePostInput
    {
        [Required]
        [StringLength(Post.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(Post.MaxSummaryLength)]
        public string Summary { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CatagoryId { get; set; }

    }
}
