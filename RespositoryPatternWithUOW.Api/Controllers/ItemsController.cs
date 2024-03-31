using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using RepositoryPatternWithUOW.Core.Dtos;
using AutoMapper;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            try
            {
                var items = await _unitOfWork.Items.GetAllAsync();

                if (items == null)
                {
                    return NotFound("No items found.");
                }

                return Ok(items);
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var item = _mapper.Map<Item>(itemDto);

                if (item == null)
                    return BadRequest();

                var createdItem = await _unitOfWork.Items.AddAsync(item);

                return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new item record");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(int id)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            var itemDto = _mapper.Map<ItemDto>(item);
            return itemDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] ItemDto itemDto)
        {
            if (id != itemDto.Id)
            {
                return BadRequest("Item ID mismatch");
            }

            var itemToUpdate = await _unitOfWork.Items.GetByIdAsync(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Item with Id = {id} not found");
            }

            try
            {
                var item = _mapper.Map<Item>(itemDto);
                _unitOfWork.Items.Update(item);
                _unitOfWork.Complete();

                return NoContent(); // HTTP 204
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating item");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var itemToDelete = await _unitOfWork.Items.GetByIdAsync(id);
            if (itemToDelete == null)
            {
                return NotFound($"Item with Id = {id} not found");
            }

            try
            {
                _unitOfWork.Items.Delete(itemToDelete);
                _unitOfWork.Complete();

                return NoContent(); // HTTP 204
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting item");
            }
        }





    }
}
