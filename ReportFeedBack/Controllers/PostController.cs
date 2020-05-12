using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportFeedBack.Data;
using ReportFeedBack.Data.Entity;
using ReportFeedBack.ViewModel;

namespace ReportFeedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FeedBackDbContext _context;
        private readonly IMapper _mapper;
        public PostController(FeedBackDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string search, int page = 1, int pageSize = 3)
        {
            var posts = _context.Post.Include(f => f.Comments).Include("Comments.User").Include(f => f.User).Select(s => s);
            if (!string.IsNullOrEmpty(search))
            {
                posts = posts.Where(f => f.Title.ToLower().Contains(search.ToLower()));
            }

            var result = Paging<PostVm>.Create(_mapper.Map<List<PostVm>>(posts.ToList()), page, pageSize);

            return Ok(new VmPostResult
            {
                PageIndex = result.PageIndex,
                TotalCount = result.Count,
                Posts = result,
                HasPreviousPage = result.HasPreviousPage,
                HasNextPage = result.HasNextPage
            });
        }
        [HttpGet("{id}")]
     
        public ActionResult GetById(int id)
        {
            var post = _context.Post.Find(id);
            if (post == null) return NotFound();
            return Ok(post);
        }



        [HttpPost]
        public IActionResult Post(VmPostEntry post)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newPost = _mapper.Map<Post>(post);
            newPost.EntryDate = DateTime.Now;
            _context.Post.Add(_mapper.Map<Post>(newPost));
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newPost.Id }, post);
        }


        [HttpPut]
        public IActionResult Put(int id, VmPostEntry post)
        {
            var updatePost = _context.Post.FirstOrDefault(f => f.Id == id);
            if (updatePost == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();
            updatePost.ModifyDate = DateTime.Now;
            _mapper.Map(post, updatePost);
            _context.SaveChanges();
            return Ok(_mapper.Map<VmPostEntry>(updatePost));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletePost = _context.Post.FirstOrDefault(f => f.Id == id);
            if (deletePost == null) return NotFound();
            _context.Post.Remove(deletePost);
            _context.SaveChanges();
            return Ok(_mapper.Map<VmPostEntry>(deletePost));
        }
    }
}