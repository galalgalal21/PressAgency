using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace SysviewWeb.Models
{
    
}
namespace Project_IA.Models
{
    public class Comment
    {
        
        public int id { get; set; }
        public string comment { get; set; }
        public DateTime ApplyDate { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }

        public virtual Post post { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}