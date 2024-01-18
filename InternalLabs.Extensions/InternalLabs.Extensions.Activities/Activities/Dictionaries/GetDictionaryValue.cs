using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using InternalLabs.Extensions.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace InternalLabs.Extensions.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetDictionaryValue_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetDictionaryValue_Description))]
    public class GetDictionaryValue : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDictionaryValue_Dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDictionaryValue_Dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> Dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDictionaryValue_Key_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDictionaryValue_Key_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<object> Key { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDictionaryValue_Result_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDictionaryValue_Result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> Result { get; set; }

        #endregion


        #region Constructors

        public GetDictionaryValue()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Dictionary)));
            if (Key == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Key)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var dictionary = Dictionary.Get(context);
            var key = Key.Get(context);
            var boolresult = false;

            boolresult = dictionary.TryGetValue(key, out object result);

            if (!boolresult)
            {
                result = null;
            }

            // Outputs
            return (ctx) => {
                Result.Set(ctx, result);
            };
        }

        #endregion
    }
}

