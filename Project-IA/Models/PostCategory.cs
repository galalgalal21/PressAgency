using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_IA.Models
{
    public class PostCategory
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }

        [Required]
        [Display(Name = "Article Type")]
        public string ArticleType { get; set; }

        public virtual ICollection<Post> post { get; set; }


    }
}