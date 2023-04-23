using Zoople;

namespace SpellingOptions_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ToolStripDropDownButton oLang = new("Language (en-US)");
            ToolStripDropDown oDropDown = new();
            oDropDown.Items.Add("en-US");
            oDropDown.Items.Add("nl-NL");
            oDropDown.Items.Add("fr-FR");

            oLang.Padding = new(3);
            oLang.DropDown = oDropDown;

            htmlEditControl1.ToolStripItems.Add(oLang);

            oLang.DropDownItemClicked += OLang_DropDownItemClicked;

            htmlEditControl1.EnableInlineSpelling = true;
            htmlEditControl1.DefaultSpellingLanguage = "en-US";
        }

        private void OLang_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            ((ToolStripDropDownButton)sender).Text = "Language (" + e.ClickedItem.ToString() + ")";

            htmlEditControl1.DefaultSpellingLanguage = e.ClickedItem.ToString();
            htmlEditControl1.SpellCheckDocument();
        }

        private void htmlEditControl1_SpellCheckWord(object sender, Zoople.SpellCheckWordEventArgs e)
        {

            if (e.UserInterfaceAction == SpellCheckWordEventArgs.UIAction.UI_Typing &&
                   e.SuggestedAction == Zoople.SpellCheckWordEventArgs.Actions.Action_Replace)
            {
               e.ActualAction = Zoople.SpellCheckWordEventArgs.Actions.Action_None;
            }
        }
    }
}