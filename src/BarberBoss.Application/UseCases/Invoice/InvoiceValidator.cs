using BarberBoss.Communication.Invoice.Requests;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Invoice;

public class InvoiceValidator : AbstractValidator<RequestRegisterInvoiceJson>
{
    public InvoiceValidator()
    {
        RuleFor(invoice => invoice.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(invoice => invoice.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(invoice => invoice.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.BILLING_CANNOT_FOR_THE_FUTURE);
        RuleFor(invoice => invoice.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}