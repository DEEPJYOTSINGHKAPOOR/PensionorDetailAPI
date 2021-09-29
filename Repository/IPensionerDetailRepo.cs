using PensionorDetailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionorDetailAPI.Repository
{
    public interface IPensionerDetailRepo
    {
        IEnumerable<PensionerDetail> GetPensionerDetail();
        PensionerDetail GetPensionerByAadhar(string Aadhar);

        Task<PensionTransaction> PostTransaction(PensionTransaction transaction);

        Task<bool> SaveDetails(PensionerDetail detail);

        Task<bool> UpdateDetails(string adhar, PensionerDetail pensionerDetail);


        Task<bool> DeleteDetails(string adhar);

        bool Save();


    }
}
