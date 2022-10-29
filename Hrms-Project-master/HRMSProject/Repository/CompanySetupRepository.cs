using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class CompanySetupRepository
    {

        private readonly HRMSDbContext _hRMSDbContext = null;

        public CompanySetupRepository(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public async Task<int> AddCompnaySetup(VmCompnaySetup model)
        {
            var cmptype = new CompanySetup()
            {
                CompanyId=model.CompanyId,
                CompanyName = model.CompanyName,
                Address = model.Address,
                CompanyStartDate = model.CompanyStartDate,
                RegistrationNo = model.RegistrationNo,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Fax = model.Fax,
                CompanyTypeId = model.CompanyTypeId,
            };

            await _hRMSDbContext.CompanySetups.AddAsync(cmptype);
            await _hRMSDbContext.SaveChangesAsync();
            return cmptype.CompanyId;

        }
        public async Task<List<VmCompnaySetup>> GetAllCompanySetup()
        {
            return await _hRMSDbContext.CompanySetups
                  .Select(cmp => new VmCompnaySetup()
                  {
                      CompanyId=cmp.CompanyId,
                      CompanyName = cmp.CompanyName,
                      Address = cmp.Address,
                      CompanyStartDate = cmp.CompanyStartDate,
                      RegistrationNo = cmp.RegistrationNo,
                      PhoneNumber = cmp.PhoneNumber,
                      Email = cmp.Email,
                      Fax = cmp.Fax,
                      
                  }).ToListAsync();
        }
        public async Task<VmCompnaySetup> GetAllCompanySetupID(int id)
        {
            return await _hRMSDbContext.CompanySetups.Where(x => x.CompanyId == id)
              .Select(cmp => new VmCompnaySetup()
              {
                  CompanyId=cmp.CompanyId,
                  CompanyName = cmp.CompanyName,
                  Address = cmp.Address,
                  CompanyStartDate = cmp.CompanyStartDate,
                  RegistrationNo = cmp.RegistrationNo,
                  PhoneNumber = cmp.PhoneNumber,
                  Email = cmp.Email,
                  Fax = cmp.Fax,
                  CompanyTypeId = cmp.CompanyTypeId,
              }).FirstOrDefaultAsync();
        }
        public async Task<int> EditCompanySetup(VmCompnaySetup model)
        {
            var result = await _hRMSDbContext.CompanySetups
               .FirstOrDefaultAsync(e => e.CompanyId == model.CompanyId);

            if (result != null)
            {
                result.CompanyId = model.CompanyId;
                result.CompanyName = model.CompanyName;
                result.Address = model.Address;
                result.CompanyStartDate = model.CompanyStartDate;
                result.RegistrationNo = model.RegistrationNo;
                result.PhoneNumber = model.PhoneNumber;
                result.Email = model.Email;
                result.Fax = model.Fax;
                result.CompanyTypeId = model.CompanyTypeId;
                await _hRMSDbContext.SaveChangesAsync();
                return result.CompanyId;
            }
            return result.CompanyId;
        }

        public async Task<VmCompnaySetup> DeleteCompanySetupID(int Id)
        {
            var result = await _hRMSDbContext.CompanySetups
                .FirstOrDefaultAsync(e => e.CompanyId == Id);

            if (result != null)
            {
                _hRMSDbContext.CompanySetups.Remove(result);
                await _hRMSDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<VmCompnaySetup> Details(int id)
        {
            return await _hRMSDbContext.CompanySetups.Where(x => x.CompanyId == id)
              .Select(cmp => new VmCompnaySetup()
              {
                  CompanyId = cmp.CompanyId,
                  CompanyName = cmp.CompanyName,
                  Address = cmp.Address,
                  CompanyStartDate = cmp.CompanyStartDate,
                  RegistrationNo = cmp.RegistrationNo,
                  PhoneNumber = cmp.PhoneNumber,
                  Email = cmp.Email,
                  Fax = cmp.Fax,
                  CompanyTypeId = cmp.CompanyTypeId,
              }).FirstOrDefaultAsync();
        }
    }
}

