namespace Application.Common.Mappers;

public interface IMapper<TFromObject, TToObject>
{
    TToObject Map(TFromObject fromObject);
}