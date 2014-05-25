using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
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
        private AssignmentListViewModel m_Assignments;

        public AssignmentListPage(MainWindow parentWindow, bool onlyOwnAssignments) :
            base(parentWindow)
        {
            InitializeComponent();

            DataContext = m_Assignments = new AssignmentListViewModel(onlyOwnAssignments, window.Session);
        }
    }
}
