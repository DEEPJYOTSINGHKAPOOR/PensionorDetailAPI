using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PensionorDetailAPI.Models;
using PensionorDetailAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PensionorDetailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        private readonly IPensionerDetailRepo detail;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PensionerDetailController));

        public PensionerDetailController(IPensionerDetailRepo _detail)
        {
            detail = _detail;
        }
        // GET: api/<PensionerDetailController>
        [HttpGet]
        public IEnumerable<PensionerDetail> GetPensionerDetail()
        {
            log.Info("Get Pensioner Detail method is invoked");
            return detail.GetPensionerDetail();
        }

        // GET api/<PensionerDetailController>/5
        [HttpGet("{Aadhar}")]
        public IActionResult GetPensionerByAadhar(string Aadhar)
        {

            log.Info("Get by Aadhar is called!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pensioner = detail.GetPensionerByAadhar(Aadhar);
            log.Info("Data of the id returned!");

            if (pensioner == null)
            {
                return NotFound();
            }

            return Ok(pensioner);
        }
        [HttpPost("PostTransaction")]
       
        public async Task<IActionResult> PostTransaction(PensionTransaction pension)
        {
            log.Info("Post Transaction method is called!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await detail.PostTransaction(pension);

            return Ok(value);
        }



        [HttpPost]
        [Route("~/api/AddPensionerDetails")]
        public async Task<IActionResult> AddPensionerDetails([FromBody]PensionerDetail details)
        {
    

            //log.Info("Post Transaction method is called!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await detail.SaveDetails(details);


            return Ok(value);
        }



        [HttpPut]
        public async Task<IActionResult> UpdatePensionerDetails(string aadhar , [FromBody] PensionerDetail pensionerDetail)
        {
            //var response = GetPensionerByAadhar(aadhar);

            var response = await detail.UpdateDetails(aadhar, pensionerDetail);

            if (response == false) {
                return NotFound(); 
            }

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDetails(string aadhar)
        {
            //var response = GetPensionerByAadhar(aadhar);

            var response = await detail.DeleteDetails(aadhar);

            if (response == false)
            {
                return NotFound();
            }

            return Ok(response);

        }

    }
}
