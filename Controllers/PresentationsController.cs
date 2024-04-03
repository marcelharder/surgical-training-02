namespace api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class PresentationsController : BaseApiController
    {
        private IPresentationService _repo;
    public PresentationsController(IPresentationService repo)
    {
        _repo = repo;
    }

    [HttpGet("dapper/specificPresentation/{id}", Name = "getDapperSpecificPresentation")]
    public async Task<IActionResult> getDapperSpecificDocument(int id)
    {
        var selected_document = await _repo.getSpecificPresentation(id);
        if (selected_document == null) { return BadRequest("Record not found"); }

        return Ok(selected_document);
    }

    [HttpPost("dapper/create_presentation/{userId}")]
    public async Task<IActionResult> createDapperDocument(int userId)
    {
        var new_document = new PresentationDetailsDto();

        new_document.Title = "";
        new_document.Media = "";
        new_document.Venue = "";
        new_document.UserId = userId;
        new_document.DatePresented = DateTime.UtcNow;
        var help = await _repo.CreatePresentation(new_document);
        return CreatedAtRoute("getDapperSpecificPresentation", new { id = help.PresentationId }, help);
    }

    [HttpPut("dapper/update_presentation")]
    public async Task<IActionResult> updateDapperDocument([FromBody] PresentationDetailsDto doc)
    {
        var selected_document = await _repo.getSpecificPresentation(doc.PresentationId);
        if (selected_document == null) { return BadRequest("Record not found"); }
        await _repo.UpdatePresentation(doc);
        var updated_Document = await _repo.getSpecificPresentation(doc.PresentationId);
        return Ok("presentation updated");
    }

    [HttpDelete("dapper/delete_presentation/{id}")]
    public async Task<IActionResult> deleteDapperDocument(int id)
    {
        await _repo.DeletePresentation(id);
        return Ok("document deleted");
    }
  
    [HttpGet("dapper/presentations/{id}")]
    public async Task<IActionResult> getAllDapperDocuments(int id)
    {
        var result = await _repo.GetPresentations(id);
        return Ok(result);
    }

    }
