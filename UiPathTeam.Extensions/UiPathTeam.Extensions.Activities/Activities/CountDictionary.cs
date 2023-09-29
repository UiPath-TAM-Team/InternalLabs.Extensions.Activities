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
    [LocalizedDisplayName(nameof(Resources.CountDictionary_DisplayName))]
    [LocalizedDescription(nameof(Resources.CountDictionary_Description))]
    public class CountDictionary : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.CountDictionary_In_dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.CountDictionary_In_dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> In_dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.CountDictionary_Out_result_DisplayName))]
        [LocalizedDescription(nameof(Resources.CountDictionary_Out_result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<int> Out_result { get; set; }

        #endregion


        #region Constructors

        public CountDictionary()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (In_dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_dictionary)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var in_dictionary = In_dictionary.Get(context);

            var out_result = in_dictionary.Count;

            // Outputs
            return (ctx) => {
                Out_result.Set(ctx, out_result);
            };
        }

        #endregion
    }
}

