using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.PermissionTypes;

namespace Examen_U1_Lenguajes.Dtos.Requests
{
    public class RequestDto
    {
        public Guid Id { get; set; }

        public virtual PermissionTypeDto PermissionType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public Boolean IsApproved { get; set; }
    }
}