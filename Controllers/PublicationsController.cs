namespace api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class PublicationsController : BaseApiController
    {
         private IPublicationService _repo;
    public PublicationsController(IPublicationService repo)
    {
        _repo = repo;
    }
    [HttpGet("dapper/specificPublication/{id}", Name = "getDapperSpecificPublication")]
    public async Task<IActionResult> getDapperSpecificDocument(int id)
    {
        var selected_document = await _repo.getSpecificPublication(id);
        if (selected_document == null) { return BadRequest("Record not found"); }

        return Ok(selected_document);
    }

    [HttpPost("dapper/create_publication/{userId}")]
    public async Task<IActionResult> createDapperDocument(int userId)
    {
        var new_document = new PublicationDetailsDto();

        new_document.PublicationId = 0;
        new_document.UserId = userId;
        new_document.Author = "";
        new_document.Title = "";
        new_document.Volume = "";
        new_document.Issue = "";
        new_document.PlaceOfPublication = "";
        new_document.Publisher = "";
        new_document.Editor = "";
        new_document.DateOfPublication = DateTime.UtcNow;
        new_document.URL = "";
        new_document.DOI = "";


        var help = await _repo.CreatePublication(new_document);
        return CreatedAtRoute("getDapperSpecificPublication", new { id = help.PublicationId }, help);
    }

    [HttpPut("dapper/update_publication")]
    public async Task<IActionResult> updateDapperDocument([FromBody] PublicationDetailsDto doc)
    {
        var selected_document = await _repo.getSpecificPublication(doc.PublicationId);
        if (selected_document == null) { return BadRequest("Record not found"); }
        await _repo.UpdatePublication(doc);
        var updated_Document = await _repo.getSpecificPublication(doc.PublicationId);
        return Ok("publication updated");
    }

    [HttpDelete("dapper/delete_publication/{id}")]
    public async Task<IActionResult> deleteDapperDocument(int id)
    {
        await _repo.DeletePublication(id);
        return Ok("document deleted");
    }

    [HttpGet("dapper/publications/{id}")]
    public async Task<IActionResult> getAllDapperDocuments(int id)
    {
        var result = await _repo.GetPublications(id);
        return Ok(result);
    }

    }
