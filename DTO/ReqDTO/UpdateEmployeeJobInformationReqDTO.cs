﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class UpdateEmployeeJobInformationReqDTO
    {
        public int EmployeeId { get; set; }

        public int? EmployeeTypeId { get; set; }

        public string? CompanyName { get; set; }

        public int? DepartmentId { get; set; }

        public int? DesignationId { get; set; }

        public DateTime? JoiningDate { get; set; }
        public DateTime? OfferDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public string? ComapanyAddress { get; set; }

        public int? ProbationPeriod { get; set; }

        public int? NoticePeriod { get; set; }

        public int? RoleId { get; set; }

        public int? ReportingManagerId { get; set; }
    }
}
