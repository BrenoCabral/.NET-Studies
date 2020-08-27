using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalManager2.Domain.Models;
using SalManager2.Domain.Services.Interfaces;

namespace SalManager2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembroController : ControllerBase
    {
        private readonly IMembroService _membroService;
        public MembroController(IMembroService membroService)
        {
            _membroService = membroService;
        }

        [HttpGet]
        public IEnumerable<Membro> Get()
        {
            try
            {
                var membros = _membroService.GetAll();
                return membros;
            }
            catch (Exception e)
            {
                throw new Exception("Could not bring every 'Membro'");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Membro membro)
        {
            try
            {
                await _membroService.Create(membro);
                return Ok();
            }
            catch(Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        [HttpPost,Route("{idMembro}/addPg/{idPg}")]
        public async Task<ActionResult> AddToPg(int idMembro, int idPg)
        {
            try
            {
                var membro = await _membroService.GetById(idMembro);
                membro.PGId = idPg;
                await _membroService.Update(membro);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        [HttpPost]
        [Route("CreateMultiple")]
        public async Task<ActionResult> CreateMultiple(List<Membro> membros)
        {
            try
            {
                await _membroService.CreateMultiple(membros);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Membro> GetById(int id)
        {
            Membro membro= await _membroService.GetById(id);
            return membro;
        }

        [HttpPut]
        public async Task<ActionResult> Update(Membro membro)
        {
            try
            {
                await _membroService.Update(membro);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _membroService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        public ActionResult ReturnBasicErrorMessage(Exception e)
        {
            return BadRequest("There was a problem while creating 'Membro: " + e.Message);
        }
    }
}
