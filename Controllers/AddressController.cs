using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs;
using server.Entities;
using server.Interface.Repository;
using server.Repository;

namespace server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository _addressService;
    private readonly DataContex _dataContex;

    public AddressController(IAddressRepository addressService, DataContex dataContex)
    {
        _addressService = addressService;
        _dataContex = dataContex;
    }

    // GET: api/address
    [HttpGet]
    public async Task<IActionResult> GetAllAddresses()
    {
        var addresses = await _addressService.GetAllAddressesAsync();
        return Ok(addresses);
    }

    // GET: api/address/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var address = await _addressService.GetAddressByIdAsync(id);
        if (address == null) return NotFound("Address not found.");
        return Ok(address);
    }

    // POST: api/address
    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody] AddressDto addressDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var createdAddress = await _addressService.CreateAddressAsync(addressDto);
            return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

     
    }
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserAddresses(int userId)
    {
        var addresses = await _addressService.GetAddressesByUserIdAsync(userId);
        if (addresses == null || !addresses.Any())
        {
            return NotFound(new { message = "No addresses found for this user." });
        }
        return Ok(addresses);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDto addressDto)
    {
        if (id != addressDto.Id)
        {
            return BadRequest("ID in the request does not match the address ID.");
        }

        var updatedAddress = await _addressService.UpdateAddressAsync(id, addressDto);
        if (updatedAddress == null) return NotFound("Address not found.");

        return Ok(updatedAddress);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        var result = await _addressService.DeleteAddressAsync(id);
        if (!result) return NotFound("Address not found or already deleted.");

        return Ok(new { message = "Address deleted successfully." });
    }



}

