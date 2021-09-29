using Microsoft.EntityFrameworkCore;
using PensionorDetailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PensionorDetailAPI.Repository
{
    public class PensionerDetailRepo : IPensionerDetailRepo
    {
        private readonly PensionManagementDBContext context;
        public PensionerDetailRepo()
        {

        }
        public PensionerDetailRepo(PensionManagementDBContext _context)
        {
            context = _context;
        }

        public async Task<bool> DeleteDetails(string adhar)
        {

            PensionerDetail value = context.PensionerDetails.Find(adhar);
            context.Entry(value).State = EntityState.Deleted;

            return Save();
            //throw new NotImplementedException();
        }

        public PensionerDetail Getaadhar(string Aadhar)
        {
            PensionerDetail value = context.PensionerDetails.Where(x => x.AadhaarNo == Aadhar).Select(x => x).SingleOrDefault();
            return value;
            //throw new NotImplementedException();
        }
        public PensionerDetail GetPensionerByAadhar(string Aadhar)
        {
            PensionerDetail value = context.PensionerDetails.Find(Aadhar);
            return value;
            //throw new NotImplementedException();
        }

        public IEnumerable<PensionerDetail> GetPensionerDetail()
        {
            return context.PensionerDetails.ToList();
            //throw new NotImplementedException();
        }

        public async Task<PensionTransaction> PostTransaction(PensionTransaction pension)
        {
            PensionTransaction pensionTransaction = null;
            if (pension == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                pensionTransaction = new PensionTransaction()
                {
                    TransactionNum = pension.TransactionNum,
                    Name = pension.Name,
                    Pan = pension.Pan,
                    AadhaarNo = pension.AadhaarNo,
                    PensionAmount = pension.PensionAmount,
                    BankType = pension.BankType,
                    BankName = pension.BankName,
                    BankAccountNo = pension.BankAccountNo,
                    PensionType = pension.PensionType,
                    TransactionDate = pension.TransactionDate,
                };
                await context.PensionTransactions.AddAsync(pensionTransaction);
                await context.SaveChangesAsync();
            }
            return pensionTransaction;
           
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0 ? true : false;
        }

        public async Task<bool> SaveDetails(PensionerDetail detail)
        {
            //context.
            context.PensionerDetails.Add(detail);

            //cont
            return Save();
        }
  
        public async Task<bool> UpdateDetails(string adhar, PensionerDetail newDetails)
        {
            var details = context.PensionerDetails.Single(x=>x.AadhaarNo == adhar);

            details.BankName = newDetails.BankName;
            //details.AadhaarNo = newDetails.AadhaarNo;
            details.Allowance = newDetails.Allowance;
            details.BankAccountNo = newDetails.BankAccountNo;
            details.BankType = newDetails.BankType;
            details.Dob = newDetails.Dob;
            details.Pan = newDetails.Pan;
            details.Name = newDetails.Name;
            details.Password = newDetails.Password;
            details.PensionTransactions = newDetails.PensionTransactions;
            details.PensionType = newDetails.PensionType;
            details.Salary = newDetails.Salary;


            context.Entry(details).State = EntityState.Modified;

            //details.Equals(newDetails);

            return Save(); 
        }
    }
}
