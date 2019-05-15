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
            
            CFDICodeDataDTO respCode = Validar(data);
            return respCode; 
        }
        
        // GET Consultar por ID
        public CFDICodeDataDTO GetById(string ide_id)
        {
            List<CFDIDataDTO> data = _cfdiData.Find(response => response.ide_id.Equals(ide_id)).ToList();

            CFDICodeDataDTO respCode = Validar(data);
            return respCode;
        }

        // POST Agregar
        public string post(CFDIDataDTO data)
        {
            this.data = data;
            string mensaje = "";
            if (!isNull())
            {
                _cfdiData.InsertOneAsync(data);
                mensaje = "Operación realizada correctamente";
            }
            else
                mensaje = "No puede mandar datos vacios";

            return mensaje;
        }

        // PUT Actualizar 
        public string put(string ide_id, CFDIDataDTO data)
        {
            try
            {
                _cfdiData.ReplaceOneAsync(res => res.ide_id.Equals(ide_id) , data);
            }
            catch (Exception e)
            {
                throw e;
            }
            return "Se actualizo";
        }

        // DELETE Eiminar
        //public string delete(string ide_id)
        //{
        //    _cfdi.DeleteOneAsync(res => res.ide_id.Equals(ide_id));
        //    return "Se elimino";
        //}
        public CFDICodeDataDTO Validar(List<CFDIDataDTO> data)
        {
            string code;
            string message;
            string level;
            string description = "";
            string moreInfo;
            bool ok = false;
            string validations;
            if (data != null)
            {
                code = "";
                message = "Opercion realizada correctamente";
                level = "SUCCESS";
                description = "Realización de todas las consultas CFDI";
                moreInfo = "http://mesa.ayuda.com/7";
                ok = true;
                validations = "[]";
            }
            else
            {
                code = "";
                message = "Opercion no se pudo realizar";
                level = "FAILURE";
                moreInfo = "http://mesa.ayuda.com/7";
                ok = false;
                validations = "[]";
            }
            return responseCode(code, message, level, description, moreInfo, data, ok, validations);
        }
        public bool isNull()
        {
            bool isNull = false;
            if (data.ide_id == null ||
                data.cve_fol_interno==null||
                data.cve_fol_sat == null||
                data.tpo_documento == null||
                data.bnd_estatus == null||
                data.txt_rfc_emisor == null||
                data.txt_rfc_receptor == null||
                data.fec_cancelar == null||
                data.fec_emision == null||
                data.mto_subtotal == null||
                data.imp_iva == null||
                data.mto_total == null)
            {
                isNull= true;
            }
            return isNull;
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

