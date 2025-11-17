using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PutAndTakePondsController : Controller
    {
        IPutAndTakePondDAO _putAndTakePondDAO;
        public PutAndTakePondsController(IPutAndTakePondDAO putAndTakePondDAO)
        {
            _putAndTakePondDAO = putAndTakePondDAO;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PutAndTakePond>> Get()
        {
            try
            {
                return Ok(_putAndTakePondDAO.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to retrieve all blog posts.");
            }
        }

        [HttpGet("{phoneNumber}")]
        public ActionResult<PutAndTakePond> Get(string phoneNumber)
        {
            try
            {
                var post = _putAndTakePondDAO.GetOne(phoneNumber);
                if (post == null)
                {
                    return NoContent();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to retrieve the blog post with id {phoneNumber}.");
            }
        }

        // Route: [website]/Authors/{id}/BlogPosts
        [HttpGet("/PondOwners/{id}/PutAndTakePonds")]
        public ActionResult<IEnumerable<PutAndTakePond>> GetByPondOwner(int id)
        {
            try
            {
                var posts = _putAndTakePondDAO.GetByPondOwner(id);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to retrieve ponds for owner with id {id}.");
            }
        }

        [HttpPost]
        public ActionResult<int> Create(PutAndTakePond putAndTakePond)
        {
            try
            {
                return Ok(_putAndTakePondDAO.Create(putAndTakePond));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to create the blog post.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Update(int pondNumber, PutAndTakePond putAndtakePond)
        {
            try
            {
                if (putAndtakePond == null || pondNumber != putAndtakePond.PondNumber)
                {
                    return BadRequest("PutAndTakePond payload is null or id mismatch.");
                }

                var updated = _putAndTakePondDAO.Update(putAndtakePond);
                if (!updated)
                {
                    return NoContent();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to update the pond with number {pondNumber}.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleted = _putAndTakePondDAO.Delete(id);
                if (!deleted)
                {
                    return NoContent();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to delete the pond with id {id}.");
            }
        }
    }
}
