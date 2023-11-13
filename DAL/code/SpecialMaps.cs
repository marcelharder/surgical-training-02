

namespace api.DAL.code;

    public class SpecialMaps
    {
        private IMapper _map;

        public SpecialMaps(IMapper map)
        {
            _map = map;
        }


        public EpaDetailsDto MapToEpaDetailsDto(Class_Epa help)
        {
            var h = new EpaDetailsDto();
            h = _map.Map<Class_Epa, EpaDetailsDto>(help);
            return h;
        }
        public Class_Epa MapToEpa(EpaDetailsDto cr, Class_Epa old)
        {
            return _map.Map<EpaDetailsDto, Class_Epa>(cr, old);
        }
        public CourseDetailsDto MapToCourseDetailsDto(Class_Course help)
        {
            var h = new CourseDetailsDto();
            h = _map.Map<Class_Course, CourseDetailsDto>(help);
            return h;
        }
        public Class_Course MapToCourse(CourseDetailsDto cr, Class_Course old)
        {
            return _map.Map<CourseDetailsDto, Class_Course>(cr, old);
        }

        public PdfForCreationDto MapToPdfDetailsDto(Class_Document help)
        {
            var h = new PdfForCreationDto();
            h = _map.Map<Class_Document, PdfForCreationDto>(help);
            return h;
        }
        public pdfForReturnDto MapToPdfReturnDto(Class_Document help)
        {
            var h = new pdfForReturnDto();
            h = _map.Map<Class_Document, pdfForReturnDto>(help);
            return h;
        }
        public Class_Document MapToDocument(PdfForCreationDto cr, Class_Document old)
        {
            return _map.Map<PdfForCreationDto, Class_Document>(cr, old);
        }
        
        public ProcedureForReturnDTO MapToProcDto(Class_Procedure proc)
        {
            return _map.Map<Class_Procedure, ProcedureForReturnDTO>(proc);
        }
      

    }

