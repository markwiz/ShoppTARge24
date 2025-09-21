using System.Collections.Generic;
using System.Threading.Tasks;
using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<IEnumerable<KindergartenDto>> IndexAsync();
        Task<KindergartenDto?> DetailsAsync(int id);
        Task<KindergartenDto> CreateAsync(KindergartenDto dto);
        Task<KindergartenDto?> UpdateAsync(KindergartenDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

