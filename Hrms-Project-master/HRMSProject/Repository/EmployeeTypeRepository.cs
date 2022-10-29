using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class EmployeeTypeRepository
    {
        private readonly HRMSDbContext _hRMSDbContext = null;

        public EmployeeTypeRepository(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public async Task<int> AddEmployeeType(VmEmployeeType model)
        {
            var emptype = new EmployeeType()
            {
                EmployeeTypeName = model.EmployeeTypeName,
                OverTimeAllowed = model.OverTimeAllowed
            };

            await _hRMSDbContext.EmployeeTypes.AddAsync(emptype);
            await _hRMSDbContext.SaveChangesAsync();
            return emptype.EmployeeTypeId;

        }
        public async Task<List<VmEmployeeType>> GetAllEmployeeType()
        {
            return await _hRMSDbContext.EmployeeTypes
                  .Select(emp => new VmEmployeeType()
                  {
                      EmployeeTypeId = emp.EmployeeTypeId,
                      EmployeeTypeName = emp.EmployeeTypeName,
                      OverTimeAllowed = emp.OverTimeAllowed
                  }).ToListAsync();
        }
        public async Task<VmEmployeeType> GetAllEmployeeTypeID(int id)
        {
            return await _hRMSDbContext.EmployeeTypes.Where(x => x.EmployeeTypeId == id)
              .Select(emp => new VmEmployeeType()
              {
                  EmployeeTypeId = emp.EmployeeTypeId,
                  EmployeeTypeName = emp.EmployeeTypeName,
                  OverTimeAllowed = emp.OverTimeAllowed
              }).FirstOrDefaultAsync();
        }
        public async Task<int> EditEmployeeType(VmEmployeeType model)
        {
            var result = await _hRMSDbContext.EmployeeTypes
               .FirstOrDefaultAsync(e => e.EmployeeTypeId == model.EmployeeTypeId);

            if (result != null)
            {
                result.EmployeeTypeId = model.EmployeeTypeId;
                result.OverTimeAllowed = model.OverTimeAllowed;
                result.EmployeeTypeName = model.EmployeeTypeName;
                await _hRMSDbContext.SaveChangesAsync();
                return result.EmployeeTypeId;
            }
            return result.EmployeeTypeId;
        }

        public async Task<VmEmployeeType> DeleteEmployee(int employeeId)
        {
            var result = await _hRMSDbContext.EmployeeTypes
                .FirstOrDefaultAsync(e => e.EmployeeTypeId == employeeId);

            if (result != null)
            {
                _hRMSDbContext.EmployeeTypes.Remove(result);
                await _hRMSDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<VmEmployeeType> Details(int id)
        {
            return await _hRMSDbContext.EmployeeTypes.Where(x => x.EmployeeTypeId == id)
              .Select(emp => new VmEmployeeType()
              {
                  EmployeeTypeId = emp.EmployeeTypeId,
                  EmployeeTypeName = emp.EmployeeTypeName,
                  OverTimeAllowed = emp.OverTimeAllowed
              }).FirstOrDefaultAsync();
        }
    }
}