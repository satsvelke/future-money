using System;
using Api.Logic.Interface;
using Api.Logic.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Api.Logic.Model
{
    public class ColumnContext
    {
        [JsonIgnore]
        public string CreatedBy { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;

        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
