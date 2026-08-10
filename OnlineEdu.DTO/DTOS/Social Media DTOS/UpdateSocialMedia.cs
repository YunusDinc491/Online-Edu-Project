using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOS
{
    public class UpdateSocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Title { get; set; }
    }
}
