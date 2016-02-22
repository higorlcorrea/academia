using Academia.Entity;
using AutoMapper;
using WebSite.Models;

namespace WebSite.Mappers
{
    public static class SimpleMapper
    {
        public static G Map<H, G>(H c)
            where H : class
            where G : class
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<H, G>()).CreateMapper();

            return mapper.Map<H, G>(c);
        }

    }
}