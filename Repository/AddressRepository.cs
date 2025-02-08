using server.DTOs;
using server.Entities;
using Microsoft.EntityFrameworkCore;
using server.Interface.Repository;
using server.Data;

namespace server.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContex _context;
        public AddressRepository(DataContex context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
        {
            var addresses = await _context.Address.ToListAsync();
            return addresses.Select(a => new AddressDto
            {
                Id = a.Id,
                Street = a.Street,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode,
                Country = a.Country,
                UserId = a.UserId
            }).ToList();
        }

        public async Task<AddressDto?> GetAddressByIdAsync(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null) return null;

            return new AddressDto
            {
                Id = address.Id,
                Street = address.Street,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                UserId = address.UserId
            };
        }


        public async Task<AddressDto> CreateAddressAsync(AddressDto addressDto)
        {
            // Check if the UserId exists in the database
            var userExists = await _context.users.AnyAsync(u => u.UserId == addressDto.UserId);
            if (!userExists)
            {
                throw new Exception($"User with UserId {addressDto.UserId} does not exist.");
            }

            // Create a new Address entity
            var address = new Address
            {
                Street = addressDto.Street,
                AddressLine2 = addressDto.AddressLine2,
                City = addressDto.City,
                State = addressDto.State,
                PostalCode = addressDto.PostalCode,
                Country = addressDto.Country,
                UserId = addressDto.UserId
            };

            try
            {
                // Save the address to the database
                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                // Return the saved address as a DTO
                return new AddressDto
                {
                    Street = address.Street,
                    AddressLine2 = address.AddressLine2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    UserId = address.UserId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Database save failed: {ex.InnerException?.Message}");
            }
        }
        public async Task<IEnumerable<Address>> GetAddressesByUserIdAsync(int userId)
        {
            return await _context.Address
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<AddressDto?> UpdateAddressAsync(int id, AddressDto addressDto)
        {
            var existingAddress = await _context.Address.FindAsync(id);
            if (existingAddress == null) return null;

            existingAddress.Street = addressDto.Street;
            existingAddress.AddressLine2 = addressDto.AddressLine2;
            existingAddress.City = addressDto.City;
            existingAddress.State = addressDto.State;
            existingAddress.PostalCode = addressDto.PostalCode;
            existingAddress.Country = addressDto.Country;

            await _context.SaveChangesAsync();
            return addressDto;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null) return false;

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
