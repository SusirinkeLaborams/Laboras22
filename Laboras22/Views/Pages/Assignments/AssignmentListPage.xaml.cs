using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.Views.Pages.Assignments
{
    public partial class AssignmentListPage : PageBase
    {
        TabItem m_AllAssignmentsTab;
        TabItem m_MyAssignmentsTab;

        public AssignmentListPage(MainWindow parentWindow) :
            base(parentWindow)
        {
            InitializeComponent();

            m_AllAssignmentsTab = new TabItem();
            m_AllAssignmentsTab.Header = "All assignments";
            m_TabControl.Items.Add(m_AllAssignmentsTab);

            m_MyAssignmentsTab = new TabItem();
            m_MyAssignmentsTab.Header = "My assignments";
            m_TabControl.Items.Add(m_MyAssignmentsTab);
        }
    }
}
