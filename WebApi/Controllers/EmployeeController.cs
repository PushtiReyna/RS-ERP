using Azure;
using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.CommonModels;
using WebApi.ViewModel.ReqViewModel;
using WebApi.ViewModel.ResViewModel;
using static DTO.ResDTO.GetEmployeeResDTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _iEmployee;
        public EmployeeController(IEmployee iEmployee)
        {
            _iEmployee = iEmployee;
        }

        [HttpPost("GetEmployee")]
        public async Task<CommonResponse> GetEmployee(GetEmployeeReqViewModel getEmployeeReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.GetEmployee(getEmployeeReqViewModel.Adapt<GetEmployeeReqDTO>());
                GetEmployeeResDTO lstGetEmployeeResDTO = response.Data;
                response.Data = lstGetEmployeeResDTO.Adapt<GetEmployeeResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetEmployeeByName")]
        public async Task<CommonResponse> GetEmployeeByName(GetEmployeeByNameReqViewModel getEmployeeByNameReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.GetEmployeeByName(getEmployeeByNameReqViewModel.Adapt<GetEmployeeByNameReqDTO>());
                List<GetEmployeeByNameResDTO> lstGetEmployeeByNameResDTO = response.Data;
                response.Data = lstGetEmployeeByNameResDTO.Adapt<List<GetEmployeeByNameResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetEmployeeByIdPersonalInformation")]
        public async Task<CommonResponse> GetEmployeeByIdPersonalInformation(GetEmployeeByIdPersonalInformationReqViewModel getEmployeeByIdPersonalInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.GetEmployeeByIdPersonalInformation(getEmployeeByIdPersonalInformationReqViewModel.Adapt<GetEmployeeByIdPersonalInformationReqDTO>());
               List<GetEmployeeByIdPersonalInformationResDTO> lstGetEmployeeByIdPersonalInformationResDTO = response.Data;
                response.Data = lstGetEmployeeByIdPersonalInformationResDTO.Adapt<List<GetEmployeeByIdPersonalInformationResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetEmployeeByIdJobInformation")]
        public async Task<CommonResponse> GetEmployeeByIdJobInformation(GetEmployeeByIdJobInformationReqViewModel getEmployeeByIdJobInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.GetEmployeeByIdJobInformation(getEmployeeByIdJobInformationReqViewModel.Adapt<GetEmployeeByIdJobInformationReqDTO>());
                List<GetEmployeeByIdJobInformationResDTO> lstGetEmployeeByIdJobInformationResDTO = response.Data;
                response.Data = lstGetEmployeeByIdJobInformationResDTO.Adapt<List<GetEmployeeByIdJobInformationResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetEmployeeByIdBankAndSalaryInformation")]
        public async Task<CommonResponse> GetEmployeeByIdBankAndSalaryInformation(GetEmployeeByIdJBankAndSalaryInformationReqViewModel getEmployeeByIdJBankAndSalaryInformationReqView)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.GetEmployeeByIdBankAndSalaryInformation(getEmployeeByIdJBankAndSalaryInformationReqView.Adapt<GetEmployeeByIdBankAndSalaryInformationReqDTO>());
                List<GetEmployeeByIdBankAndSalaryInformationResDTO> lstGetEmployeeByIdBankAndSalaryInformationResDTO = response.Data;
                response.Data = lstGetEmployeeByIdBankAndSalaryInformationResDTO.Adapt<List<GetEmployeeByIdBankAndSalaryInformationResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddEmployeePersonalInformation")]
        public async Task<CommonResponse> AddEmployeePersonalInformation([FromForm] AddEmployeePersonalInformationReqViewModel addEmployeePersonalInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.AddEmployeePersonalInformation(addEmployeePersonalInformationReqViewModel.Adapt<AddEmployeePersonalInformationReqDTO>());
                AddEmployeePersonalInformationResDTO addEmployeePersonalInformationResDTO = response.Data;
                response.Data = addEmployeePersonalInformationResDTO.Adapt<AddEmployeePersonalInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddEmployeeJobInformation")]
        public async Task<CommonResponse> AddEmployeeJobInformation(AddEmployeeJobInformationReqViewModel addEmployeeJobInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.AddEmployeeJobInformation(addEmployeeJobInformationReqViewModel.Adapt<AddEmployeeJobInformationReqDTO>());
                AddEmployeeJobInformationResDTO addEmployeeJobInformationResDTO = response.Data;
                response.Data = addEmployeeJobInformationResDTO.Adapt<AddEmployeeJobInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddEmployeeBankAndSalaryInformation")]
        public async Task<CommonResponse> AddEmployeeBankAndSalaryInformation(AddEmployeeBankAndSalaryInformationReqViewModel addEmployeeBankAndSalaryInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.AddEmployeeBankAndSalaryInformation(addEmployeeBankAndSalaryInformationReqViewModel.Adapt<AddEmployeeBankAndSalaryInformationReqDTO>());
                AddEmployeeBankAndSalaryInformationResDTO addEmployeeBankAndSalaryInformationResDTO = response.Data;
                response.Data = addEmployeeBankAndSalaryInformationResDTO.Adapt<AddEmployeeBankAndSalaryInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateEmployeePersonalInformation")]
        public async Task<CommonResponse> UpdateEmployeePersonalInformation([FromForm] UpdateEmployeePersonalInformationReqViewModel updateEmployeePersonalInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.UpdateEmployeePersonalInformation(updateEmployeePersonalInformationReqViewModel.Adapt<UpdateEmployeePersonalInformationReqDTO>());
                UpdateEmployeePersonalInformationResDTO updateEmployeePersonalInformationResDTO = response.Data;
                response.Data = updateEmployeePersonalInformationResDTO.Adapt<UpdateEmployeePersonalInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateEmployeeJobInformation")]
        public async Task<CommonResponse> UpdateEmployeeJobInformation(UpdateEmployeeJobInformationReqViewModel updateEmployeeJobInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.UpdateEmployeeJobInformation(updateEmployeeJobInformationReqViewModel.Adapt<UpdateEmployeeJobInformationReqDTO>());
                UpdateEmployeeJobInformationResDTO updateEmployeeJobInformationResDTO = response.Data;
                response.Data = updateEmployeeJobInformationResDTO.Adapt<UpdateEmployeeJobInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateEmployeeBankAndSalaryInformation")]
        public async Task<CommonResponse> UpdateEmployeeBankAndSalaryInformation(UpdateEmployeeBankAndSalaryInformationReqViewModel updateEmployeeBankAndSalaryInformationReqView)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.UpdateEmployeeBankAndSalaryInformation(updateEmployeeBankAndSalaryInformationReqView.Adapt<UpdateEmployeeBankAndSalaryInformationReqDTO>());
                UpdateEmployeeBankAndSalaryInformationResDTO updateEmployeeBankAndSalaryInformationResDTO = response.Data;
                response.Data = updateEmployeeBankAndSalaryInformationResDTO.Adapt<UpdateEmployeeBankAndSalaryInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<CommonResponse> DeleteEmployee(DeleteEmployeeReqViewModel deleteUserReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.DeleteEmployee(deleteUserReqViewModel.Adapt<DeleteEmployeeReqDTO>());
                DeleteEmployeeResDTO deleteUserResDTO = response.Data;
                response.Data = deleteUserResDTO.Adapt<DeleteEmployeeResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddResign")]
        public async Task<CommonResponse> AddResign(ResignReqViewModel resignReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iEmployee.AddResign(resignReqViewModel.Adapt<ResignReqDTO>());
                ResignResDTO resignResDTO = response.Data;
                response.Data = resignResDTO.Adapt<ResignResViewModel>();
            }
            catch { throw; }
            return response;
        }



    }
}
