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



        //Post api/cfdi Agregar 
        [HttpPost]
        public ActionResult<string> post([FromBody] CFDIDataDTO data)
        {



            return _cfdiMgr.post(data);
        }

        //PUT api/cfdi Actualizar
        [HttpPut("{ide_id}")]
        public ActionResult<string> put(string ide_id, [FromBody] CFDIDataDTO data)
        {
            return _cfdiMgr.put(ide_id,data);
        }

        //DELETE api/cfdi Elimiar
        //[HttpDelete("{ide_id}")]
        //public ActionResult<string> delete(string ide_id)
        //{
        //    return _cfdiMgr.delete(ide_id);
        //}


    }
}
