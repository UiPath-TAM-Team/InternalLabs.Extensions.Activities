using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using UiPathTeam.Extensions.Activities.Design.Designers;
using UiPathTeam.Extensions.Activities.Design.Properties;

namespace UiPathTeam.Extensions.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            //var categoryAttribute = new CategoryAttribute($"{Resources.Category}");
            var categoryAttribute = new CategoryAttribute($"{Resources.CategoryStatements}");

            builder.AddCustomAttributes(typeof(Test), categoryAttribute);
            builder.AddCustomAttributes(typeof(Test), new DesignerAttribute(typeof(TestDesigner)));
            builder.AddCustomAttributes(typeof(Test), new HelpKeywordAttribute(""));


            builder.AddCustomAttributes(typeof(AddToDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(AddToDictionary), new DesignerAttribute(typeof(Design.Designers.AddToDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(AddToDictionary), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
