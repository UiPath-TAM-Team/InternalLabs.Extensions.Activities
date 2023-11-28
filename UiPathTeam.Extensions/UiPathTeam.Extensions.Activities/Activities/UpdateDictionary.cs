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
    [LocalizedDisplayName(nameof(Resources.UpdateDictionary_DisplayName))]
    [LocalizedDescription(nameof(Resources.UpdateDictionary_Description))]
    public class UpdateDictionary : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.UpdateDictionary_In_Key_DisplayName))]
        [LocalizedDescription(nameof(Resources.UpdateDictionary_In_Key_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<object> In_Key { get; set; }

        [LocalizedDisplayName(nameof(Resources.UpdateDictionary_In_Dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.UpdateDictionary_In_Dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Dictionary<object, object>> In_Dictionary { get; set; }

        [LocalizedDisplayName(nameof(Resources.UpdateDictionary_In_Value_DisplayName))]
        [LocalizedDescription(nameof(Resources.UpdateDictionary_In_Value_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<object> In_Value { get; set; }

        [LocalizedDisplayName(nameof(Resources.UpdateDictionary_Out_Result_DisplayName))]
        [LocalizedDescription(nameof(Resources.UpdateDictionary_Out_Result_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<bool> Out_Result { get; set; }

        #endregion


        #region Constructors

        public UpdateDictionary()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (In_Key == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_Key)));
            if (In_Dictionary == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_Dictionary)));
            if (In_Value == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(In_Value)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var in_key = In_Key.Get(context);
            var in_dictionary = In_Dictionary.Get(context);
            var in_value = In_Value.Get(context);
            var out_result = Out_Result.Get(context);

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            if (in_dictionary.ContainsKey(in_key))
            {
                in_dictionary[in_key] = in_value;
                out_result = true;
            }
            else
            {
                out_result = false;
            }

            // Outputs
            return (ctx) => {
                Out_Result.Set(ctx, out_result);
            };
        }

        #endregion
    }
}

