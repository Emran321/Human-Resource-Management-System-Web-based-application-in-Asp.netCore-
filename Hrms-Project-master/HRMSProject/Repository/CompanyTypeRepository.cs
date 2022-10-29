using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class CompanyTypeRepository
    {
        private readonly HRMSDbContext _hRMSDbContext = null;

        public CompanyTypeRepository(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public async Task<int> AddCompanyType(VmCompanyType model)
        {
            var cmptype = new CompanyType()
            {
                CompanyTypeName = model.CompanyTypeName
            };

            await _hRMSDbContext.CompanyTypes.AddAsync(cmptype);
            await _hRMSDbContext.SaveChangesAsync();
            return cmptype.CompanyTypeId;

        }
        public async Task<List<VmCompanyType>> GetAllCompanyType()
        {
            return await _hRMSDbContext.CompanyTypes
                  .Select(cmp => new VmCompanyType()
                  {
                      CompanyTypeId = cmp.CompanyTypeId,
                      CompanyTypeName = cmp.CompanyTypeName
                  }).ToListAsync();
        }
        public async Task<VmCompanyType> GetAllCompanyTypeID(int id)
        {
            return await _hRMSDbContext.CompanyTypes.Where(x => x.CompanyTypeId == id)
              .Select(cmp => new VmCompanyType()
              {
                  CompanyTypeId = cmp.CompanyTypeId,
                  CompanyTypeName = cmp.CompanyTypeName
              }).FirstOrDefaultAsync();
        }
        public async Task<int> EditCompanyType(VmCompanyType model)
        {
            var result = await _hRMSDbContext.CompanyTypes
               .FirstOrDefaultAsync(e => e.CompanyTypeId == model.CompanyTypeId);

            if (result != null)
            {
                result.CompanyTypeId = model.CompanyTypeId;
                result.CompanyTypeName = model.CompanyTypeName;
                await _hRMSDbContext.SaveChangesAsync();
                return result.CompanyTypeId;
            }
            return result.CompanyTypeId;
        }

        public async Task<VmCompanyType> DeleteCompany(int Id)
        {
            var result = await _hRMSDbContext.CompanyTypes
                .FirstOrDefaultAsync(e => e.CompanyTypeId == Id);

            if (result != null)
            {
                _hRMSDbContext.CompanyTypes.Remove(result);
                await _hRMSDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<VmCompanyType> Details(int id)
        {
            return await _hRMSDbContext.CompanyTypes.Where(x => x.CompanyTypeId == id)
              .Select(cmp => new VmCompanyType()
              {
                  CompanyTypeId = cmp.CompanyTypeId,
                  CompanyTypeName = cmp.CompanyTypeName
              }).FirstOrDefaultAsync();
        }

        public async Task<List<VmCompanyType>> GetcompanyTypeDropDown()
        {
            return await _hRMSDbContext.CompanyTypes.Select(x => new VmCompanyType()
            {
               CompanyTypeId=x.CompanyTypeId,
               CompanyTypeName=x.CompanyTypeName
            }).ToListAsync();
        }
    }
}
