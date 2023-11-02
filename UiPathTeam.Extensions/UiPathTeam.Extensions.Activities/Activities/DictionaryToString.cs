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
    [LocalizedDisplayName(nameof(Resources.DictionaryToString_DisplayName))]
    [LocalizedDescription(nameof(Resources.DictionaryToString_Description))]
    public class DictionaryToString : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryToString_In_Dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryToString_In_Dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> In_Dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryToString_Result_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryToString_Result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> Result { get; set; }

        #endregion


        #region Constructors

        public DictionaryToString()
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

            String StrOut = String.Empty;
            String delim = String.Empty;

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            foreach (KeyValuePair<object, object> entry in in_dictionary)
            {
                StrOut = StrOut + delim + "[" + entry.Key.ToString();
                delim = ", ";
                StrOut = StrOut + delim + entry.Value.ToString() + "]";
            }

            // Outputs
            return (ctx) => {
                Result.Set(ctx, StrOut);
            };
        }

        #endregion
    }
}

