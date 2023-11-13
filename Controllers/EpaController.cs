namespace api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EpaController : BaseApiController
    {
        private readonly IEpaService _repo;
        
      


        public EpaController(IEpaService repo)
        {
            _repo = repo;
          
           
        }


        [HttpGet("dapper/Epas/{id}")]
        public async Task<IActionResult> GetEpasDapper(int id)
        {
            var l = new List<EpaDetailsDto>();
            l = await _repo.getList_Dapper(id);

            if(l.Count == 0){ // er zijn geen epaas voor deze resident (use entityframework for this action now)
            l = await _repo.postEpa_Dapper(id);
            }
            return Ok(l);
        }
       
        [HttpGet("dapper/EpaDetails/{id}", Name = "GetDapperEpa")]
        public async Task<IActionResult> GetEpaDetailsDapper(int id)
        {
            var l = await _repo.getIndividualEpa_Dapper(id);
            return Ok(l);
        }

        [HttpPut("dapper/UpdateEpa")]
        public async Task<IActionResult> EditEpasDetailsDapper(EpaDetailsDto epd)
        {
            await _repo.updateDapperEpa(epd);
            return Ok();
        }

        [HttpDelete("dapper/DeleteEpa/{id}")]
        public async Task<IActionResult> DeleteEpaDetailsDapper(int id)
        {
            await _repo.deleteDapperEpaAsync(id);
            return Ok();
        }

       

       



    }