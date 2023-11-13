

[ApiController]
[Route("api/[controller]")]
public class PdfController : BaseApiController
{
    
    private readonly IDocumentService _doc;
    private IPhotoService _ps;
    private SpecialMaps _spec;

    public PdfController(
        
        IPhotoService ps,
        SpecialMaps spec,
        IDocumentService doc
        )
    {
       
        _ps = ps;
        _spec = spec;
        _doc = doc;
    }

    [HttpGet("dapper/specificfile/{id}", Name = "getDapperSpecificPdf")]
    public async Task<IActionResult> getDapperSpecificDocument(int id)
    {
        var selected_document = await _doc.getSpecificFile(id);
        if (selected_document == null) { return BadRequest("Record not found"); }

        return Ok(_spec.MapToPdfDetailsDto(selected_document));
    }

    [HttpPost("dapper/create_document/{userId}")]
    public async Task<IActionResult> createDapperDocument(int userId)
    {
        var new_document = new PdfForCreationDto();

        new_document.Description = "mijn verhaal";
        new_document.Document_url = "";
        new_document.PublicId = "";
        new_document.UserId = userId;
        new_document.Finished = false;
        new_document.Type = 3;

        var help = await _doc.Create(new_document);


        return CreatedAtRoute("getDapperSpecificPdf", new { id = help.DocumentId }, help);

    }

    [HttpGet("dapper/files/{id}")]
    public async Task<IActionResult> getAllDapperDocuments(int id)
    {
        var result = await _doc.getFiles(id);
        return Ok(result);
    }

    [HttpPut("dapper/update_document")]
    public async Task<IActionResult> updateDapperDocument([FromBody] PdfForCreationDto doc)
    {
        var selected_document = await _doc.getSpecificFile(doc.DocumentId);
        if (selected_document == null) { return BadRequest("Record not found"); }
        await _doc.Update(doc);
        var updated_Document = await _doc.getSpecificFile(doc.DocumentId);
        return Ok(updated_Document);
    }

    [HttpDelete("dapper/delete_document/{id}")]
    public async Task<IActionResult> deleteDapperDocument(int id)
    {
        var selected_document = await _doc.getSpecificFile(id);
        if (selected_document.PublicId != "" && selected_document.PublicId != null)
        {
            await _ps.DeletePhotoAsync(selected_document.PublicId); // remove the asset on cloudinary
        }

        await _doc.Delete(id);
        return Ok("document deleted");
    }

    [HttpPost("dapper/upload-pdf/{id}")] // id is document id here
    public async Task<IActionResult> dapperUploadPdf(int id, IFormFile file)
    {
        // get the correct document
        var selected_document = await _doc.getSpecificFile(id);
        if (selected_document == null) { return BadRequest("Record not found"); }

        var result = await _ps.AddPhotoAsync(file);
        if (result.Error != null) { return BadRequest(result.Error.Message); }

        selected_document.Document_url = result.SecureUrl.AbsoluteUri;
        selected_document.PublicId = result.PublicId;

        PdfForCreationDto p = _spec.MapToPdfDetailsDto(selected_document);

        await _doc.Update(p);

        return Ok(new pdfForReturnDto
        {
            Document_url = selected_document.Document_url,
            PublicID = selected_document.PublicId
        });

    }

}
