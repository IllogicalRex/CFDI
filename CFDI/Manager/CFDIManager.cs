using CFDI.DO;
using CFDI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.Manager
{
    public class CFDIManager
    {
        private CFDIDO _cfdiDO = new CFDIDO();
        
        // GET Consultar
        public CFDICodeDataDTO Get()
        {
            return _cfdiDO.Get();
        }

        // GET Consultar por ID
        public CFDICodeDataDTO GetById(string ide_id)
        {
            return _cfdiDO.GetById(ide_id);
        }


        // POST Agregar
        public string post(CFDIDataDTO data)
        {
            return _cfdiDO.post(data);
        }

        // PUT Actualizar
        public string put(string ide_id, CFDIDataDTO data)
        {
            return _cfdiDO.put(ide_id, data);
        }

        // DELETE Elimiar
        //public string delete(string ide_id)
        //{
        //    return _cfdiDO.delete(ide_id);
        //}
    }
}
