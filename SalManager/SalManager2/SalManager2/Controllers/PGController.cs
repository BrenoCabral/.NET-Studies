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
    public class PGController : ControllerBase
    {
        private readonly IPGService _PGService;
        public PGController(IPGService PGService)
        {
            _PGService = PGService;
        }

        [HttpGet]
        public IEnumerable<PG> Get()
        {
            try
            {
                return _PGService.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("Could not bring every 'PG'");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(PG PG)
        {
            try
            {
                await _PGService.Create(PG);
                return Ok();
            }
            catch(Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        [HttpPost]
        [Route("CreateMultiple")]
        public async Task<ActionResult> CreateMultiple(List<PG> PGs)
        {
            try
            {
                await _PGService.CreateMultiple(PGs);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<PG> GetById(int id)
        {
            PG PG= await _PGService.GetById(id);
            return PG;
        }

        [HttpPut]
        public async Task<ActionResult> Update(PG PG)
        {
            try
            {
                await _PGService.Update(PG);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _PGService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return ReturnBasicErrorMessage(e);
            }
        }
        public ActionResult ReturnBasicErrorMessage(Exception e)
        {
            return BadRequest("There was a problem while creating 'PG: " + e.Message);
        }
    }
}
