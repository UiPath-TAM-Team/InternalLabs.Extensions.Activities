using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using InternalLabs.Extensions.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using System.Collections;
using System.Linq;

namespace InternalLabs.Extensions.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetDictionaryKeys_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetDictionaryKeys_Description))]
    public class GetDictionaryKeys : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDictionaryKeys_In_Dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDictionaryKeys_In_Dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> In_Dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetDictionaryKeys_Out_Keys_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetDictionaryKeys_Out_Keys_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<List<object>> Out_Keys { get; set; }

        #endregion


        #region Constructors

        public GetDictionaryKeys()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (In_Dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_Dictionary)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var in_dictionary = In_Dictionary.Get(context);

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            var result = in_dictionary.Keys.ToList();
            // Outputs
            return (ctx) => {
                Out_Keys.Set(ctx, result);
            };
        }

        #endregion
    }
}

