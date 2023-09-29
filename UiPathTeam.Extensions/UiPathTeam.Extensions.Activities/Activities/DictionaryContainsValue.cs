using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UiPathTeam.Extensions.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace UiPathTeam.Extensions.Activities
{
    [LocalizedDisplayName(nameof(Resources.DictionaryContainsValue_DisplayName))]
    [LocalizedDescription(nameof(Resources.DictionaryContainsValue_Description))]
    public class DictionaryContainsValue : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsValue_Dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsValue_Dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> Dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsValue_Result_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsValue_Result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<bool> Result { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsValue_Value_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsValue_Value_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<object> Value { get; set; }

        #endregion


        #region Constructors

        public DictionaryContainsValue()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Dictionary)));
            if (Value == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Value)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var dictionary = Dictionary.Get(context);
            var value = Value.Get(context);

            var result = Result.Get(context);


            if (dictionary.ContainsValue(value))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            // Outputs
            return (ctx) => {
                Result.Set(ctx, result);
            };
        }

        #endregion
    }
}

