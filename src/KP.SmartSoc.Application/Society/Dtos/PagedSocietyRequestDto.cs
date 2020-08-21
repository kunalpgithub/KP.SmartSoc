using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KP.SmartSoc.Society.Dtos
{
    public class PagedSocietyResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
