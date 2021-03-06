﻿using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    class AssignmentListViewModel : NotifyPropertyChangedBase
    {
        private bool m_OnlyOwnAssignments;
        private SessionViewModel m_Session;
        public IEnumerable<AssignmentViewModel> Assignments { get; private set; }
        
        public AssignmentListViewModel(bool onlyOwnAssignments, SessionViewModel session)
        {
            m_OnlyOwnAssignments = onlyOwnAssignments;
            m_Session = session;
        }
        
        public async Task LoadAssignments()
        {
            if (m_OnlyOwnAssignments)
            {
                switch (m_Session.UserType)
                {
                    case SessionViewModel.UserTypeEnum.Lecturer:
                        Assignments = await AssignmentViewModel.Where(x => x.LecturerId == m_Session.User.Id);
                        break;

                    default:
                        throw new NotSupportedException("Only lecturers can have own assignments.");
                }
            }
            else
            {
                Assignments = await AssignmentViewModel.Enumerate();
            }

            OnPropertyChanged("Assignments");
        }
    }
}
