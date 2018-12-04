namespace BettingApp.Services.Mapping
{
	using AutoMapper;

	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfigurationExpression configuration);
	}
}
