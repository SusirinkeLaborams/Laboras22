﻿using Laboras22.Models.Projects;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectParticipantViewModel : ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>
    {
        public UserViewModel Student { get; set; }
        public RatingViewModel Rating { set; get; }
        public GradeViewModel Grade { set; get; }
        public int? GradeValue { get { return Grade != null ? (int?)Grade.Value : null; } }
        public int? RatingValue { get { return Rating != null ? (int?)Rating.Value : null; } }
        public string RatingComment { get { return Rating != null ? Rating.Comment : null; } }
        protected override async Task RefreshFields()
        {
            Student = await UserViewModel.Get(model.Student);
            Grade = (await GradeViewModel.Where(g => g.Participant == model.Id)).Single();
            Rating = (await RatingViewModel.Where(r => r.Participant == model.Id)).Single();
        }
    }
}
