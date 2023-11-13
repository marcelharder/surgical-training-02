namespace api.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Class_Epa, EpaDetailsDto>();
        CreateMap<EpaDetailsDto, Class_Epa>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Class_Course, CourseDetailsDto>();
        CreateMap<CourseDetailsDto, Class_Course>().ForMember(dest => dest.CourseId, opt => opt.Ignore());

        CreateMap<Class_Document, PdfForCreationDto>();
        CreateMap<PdfForCreationDto, Class_Document>().ForMember(dest => dest.DocumentId, opt => opt.Ignore());

        CreateMap<ProcedureForReturnDTO, Class_Procedure>();
    }
}
