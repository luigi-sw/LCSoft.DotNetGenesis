using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace __company__.__project__.Web.Extensions;
public static class MvcOptionsExtensions
{
    public static void UseCustomModelBindingMessages(this MvcOptions options, IStringLocalizer localizer)
    {
        options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((value, fieldName) =>
           localizer["AttemptedValueIsInvalid", value, fieldName]);

        options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(fieldName =>
            localizer["MissingBindRequiredValue", fieldName]);

        options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() =>
            localizer["MissingKeyOrValue"]);

        options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() =>
            localizer["MissingRequestBodyRequiredValue"]);

        options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(value =>
            localizer["NonPropertyAttemptedValueIsInvalid", value]);

        options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() =>
            localizer["NonPropertyUnknownValueIsInvalid"]);

        options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() =>
            localizer["NonPropertyValueMustBeANumber"]);

        options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(fieldName =>
            localizer["UnknownValueIsInvalid", fieldName]);

        options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(value =>
            localizer["ValueIsInvalid", value]);

        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(fieldName =>
            localizer["ValueMustBeANumber", fieldName]);

        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(fieldName =>
            localizer["ValueMustNotBeNull", fieldName]);
    }
}

