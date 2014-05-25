using Laboras22.ViewModels.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboras22.Views.Pages.Assignments
{
    /// <summary>
    /// Interaction logic for AssignmentDetailsPage.xaml
    /// </summary>
    partial class AssignmentDetailsPage : PageBase
    {
        internal AssignmentDetailsPage(MainWindow parentWindow, AssignmentViewModel assignment) :
            base(parentWindow)
        {
            InitializeComponent();
            DataContext = assignment;
        }
    }
}
