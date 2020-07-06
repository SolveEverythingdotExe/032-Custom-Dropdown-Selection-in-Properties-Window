using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MainApplication
{
    public class PercentageDropdownEditor: UITypeEditor
    {
        //service for displaying windows forms and dropdown in the properties window
        private IWindowsFormsEditorService windowsFormsEditorService;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            //set the Edit style on the Properties Window as a Dropdown
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            windowsFormsEditorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            //create a ListBox
            ListBox listBox = new ListBox();

            //add the selection
            listBox.Items.Add("10%");
            listBox.Items.Add("15%");
            listBox.Items.Add("20%");
            listBox.Items.Add("25%");
            listBox.Items.Add("30%");

            //set the current value
            if (value != null)
                listBox.SelectedItem = value;

            //add an event
            listBox.SelectedValueChanged += ListBox_SelectedValueChanged;

            //show the dropdown
            windowsFormsEditorService.DropDownControl(listBox);

            return listBox.SelectedItem;
        }

        private void ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //automatically close the dropdown after the user selects item
            if (windowsFormsEditorService != null)
                windowsFormsEditorService.CloseDropDown();
        }
        //done, lets build and test
    }
}
