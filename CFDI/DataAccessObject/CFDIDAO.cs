using CFDI.DB;
using CFDI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.DataAccessObject
{
    public class CFDIDAO
    {
        private ConnectionDB _cfdiDB = new ConnectionDB();

        // GET Consultar Todo
        public CFDICodeDataDTO Get()
        {
            return _cfdiDB.Get();
        }

        // GET Consultar por ID
        public CFDICodeDataDTO GetById(string ide_id)
        {
            return _cfdiDB.GetById(ide_id);
        }

        // POST Agregar
        public string post(CFDIDataDTO data)
        {
            return _cfdiDB.post(data);
        }

        // PUT Actualizar
        public string put(string ide_id, CFDIDataDTO data)
        {
            return _cfdiDB.put(ide_id, data);
        }

        // DELETE Eliminar
        //public string delete(string ide_id)
        //{
        //    return _cfdiDB.delete(ide_id);
        //}
    }
}
