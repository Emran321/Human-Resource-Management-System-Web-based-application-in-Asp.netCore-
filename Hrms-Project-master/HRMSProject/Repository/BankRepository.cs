using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class BankRepository
    {
        private readonly HRMSDbContext _hRMSDbContext = null;

        public BankRepository(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public async Task<int> AddBank
            (VmBank model)
        {
            var bank = new Bank()
            {
                BankName = model.BankName

            };

            await _hRMSDbContext.Banks.AddAsync(bank);
            await _hRMSDbContext.SaveChangesAsync();
            return bank.BankId;

        }
        public async Task<List<VmBank>> GetAllBank()
        {
            return await _hRMSDbContext.Banks
                  .Select(bank => new VmBank()
                  {
                      BankId = bank.BankId,
                      BankName = bank.BankName

                  }).ToListAsync();
        }
        public async Task<VmBank> GetAllBankID(int id)
        {
            return await _hRMSDbContext.Banks.Where(x => x.BankId == id)
              .Select(bank => new VmBank()
              {
                  BankId = bank.BankId,
                  BankName = bank.BankName,

              }).FirstOrDefaultAsync();
        }
        public async Task<int> EditBank(VmBank model)
        {
            var result = await _hRMSDbContext.Banks
               .FirstOrDefaultAsync(e => e.BankId == model.BankId);

            if (result != null)
            {
                result.BankId = model.BankId;
                result.BankName = model.BankName;
                await _hRMSDbContext.SaveChangesAsync();
                return result.BankId;
            }
            return result.BankId;
        }

        public async Task<VmBank> DeleteBank(int bankId)
        {
            var result = await _hRMSDbContext.Banks
                .FirstOrDefaultAsync(e => e.BankId == bankId);

            if (result != null)
            {
                _hRMSDbContext.Banks.Remove(result);
                await _hRMSDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<VmBank> Details(int id)
        {
            return await _hRMSDbContext.Banks.Where(x => x.BankId == id)
              .Select(bank => new VmBank()
              {
                  BankId = bank.BankId,
                  BankName = bank.BankName,
              }).FirstOrDefaultAsync();
        }
    }
}
