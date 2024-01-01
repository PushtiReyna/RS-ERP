using BusinessLayer;
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
    public class EmployeeImpl : IEmployee
    {
        public readonly EmployeeBLL _employeeBLL;
        public EmployeeImpl(EmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }

        public async Task<CommonResponse> GetEmployee(GetEmployeeReqDTO getEmployeeReqDTO) => await _employeeBLL.GetEmployee(getEmployeeReqDTO);
        public async Task<CommonResponse> GetEmployeeByName(GetEmployeeByNameReqDTO getEmployeeByNameReqDTO) => await _employeeBLL.GetEmployeeByName(getEmployeeByNameReqDTO);
        public async Task<CommonResponse> GetEmployeeByIdPersonalInformation(GetEmployeeByIdPersonalInformationReqDTO getEmployeeByIdPersonalInformationReqDTO) => await _employeeBLL.GetEmployeeByIdPersonalInformation(getEmployeeByIdPersonalInformationReqDTO);
        public async Task<CommonResponse> GetEmployeeByIdJobInformation(GetEmployeeByIdJobInformationReqDTO getEmployeeByIdJobInformationReqDTO) => await _employeeBLL.GetEmployeeByIdJobInformation(getEmployeeByIdJobInformationReqDTO);
        public async Task<CommonResponse> GetEmployeeByIdBankAndSalaryInformation(GetEmployeeByIdBankAndSalaryInformationReqDTO getEmployeeByIdBankAndSalaryInformationReqDTO) => await _employeeBLL.GetEmployeeByIdBankAndSalaryInformation(getEmployeeByIdBankAndSalaryInformationReqDTO);
        public async Task<CommonResponse> AddEmployeePersonalInformation(AddEmployeePersonalInformationReqDTO addEmployeePersonalInformationReqDTO) => await _employeeBLL.AddEmployeePersonalInformation(addEmployeePersonalInformationReqDTO);
        public async Task<CommonResponse> AddEmployeeJobInformation(AddEmployeeJobInformationReqDTO addEmployeeJobInformationReqDTO) => await _employeeBLL.AddEmployeeJobInformation(addEmployeeJobInformationReqDTO);
        public async Task<CommonResponse> AddEmployeeBankAndSalaryInformation(AddEmployeeBankAndSalaryInformationReqDTO addEmployeeBankAndSalaryInformationReqDTO) => await _employeeBLL.AddEmployeeBankAndSalaryInformation(addEmployeeBankAndSalaryInformationReqDTO);
        public async Task<CommonResponse> UpdateEmployeePersonalInformation(UpdateEmployeePersonalInformationReqDTO updateEmployeePersonalInformationReqDTO) => await _employeeBLL.UpdateEmployeePersonalInformation(updateEmployeePersonalInformationReqDTO);
        public async Task<CommonResponse> UpdateEmployeeJobInformation(UpdateEmployeeJobInformationReqDTO updateEmployeeJobInformationReqDTO) => await _employeeBLL.UpdateEmployeeJobInformation(updateEmployeeJobInformationReqDTO);
        public async Task<CommonResponse> UpdateEmployeeBankAndSalaryInformation(UpdateEmployeeBankAndSalaryInformationReqDTO updateEmployeeBankAndSalaryInformationReqDTO)
             => await _employeeBLL.UpdateEmployeeBankAndSalaryInformation(updateEmployeeBankAndSalaryInformationReqDTO);
        public async Task<CommonResponse> DeleteEmployee(DeleteEmployeeReqDTO deleteUserReqDTO) => await _employeeBLL.DeleteEmployee(deleteUserReqDTO);
        public async Task<CommonResponse> AddResign(ResignReqDTO resignReqDTO) => await _employeeBLL.AddResign(resignReqDTO);

    }
    public interface IEmployee
    {
        public Task<CommonResponse> GetEmployee(GetEmployeeReqDTO getEmployeeReqDTO);
        public Task<CommonResponse> GetEmployeeByName(GetEmployeeByNameReqDTO getEmployeeByNameReqDTO);
        public Task<CommonResponse> GetEmployeeByIdPersonalInformation(GetEmployeeByIdPersonalInformationReqDTO getEmployeeByIdPersonalInformationReqDTO);
        public Task<CommonResponse> GetEmployeeByIdJobInformation(GetEmployeeByIdJobInformationReqDTO getEmployeeByIdJobInformationReqDTO);
        public Task<CommonResponse> GetEmployeeByIdBankAndSalaryInformation(GetEmployeeByIdBankAndSalaryInformationReqDTO getEmployeeByIdBankAndSalaryInformationReqDTO);
        public Task<CommonResponse> AddEmployeePersonalInformation(AddEmployeePersonalInformationReqDTO addEmployeePersonalInformationReqDTO);
        public Task<CommonResponse> AddEmployeeJobInformation(AddEmployeeJobInformationReqDTO addEmployeeJobInformationReqDTO);
        public Task<CommonResponse> AddEmployeeBankAndSalaryInformation(AddEmployeeBankAndSalaryInformationReqDTO addEmployeeBankAndSalaryInformationReqDTO);
        public Task<CommonResponse> UpdateEmployeePersonalInformation(UpdateEmployeePersonalInformationReqDTO updateEmployeePersonalInformationReqDTO);
        public Task<CommonResponse> UpdateEmployeeJobInformation(UpdateEmployeeJobInformationReqDTO updateEmployeeJobInformationReqDTO);
        public Task<CommonResponse> UpdateEmployeeBankAndSalaryInformation(UpdateEmployeeBankAndSalaryInformationReqDTO updateEmployeeBankAndSalaryInformationReqDTO);
        public Task<CommonResponse> DeleteEmployee(DeleteEmployeeReqDTO deleteEmployeeReqDTO);
        public Task<CommonResponse> AddResign(ResignReqDTO addResignReqDTO);

    }
}
