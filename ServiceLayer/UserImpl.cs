using BusinessLayer;
using DTO.ReqDTO;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserImpl :IUser
    {
        public readonly UserBLL _userBLL;
        public UserImpl(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        public async Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO) => await _userBLL.AddUserPersonalInformation(addUserPersonalInformationReqDTO);
    }
    public interface IUser
    {
        public Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO);
    }
}
