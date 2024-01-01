using DTO.ResDTO;
using Helper.CommonModels;
using Mapster;
using Mapster.Utils;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceList = Helper.CommonModels.AttendanceList;
//using AttendanceList = Helper.CommonModels.AttendanceList;

namespace BusinessLayer
{
    public class AttendanceBLL
    {
        //public readonly AttendanceList _attendanceList;
        //public AttendanceBLL(AttendanceList attendanceList)
        //{ 
        //    _attendanceList = attendanceList;
        #region MyRegion
        #endregion
        //}

        public async Task<CommonResponse> GetAttendanceList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                //List<GetAttendanceListResDTO> getAttendanceListResDTO = new List<GetAttendanceListResDTO>();
                var getAttendanceListResDTO = Enum.GetValues(typeof(AttendanceList)).Cast<AttendanceList>().ToList();/*.Adapt<List<GetAttendanceListResDTO>>();*/
                
                response.Data = getAttendanceListResDTO.Adapt<List<GetAttendanceListResDTO>>();



            }
            catch { throw; }
            return response;
        }

    }

   
}
