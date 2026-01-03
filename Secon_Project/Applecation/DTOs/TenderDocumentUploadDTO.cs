using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class TenderDocumentUploadDTO
    {
        public TenderDocumentUploadDTO()
        {
        }

        public int tenderId { get; set; }
        public IFormFile file { get; set; }

    }
}
