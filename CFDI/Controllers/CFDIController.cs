using CFDI.DTO;
using CFDI.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CFDIController : ControllerBase
    {
        private CFDIManager _cfdiMgr = new CFDIManager();
        // GET api/cfdi Consultar todo
        [HttpGet]
        public ActionResult<CFDICodeDataDTO> Get()
        {
            CFDICodeDataDTO cfdi = _cfdiMgr.Get();

            return cfdi;
        }


        // GET api/cfdi Consultar por id
        [HttpGet("{ide_id}")]
        public ActionResult<CFDICodeDataDTO> GetById(string ide_id)
        {
            CFDICodeDataDTO cfdi = _cfdiMgr.GetById(ide_id);
            return cfdi;
        }
    }
}
