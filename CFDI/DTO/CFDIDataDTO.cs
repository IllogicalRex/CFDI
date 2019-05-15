using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFDI.DTO
{
    [BsonIgnoreExtraElements]
    public class CFDIDataDTO
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string ide_id { get; set; }

        [BsonElement("cve_fol_interno")]
        public string cve_fol_interno { get; set; }

        [BsonElement("cve_fol_sat")]
        public string cve_fol_sat { get; set; }

        [BsonElement("tpo_documento")]
        public string tpo_documento { get; set; }

        [BsonElement("bnd_estatus")]
        public string bnd_estatus { get; set; }

        [BsonElement("txt_rfc_emisor")]
        public string txt_rfc_emisor { get; set; }

        [BsonElement("txt_rfc_receptor")]
        public string txt_rfc_receptor { get; set; }

        [BsonElement("fec_cancelar")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime fec_cancelar { get; set; }

        [BsonElement("fec_emisión")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime fec_emision { get; set; }

        [BsonElement("mto_subtotal")]
        public double mto_subtotal { get; set; }

        [BsonElement("imp_iva")]
        public double imp_iva { get; set; }

        [BsonElement("mto_total")]
        public double mto_total { get; set; }

        

    }

    public class CFDICodeDataDTO 
    {
        public string code { get; set; }
        public string message { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        public string moreInfo { get; set; }
        public List<CFDIDataDTO> response { get; set; }
        public bool ok { get; set; }
        public string validations { get; set; }

        public CFDICodeDataDTO(string code, string message, string level, string description, string moreInfo, List<CFDIDataDTO> response, bool ok, string validations)
        {
            this.code = code;
            this.message = message;
            this.level = level;
            this.description = description;
            this.moreInfo = moreInfo;
            this.response = response;
            this.ok = ok;
            this.validations = validations;
        }
        public CFDICodeDataDTO()
        {

        }

    }
}
