
using server.DTOs;
using server.Entities;
namespace server.Interface.Repository;

public interface IAddressRepository
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
    Task<AddressDto?> GetAddressByIdAsync(int id);
    Task<AddressDto> CreateAddressAsync(AddressDto addressDto);
    Task<IEnumerable<Address>> GetAddressesByUserIdAsync(int userId);
    Task<AddressDto?> UpdateAddressAsync(int id, AddressDto addressDto);
    Task<bool> DeleteAddressAsync(int id);

}
