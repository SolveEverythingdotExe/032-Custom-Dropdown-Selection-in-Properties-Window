using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class ParentForm : Form
    {
        [Editor(typeof(PercentageDropdownEditor), typeof(UITypeEditor))]
        public string Percentage { get; set; }

        public ParentForm()
        {
            InitializeComponent();
        }
    }
}
