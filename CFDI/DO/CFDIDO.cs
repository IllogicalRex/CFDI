using CFDI.DataAccessObject;
using CFDI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.DO
{
    public class CFDIDO
    {
        private CFDIDAO _cfdiDAO = new CFDIDAO();
        
        // GET Consultar
        public CFDICodeDataDTO Get()
        {
            return _cfdiDAO.Get();
        }

        // GET Consultar por ID
        public CFDICodeDataDTO GetById(string ide_id)
        {
            return _cfdiDAO.GetById(ide_id);
        }

        
    }
}
