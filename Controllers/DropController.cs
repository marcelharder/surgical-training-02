namespace Cardiohelp.Controllers;

    public class DropController : BaseApiController
    {
        private Dropdownlists _drops;
        private readonly IEpaService _repo;

        public DropController(Dropdownlists drops,  IEpaService repo)
        {
            _drops = drops;
            _repo = repo;
        }
       
        [Route("epadefinition")]
        [HttpGet]
        [AllowAnonymous]
        public List<EpaDefinitionDto> getDefinition(){
            return  _drops.getEpaDefinition();
        }

        
    }
