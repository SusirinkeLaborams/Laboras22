using Laboras22.Models.Projects;
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
        public string Name { get { return Student.Name; } }
        private StudentViewModel student;
        public StudentViewModel Student 
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                model.StudentId = value.Id;
            }
        }
        private ProjectViewModel project;
        public ProjectViewModel Project 
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                model.ProjectId = value.Id;
            }
        }
        public string Grade 
        {
            get
            {
                return grade != null ? grade.Value.ToString() : null;
            } 
            set
            {
                var g = int.Parse(value);
                if(grade != null)
                    grade.Value = g;
            }
        }
        private GradeViewModel grade;
        public static new async Task<ProjectParticipantViewModel> Create(ProjectParticipant model = null)
        {
            var instance = await ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>.Create(model);
            if(instance.Grade == null)
            {
                var grade = await GradeViewModel.Create();
                grade.Value = 0;
                grade.Participant = instance;
            }
            return instance;
        }
        public override async Task Insert()
        {
            await base.Insert();
            await grade.Insert();
        }
        protected override async Task RefreshFields()
        {
            student = await StudentViewModel.Get(model.StudentId);
            project = await ProjectViewModel.Get(model.ProjectId);
            grade = (await GradeViewModel.Where(x => x.ParticipantId == model.Id)).SingleOrDefault();
        }
    }
}
