﻿namespace Service
{
    interface
        IOnlinePaymentService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int mounths);

    }
}
