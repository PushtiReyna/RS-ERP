using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        public readonly IHostingEnvironment _hostEnvironment;
        public UserBLL(DBContext dbContext, CommonRepo commonRepo, IHostingEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UserMst userMst = new UserMst();
                AddUserPersonalInformationResDTO addUserPersonalInformationResDTO = new AddUserPersonalInformationResDTO();

                var userDetail =  await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == addUserPersonalInformationReqDTO.EmployeeId && x.Email == addUserPersonalInformationReqDTO.Email);
                if(userDetail == null)
                {
                    userMst.EmployeeId = addUserPersonalInformationReqDTO.EmployeeId;
                    string imgName = uploadUserImage(addUserPersonalInformationReqDTO.Image);
                    userMst.Image = imgName;
                    userMst.FirstName = addUserPersonalInformationReqDTO.FirstName;
                    userMst.MiddleName = addUserPersonalInformationReqDTO.MiddleName;
                    userMst.LastName = addUserPersonalInformationReqDTO.LastName;
                    userMst.Email = addUserPersonalInformationReqDTO.Email;
                    userMst.Gender = addUserPersonalInformationReqDTO.Gender;
                    userMst.DateOfBirth = addUserPersonalInformationReqDTO.DateOfBirth;
                    userMst.EmergencyContactName = addUserPersonalInformationReqDTO.EmergencyContactName;
                    userMst.EmergencyContactNo = addUserPersonalInformationReqDTO.EmergencyContactNo;
                    userMst.Password = addUserPersonalInformationReqDTO.Password;
                    userMst.MartialStatus = addUserPersonalInformationReqDTO.MartialStatus;
                    userMst.PermanentAddress = addUserPersonalInformationReqDTO.PermanentAddress;
                    userMst.PermanentAddressPostalCode = addUserPersonalInformationReqDTO.PermanentAddressPostalCode;
                    userMst.CurrentAddress = addUserPersonalInformationReqDTO.CurrentAddress;
                    userMst.CurrentAddressPostalCode = addUserPersonalInformationReqDTO.CurrentAddressPostalCode;
                    userMst.CreatedBy = 1;
                    userMst.IsActive = true;
                    userMst.CreatedDate = DateTime.Now;

                    _dbContext.UserMsts.Add(userMst);
                    _dbContext.SaveChanges();

                    addUserPersonalInformationResDTO.EmployeeId = userMst.EmployeeId;
                    response.Data = addUserPersonalInformationResDTO;
                    response.Message = "user personal information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "user already exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public string uploadUserImage(dynamic imgPath)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            string fileName = imgPath.FileName;
            string filePath = Path.Combine(path, fileName);
            string relativePath = Path.Combine("Images", fileName);

            if (fileName != null)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imgPath.CopyTo(fileStream);
                }
            }
            return relativePath;
        }

    }
}
