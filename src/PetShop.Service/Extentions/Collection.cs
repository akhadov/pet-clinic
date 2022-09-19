using PetShop.Domain.Configurations;

namespace PetShop.Service.Extentions
{
    public static class Collection
    {
        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            return @params.PageSize >= 0 && @params.PageIndex >= 0
                   ? source.Skip((@params.PageSize - 1) * @params.PageIndex).Take(@params.PageSize) : source;
        }

    }
}
