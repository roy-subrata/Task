using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportFeedBack.Data;
using ReportFeedBack.Data.Entity;
using ReportFeedBack.ViewModel;

namespace ReportFeedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly FeedBackDbContext _context;
        private readonly IMapper _mapper;
        public CommentController(FeedBackDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var comments = _context.Comment.ToList();
            return Ok(_mapper.Map<List<VmCommentResult>>(comments));
        }

        [HttpPost]
        public IActionResult Post(VmCommentEntry comment)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newComment = _mapper.Map<Comment>(comment);
            newComment.EntryDate = DateTime.Now;
            _context.Comment.Add(newComment);
            _context.SaveChanges();
            return Ok(_mapper.Map<VmCommentEntry>(newComment));
        }


        [HttpPut]
        public IActionResult Put(int id, VmCommentEntry comment)
        {
            var updateComment = _context.Comment.FirstOrDefault(f => f.Id == id);
            if (updateComment == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
             updateComment.ModifyDate = DateTime.Now;
            _mapper.Map(comment, updateComment);
            _context.SaveChanges();
            return Ok(_mapper.Map<VmCommentEntry>(updateComment));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletComment = _context.Comment.FirstOrDefault(f => f.Id == id);
            if (deletComment == null) return NotFound();
            _context.Comment.Remove(deletComment);
            _context.SaveChanges();
            return Ok(_mapper.Map<VmCommentEntry>(deletComment));
        }
    }
}