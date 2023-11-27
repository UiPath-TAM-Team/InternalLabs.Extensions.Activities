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
    [LocalizedDisplayName(nameof(Resources.BuildDictionary_DisplayName))]
    [LocalizedDescription(nameof(Resources.BuildDictionary_Description))]
    public class BuildDictionary : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.BuildDictionary_In_keys_DisplayName))]
        [LocalizedDescription(nameof(Resources.BuildDictionary_In_keys_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Object[]> In_keys { get; set; }

        [LocalizedDisplayName(nameof(Resources.BuildDictionary_In_values_DisplayName))]
        [LocalizedDescription(nameof(Resources.BuildDictionary_In_values_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Object[]> In_values { get; set; }

        [LocalizedDisplayName(nameof(Resources.BuildDictionary_Out_dictionary_DisplayName))]
        [LocalizedDescription(nameof(Resources.BuildDictionary_Out_dictionary_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<Dictionary<object, object>> Out_dictionary { get; set; }

        #endregion


        #region Constructors

        public BuildDictionary()
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
            var in_keys = In_keys.Get(context);
            var in_values = In_values.Get(context);
            var out_dictionary = new Dictionary<object, object>();


            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            for (int x = 0; x < in_keys.Length; x++)
            {
                out_dictionary.Add(in_keys[x], in_values[x]);
            }



            // Outputs
            return (ctx) => {
                Out_dictionary.Set(ctx, out_dictionary);
            };
        }

        #endregion
    }
}

