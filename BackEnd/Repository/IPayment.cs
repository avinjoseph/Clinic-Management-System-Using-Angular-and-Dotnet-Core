using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Models
{
    public interface IPayment
    {
        Task<List<PaymentViewModel>> GetPaymentDetails();
        
        Task<int> AddPayment(Payments payment);
        Task UpdatePayment(Payments payment);

        Task<PaymentViewModel> GetPaymentByPatientId(int id);
        Task<Payments> GetPaymentById(int id);
    }
}
