using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    class AssignmentListViewModel : INotifyPropertyChanged
    {
        private bool m_OnlyOwnAssignments;
        public IEnumerable<AssignmentViewModel> Assignments { get; private set; }
        
        public AssignmentListViewModel(bool onlyOwnAssignments)
        {
            m_OnlyOwnAssignments = onlyOwnAssignments;
            LoadAssignments();
        }

        private async void LoadAssignments()
        {
            if (m_OnlyOwnAssignments)
            {
                //Assignments = await AssignmentViewModel.Where(x => x.
            }
            else
            {
                Assignments = await AssignmentViewModel.Enumerate();
            }

            OnPropertyChanged("Assignments");
        }

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
