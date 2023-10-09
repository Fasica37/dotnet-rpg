using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.PostServices
{
    public interface IPostService
    {
        Task<ServiceResponse<List<GetPostDto>>> GetAllPosts();
        Task<ServiceResponse<GetPostDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newCharacter);
        Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto updateCharacter);
        Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id);
    }
}