using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class DesignationRepository
    {
        private readonly HRMSDbContext _hRMSDbContext = null;

        public DesignationRepository(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public async Task<int> AddDesignation(VmDesignation model)
        {
            var dsg = new Designation()
            {
                DesignationName = model.DesignationName,

            };

            await _hRMSDbContext.Designations.AddAsync(dsg);
            await _hRMSDbContext.SaveChangesAsync();
            return dsg.DesignationId;

        }
        public async Task<List<VmDesignation>> GetAllDesignation()
        {
            return await _hRMSDbContext.
                Designations
                  .Select(desig => new VmDesignation()
                  {
                      DesignationId = desig.DesignationId,
                      DesignationName = desig.DesignationName,
                  }).ToListAsync();
        }
        public async Task<VmDesignation> GetAllDesignationId(int id)
        {
            return await _hRMSDbContext.Designations.Where(x => x.DesignationId == id)
              .Select(desig => new VmDesignation()
              {
                  DesignationId = desig.DesignationId,
                  DesignationName = desig.DesignationName,
              }).FirstOrDefaultAsync();
        }
        public async Task<int> EditDesignation(VmDesignation model)
        {
            var result = await _hRMSDbContext.Designations
               .FirstOrDefaultAsync(d => d.DesignationId == model.DesignationId);

            if (result != null)
            {
                result.DesignationId = model.DesignationId;
                result.DesignationName = model.DesignationName;
                await _hRMSDbContext.SaveChangesAsync();
                return result.DesignationId;
            }
            return result.DesignationId;
        }

        public async Task<VmDesignation> DeleteDesignation(int designationId)
        {
            var result = await _hRMSDbContext.Designations
                .FirstOrDefaultAsync(e => e.DesignationId == designationId);

            if (result != null)
            {
                _hRMSDbContext.Designations.Remove(result);
                await _hRMSDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<VmDesignation> Details(int id)
        {
            return await _hRMSDbContext.Designations.Where(x => x.DesignationId == id)
              .Select(dsg => new VmDesignation()
              {
                  DesignationId = dsg.DesignationId,
                  DesignationName = dsg.DesignationName,
              }).FirstOrDefaultAsync();
        }
    }
}
