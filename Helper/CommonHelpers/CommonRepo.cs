using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonHelpers
{
    public class CommonRepo
    {
        private readonly DBContext _dbContext;

        public CommonRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<UserMst> UserMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.UserMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<DepartmentMst> DepartmentMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.DepartmentMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<DesignationMst>DesignationMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.DesignationMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<EmployeeTypeMst> EmployeeTypeMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.EmployeeTypeMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<RoleMst> RoleMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.RoleMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<ReportingManagerMst> ReportingManagerMstsList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.ReportingManagerMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<AttritionTypeMst> AttritionTypeMstsList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.AttritionTypeMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<HolidaysMst> HolidayMstsList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.HolidaysMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<LeaveMst> LeaveMstsList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.LeaveMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<ResignMst> ResignMstsList()
        {
            return _dbContext.ResignMsts.AsQueryable();
        }
        public IQueryable<TokenMst> TokenMstList()
        {
            return _dbContext.TokenMsts.AsQueryable();
        }
    }
}
