using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.PostServices
{

    public class PostService : IPostService
    {

        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public PostService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            var dbPost = _mapper.Map<Post>(newPost);
            // dbPost.Id = posts.Max(c => c.Id) + 1;
            _context.Posts.Add(dbPost);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            try
            {
                var dbPost = await _context.Posts.FirstOrDefaultAsync(c => c.Id == id);
                if (dbPost == null)
                    throw new Exception($"Post with id '{id}' not found");
                _context.Posts.Remove(dbPost);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            var dbPost = await _context.Posts.ToListAsync();
            serviceResponse.Data = dbPost.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {

            var serviceResponse = new ServiceResponse<GetPostDto>();
            var dbPost = await _context.Posts.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetPostDto>(dbPost);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto updatedPost)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();
            try
            {
                var dbPost = await _context.Posts.FirstOrDefaultAsync(c => c.Id == updatedPost.Id);
                if (dbPost == null)
                    throw new Exception($"Post with id '{updatedPost.Id}' not found");
                dbPost.Title = updatedPost.Title;
                dbPost.Body = updatedPost.Body;
                dbPost.imageUrl = updatedPost.imageUrl;

                serviceResponse.Data = _mapper.Map<GetPostDto>(dbPost);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}