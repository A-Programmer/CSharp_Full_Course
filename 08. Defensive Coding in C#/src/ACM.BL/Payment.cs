using System.ComponentModel;

namespace ACM.BL;

public class Payment
{
    public PaymentType PaymentType { get; set; }
    public void ProcessPayment()
    {
        // Not use IsDefined because it is using refelection and it cost much
        // if (!Enum.IsDefined(typeof(PaymentType), PaymentType))
        // {
        //     throw new InvalidEnumArgumentException(
        //                             "Payment type",
        //                             (int)this.PaymentType, typeof(PaymentType));
        // }
        PaymentType paymenTypeOption;
        if(!Enum.TryParse(this.PaymentType.ToString(), out paymenTypeOption))
        {
            throw new InvalidEnumArgumentException(
                            "Payment type",
                            (int)this.PaymentType, typeof(PaymentType));
        }
        switch (paymenTypeOption)
        {
            case PaymentType.CreditCard:
                // Process credit card
                break;

            case PaymentType .PayPal:
                // Process PayPal
                break;

            default:
                throw new ArgumentException();
        }
    }
}
public enum PaymentType
{
    CreditCard = 1,
    PayPal = 2
}