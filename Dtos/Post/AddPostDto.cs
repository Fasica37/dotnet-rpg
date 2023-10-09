using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Post
{
    public class AddPostDto
    {
        public string Title { get; set; } = "My title";
        public string Body { get; set; } = "Description about the post";
        public string imageUrl { get; set; } = "https://raw.githubusercontent.com/ethioclicks/ec-image/main/Zegulit/category_images/mens%20cloth/watch.png";
    }
}