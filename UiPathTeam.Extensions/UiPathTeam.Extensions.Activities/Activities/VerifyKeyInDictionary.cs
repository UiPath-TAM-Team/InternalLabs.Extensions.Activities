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
    [LocalizedDisplayName(nameof(Resources.VerifyKeyInDictionary_DisplayName))]
    [LocalizedDescription(nameof(Resources.VerifyKeyInDictionary_Description))]
    public class VerifyKeyInDictionary : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.VerifyKeyInDictionary_In_dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.VerifyKeyInDictionary_In_dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<string, object>> In_dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.VerifyKeyInDictionary_In_key_DisplayName))]
        [LocalizedDescription(nameof(Resources.VerifyKeyInDictionary_In_key_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> In_key { get; set; }

        [LocalizedDisplayName(nameof(Resources.VerifyKeyInDictionary_Out_result_DisplayName))]
        [LocalizedDescription(nameof(Resources.VerifyKeyInDictionary_Out_result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<bool> Out_result { get; set; }

        [LocalizedDisplayName(nameof(Resources.VerifyKeyInDictionary_Out_value_DisplayName))]
        [LocalizedDescription(nameof(Resources.VerifyKeyInDictionary_Out_value_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> Out_value { get; set; }

        #endregion


        #region Constructors

        public VerifyKeyInDictionary()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (In_dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_dictionary)));
            if (In_key == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_key)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var in_dictionary = In_dictionary.Get(context);
            var in_key = In_key.Get(context);
            var out_result = Out_result.Get(context);
            var out_value = Out_value.Get(context);

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            if (in_dictionary.Equals(in_key))
            {
                out_result = true;
                out_value = in_dictionary[in_key];
            }
            else
            {
                out_result = false;
            }
            // Outputs
            return (ctx) => {
                Out_result.Set(ctx, out_result);
                Out_value.Set(ctx, out_value);
            };
        }

        #endregion
    }
}

