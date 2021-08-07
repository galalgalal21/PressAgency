using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_IA.Models
{
    public class Post
    {
        public int id { get; set; }

        [Display(Name = "Editor Name")]
        public string EditorName { get; set; }

        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }

        [Display(Name = "Article Body")]
        public string ArticleBody { get; set; }

        [Display(Name = "Article Image")]
        public string ArticleImage { get; set; }

        [Display(Name = "Article Type")]
        public int PostCategoryId { get; set; }
        public string UserId { get; set; }
        public int LikesCounter { set; get; }
        public int DisLikesCounter { set; get; }
        public string PostStatus { set; get; }
        public virtual PostCategory PostCategory { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}