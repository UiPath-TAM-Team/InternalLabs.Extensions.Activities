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
    [LocalizedDisplayName(nameof(Resources.DictionaryContainsKey_DisplayName))]
    [LocalizedDescription(nameof(Resources.DictionaryContainsKey_Description))]
    public class DictionaryContainsKey : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsKey_In_dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsKey_In_dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> In_dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsKey_In_key_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsKey_In_key_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<object> In_key { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsKey_Out_result_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsKey_Out_result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<bool> Out_result { get; set; }

        [LocalizedDisplayName(nameof(Resources.DictionaryContainsKey_Out_value_DisplayName))]
        [LocalizedDescription(nameof(Resources.DictionaryContainsKey_Out_value_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> Out_value { get; set; }

        #endregion


        #region Constructors

        public DictionaryContainsKey()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var in_dictionary = In_dictionary.Get(context);
            var in_key = In_key.Get(context);
            bool out_result;
            object out_value;

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            if (in_dictionary.ContainsKey(in_key))
            {
                out_result = true;
                out_value = (object)in_dictionary[in_key];
            }
            else
            {
                out_result = false;
                out_value = null;
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

