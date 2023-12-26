﻿using BusinessLayer;
using DTO.ReqDTO;
using DTO.ResDTO;
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

        public async Task<CommonResponse> GetUser() => await _userBLL.GetUser();
        public async Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO) => await _userBLL.AddUserPersonalInformation(addUserPersonalInformationReqDTO);
        public async Task<CommonResponse> AddUserJobInformation(AddUserJobInformationReqDTO addUserJobInformationReqDTO) => await _userBLL.AddUserJobInformation(addUserJobInformationReqDTO);
        public async Task<CommonResponse> AddUserBankAndSalaryInformation(AddUserBankAndSalaryInformationReqDTO addUserBankAndSalaryInformationReqDTO) => await _userBLL.AddUserBankAndSalaryInformation(addUserBankAndSalaryInformationReqDTO);
        public async Task<CommonResponse> UpdateUserPersonalInformation(UpdateUserPersonalInformationReqDTO updateUserPersonalInformationReqDTO) => await _userBLL.UpdateUserPersonalInformation(updateUserPersonalInformationReqDTO);
        public async Task<CommonResponse> UpdateUserJobInformation(UpdateUserJobInformationReqDTO updateUserJobInformationReqDTO) => await _userBLL.UpdateUserJobInformation(updateUserJobInformationReqDTO);
        public async Task<CommonResponse> UpdateUserBankAndSalaryInformation(UpdateUserBankAndSalaryInformationReqDTO updateUserBankAndSalaryInformationReqDTO)
             => await _userBLL.UpdateUserBankAndSalaryInformation(updateUserBankAndSalaryInformationReqDTO);
        public async Task<CommonResponse> DeleteUser(DeleteUserReqDTO deleteUserReqDTO) => await _userBLL.DeleteUser(deleteUserReqDTO);
        public async Task<CommonResponse> AddResign(ResignReqDTO resignReqDTO) => await _userBLL.AddResign(resignReqDTO);

    }
    public interface IUser
    {
        public Task<CommonResponse> GetUser();
        public Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO);
        public Task<CommonResponse> AddUserJobInformation(AddUserJobInformationReqDTO addUserJobInformationReqDTO);
        public Task<CommonResponse> AddUserBankAndSalaryInformation(AddUserBankAndSalaryInformationReqDTO addUserBankAndSalaryInformationReqDTO);
        public Task<CommonResponse> UpdateUserPersonalInformation(UpdateUserPersonalInformationReqDTO updateUserPersonalInformationReqDTO);
        public Task<CommonResponse> UpdateUserJobInformation(UpdateUserJobInformationReqDTO updateUserJobInformationReqDTO);
        public Task<CommonResponse> UpdateUserBankAndSalaryInformation(UpdateUserBankAndSalaryInformationReqDTO updateUserBankAndSalaryInformationReqDTO);
        public Task<CommonResponse> DeleteUser(DeleteUserReqDTO deleteUserReqDTO);
        public Task<CommonResponse> AddResign(ResignReqDTO addResignReqDTO);


    }
}
