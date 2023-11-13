using api.DAL.code;

namespace api.Controllers;
 
 [ApiController]
    [Route("api/[controller]")]
    public class CourseController : BaseApiController
    {
        private readonly IDapperCourseService _repo;
        private readonly SpecialMaps _spec;


        public CourseController(IDapperCourseService repo, SpecialMaps spec)
        {
            _repo = repo;
            _spec = spec;
        }

        [HttpGet("dapper/specificCourse/{id}", Name = "getDapperSpecificCourse")]
        public async Task<IActionResult> getDapperSpecificDocument(int id)
        {
            var selected_document = await _repo.getSpecificCourse(id);
            if (selected_document == null) { return BadRequest("Record not found"); }

            return Ok(_spec.MapToCourseDetailsDto(selected_document));
        }

        [HttpPost("dapper/create_course/{userId}")]
        public async Task<IActionResult> createDapperDocument(int userId)
        {
            var new_document = new CourseDetailsDto();

            new_document.description = "";
            new_document.diploma = "";
            new_document.price = 0F;
            new_document.userId = userId;
            new_document.active = false;
            new_document.venue_location = "";

            var help = await _repo.CreateCourse(new_document);

            return CreatedAtRoute("getDapperSpecificCourse", new { id = help.CourseId }, help);

        }

        [HttpGet("dapper/files/{id}")]
        public async Task<IActionResult> getAllDapperDocuments(int id)
        {
            var result = await _repo.GetCourses(id);
            return Ok(result);
        }

        [HttpPut("dapper/update_course")]
        public async Task<IActionResult> updateDapperDocument([FromBody] CourseDetailsDto doc)
        {
            var selected_document = await _repo.getSpecificCourse(doc.CourseId);
            if (selected_document == null) { return BadRequest("Record not found"); }
            await _repo.UpdateCourse(doc);
            var updated_Document = await _repo.getSpecificCourse(doc.CourseId);
            return Ok(updated_Document);
        }
      
        [HttpDelete("dapper/delete_course/{id}")]
        public async Task<IActionResult> deleteDapperDocument(int id)
        {
            await _repo.DeleteCourse(id);
            return Ok("document deleted"); 
        }
       
       







    }