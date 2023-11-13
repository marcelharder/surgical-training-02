namespace api.DAL.Mappings;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Class_Epa, EpaDetailsDto>();
        CreateMap<EpaDetailsDto, Class_Epa>().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Class_Document, pdfForReturnDto>();
        CreateMap<pdfForReturnDto, Class_Document>();

        CreateMap<PdfForCreationDto, Class_Document>().ForMember(dest => dest.DocumentId, opt => opt.Ignore());

        CreateMap<Class_Procedure, ProcedureForReturnDTO>();
    }
}


