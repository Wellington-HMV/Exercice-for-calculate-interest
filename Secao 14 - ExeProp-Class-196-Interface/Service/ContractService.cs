using System;
using Entities;

namespace Service
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;
        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }
        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double upBasicQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = upBasicQuota + _onlinePaymentService.PaymentFee(upBasicQuota);
                contract.AddInstallments(new Installment(date, fullQuota));
            }
        }
    }
}
