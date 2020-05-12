using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportFeedBack.Data;
using ReportFeedBack.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReportFeedBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : Controller
    {
        private readonly FeedBackDbContext _context;
        private readonly IMapper _mapper;
        public CommonController(FeedBackDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
       
        public IActionResult Post(VmVote vote)
        {
            var comment = _context.Comment.FirstOrDefault(f=>f.Id==vote.Id);
            if (comment == null) return BadRequest();
            comment.Like = vote.Like;
            comment.Dislike = vote.Dislike;
            _context.SaveChanges();
            return Ok();
        }

    }
}

