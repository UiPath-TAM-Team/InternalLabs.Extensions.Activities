using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using UiPathTeam.Extensions.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace UiPathTeam.Extensions.Activities
{
    [LocalizedDisplayName(nameof(Resources.Test_DisplayName))]
    [LocalizedDescription(nameof(Resources.Test_Description))]
    public class Test : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.Test_InString_DisplayName))]
        [LocalizedDescription(nameof(Resources.Test_InString_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InString { get; set; }

        [LocalizedDisplayName(nameof(Resources.Test_OutString_DisplayName))]
        [LocalizedDescription(nameof(Resources.Test_OutString_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> OutString { get; set; }

        #endregion


        #region Constructors

        public Test()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (InString == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(InString)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var instring = InString.Get(context);

            var outstring = "Hello, " + instring;

            // Outputs
            return (ctx) => {
                OutString.Set(ctx, outstring);
            };
        }

        #endregion
    }
}

