using Service;

namespace Service
{
    class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MountlyInterest = 0.01;
        public double Interest(double amount, int mounth)
        {
            return amount * MountlyInterest * mounth;
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }

    }
}
