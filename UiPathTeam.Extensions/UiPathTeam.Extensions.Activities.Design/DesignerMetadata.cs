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

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(AddToDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(AddToDictionary), new DesignerAttribute(typeof(AddToDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(AddToDictionary), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(CountDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(CountDictionary), new DesignerAttribute(typeof(CountDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(CountDictionary), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DictionaryContainsKey), categoryAttribute);
            builder.AddCustomAttributes(typeof(DictionaryContainsKey), new DesignerAttribute(typeof(DictionaryContainsKeyDesigner)));
            builder.AddCustomAttributes(typeof(DictionaryContainsKey), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DictionaryContainsValue), categoryAttribute);
            builder.AddCustomAttributes(typeof(DictionaryContainsValue), new DesignerAttribute(typeof(DictionaryContainsValueDesigner)));
            builder.AddCustomAttributes(typeof(DictionaryContainsValue), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetDictionaryValue), categoryAttribute);
            builder.AddCustomAttributes(typeof(GetDictionaryValue), new DesignerAttribute(typeof(GetDictionaryValueDesigner)));
            builder.AddCustomAttributes(typeof(GetDictionaryValue), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(RemoveFromDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveFromDictionary), new DesignerAttribute(typeof(RemoveFromDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(RemoveFromDictionary), new HelpKeywordAttribute(""));
            builder.AddCustomAttributes(typeof(GetDictionaryValue), categoryAttribute);
            builder.AddCustomAttributes(typeof(GetDictionaryValue), new DesignerAttribute(typeof(GetDictionaryValueDesigner)));
            builder.AddCustomAttributes(typeof(GetDictionaryValue), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(CountDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(CountDictionary), new DesignerAttribute(typeof(CountDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(CountDictionary), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
