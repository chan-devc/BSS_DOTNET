using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSAPI.model;
using Microsoft.AspNetCore.Mvc;

namespace BSSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BSS : ControllerBase
    {
        [HttpPost]
        public IActionResult GetValue([FromBody] RequestData requestData)
        {
            string sr = requestData.serial;
            string key = requestData.hashkey;

            if (key == "ATF@2023ATF")
            {
                try
                {
                    OracleContext oracleContext = new OracleContext();
                    List<ESIM> data = oracleContext.GetData(sr);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound("No data found for the specified serial number");
                    }
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound("Hash Key not matching");
            }

        }
    }
}