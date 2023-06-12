using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.BaseServices;
using System.Net;
using Core.Entities;

namespace API.Controllers
{
    public class BaseEntityController<TDto, TEntity, TCreateRequest, TUpdateRequest> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseService _baseService;

        public BaseEntityController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<List<object>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _baseService.GetAll<TDto, TEntity>();
                if (result == null)
                {
                    return NotFound(Result<List<TDto>>.Failure());
                }
                return Ok(Result<List<TDto>>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<List<TDto>>.Exception(ex));
            }
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<object>), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _baseService.GetById<TDto, TEntity>(id);
                if (result == null)
                {
                    return NotFound(Result<TDto>.Failure());
                }
                return Ok(Result<TDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<TDto>.Exception(ex));
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        public async Task<IActionResult> Create(TCreateRequest entityRequest)
        {
            try
            {
                var result = await _baseService.Create<TCreateRequest, TEntity>(entityRequest);
                return Ok(Result<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<TDto>.Exception(ex));
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        public async Task<IActionResult> Update(TUpdateRequest entityRequest)
        {
            try
            {
                var result = await _baseService.Update<TUpdateRequest, TEntity>(entityRequest);
                return Ok(Result<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<bool>.Exception(ex));
            }
        }
    }
}
