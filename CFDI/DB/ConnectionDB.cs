using CFDI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.DB
{
    public class ConnectionDB
    {
        private IMongoCollection<CFDICodeDataDTO> _cfdi;
        private IMongoCollection<CFDIDataDTO> _cfdiData;
        private CFDIDataDTO data;
        public ConnectionDB() 
        {
            // Lee la instancia del servidor para realizar operaciones de base de datos.
            
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("CFDI");
                _cfdi = database.GetCollection<CFDICodeDataDTO>("rpt_facturas");
                _cfdiData = database.GetCollection<CFDIDataDTO>("rpt_facturas");

        }

        // GET Consultar Todo
        public CFDICodeDataDTO Get() 
        {
           
            List <CFDIDataDTO> data = _cfdiData.Find(response => true).ToList();
            
            CFDICodeDataDTO respCode = Validar(data,1);
            return respCode; 
        }
        
        // GET Consultar por ID
        public CFDICodeDataDTO GetById(string ide_id)
        {
            List<CFDIDataDTO> data = _cfdiData.Find(response => response.ide_id.Equals(ide_id)).ToList();

            CFDICodeDataDTO respCode = Validar(data,2);
            return respCode;
        }

       //si type es 1 es get, si es 2 es get por filtro
        public CFDICodeDataDTO Validar(List<CFDIDataDTO> data, int type)
        {
            string code;
            string message;
            string level;
            string description = "Realización de consultas CFDI";
            string moreInfo = "http://mesa.ayuda.com/7";
            bool ok = false;
            string validations;
            if (data.Count>0)
            {

                code = "";
                message = "Operación realizada correctamente ";
                level = "SUCCESS";
                ok = true;
                validations = "[]";
            }
            else if (data.Count==0)
            {

                code = "";
                message = "No se encotraron resultados";
                level = "SUCCESS";
                ok = true;
                validations = "[]";
            }
            else
            {
                code = "";
                message = "Opercion no se pudo realizar";
                level = "FAILURE";
                ok = false;
                validations = "[]";
            }

            
            return responseCode(code, message, level, description, moreInfo, data, ok, validations);
        }
        

        public CFDICodeDataDTO responseCode(string code, string message, string level, string description, string moreInfo, List<CFDIDataDTO> response, bool ok, string validations)
        {
            //CFDICodeDataDTO Data = new CFDICodeDataDTO(code, message, level, description, moreInfo, response, ok, validations);
            CFDICodeDataDTO Data = new CFDICodeDataDTO();
            Data.code = code;
            Data.message = message;
            Data.level = level;
            Data.description = description;
            Data.moreInfo = moreInfo;
            Data.response =response;
            Data.ok = ok;
            Data.validations = validations;
            return Data;
        }

    }
}

