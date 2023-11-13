namespace api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProcedureController : BaseApiController
    {
        private readonly IProcedureService _repo;
        private readonly SpecialMaps _spec;


        public ProcedureController(IProcedureService repo, SpecialMaps spec)
        {
            _repo = repo;
            _spec = spec;
        }


        [HttpGet("Procedures/{id}/{hos}")]
        public async Task<IActionResult> GetProcedures(int id, int hos)
        {
            var l = new List<Class_Procedure>();
            var ret = new List<ProcedureForReturnDTO>();
            l = await _repo.GetProcedures(id, hos);
            if(l.Count == 0){return BadRequest("no procedure found");}
            foreach(Class_Procedure cp in l){ret.Add(_spec.MapToProcDto(cp));}
            return Ok(ret);
        }

        [HttpGet("ProcedureDetails/{id}")]
        public async Task<IActionResult> GetEpaDetails(int id)
        {
            var l = await _repo.getSpecificProcedure(id);
            return Ok(l);
        }

    }