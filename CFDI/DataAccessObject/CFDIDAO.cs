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

        
    }
}
