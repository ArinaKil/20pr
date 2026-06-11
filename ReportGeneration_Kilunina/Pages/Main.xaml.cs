using ReportGeneration_Kilunina.Classes;
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

namespace ReportGeneration_Kilunina.Pages
{
    public partial class Main : Page
    {
        public List<GroupContext> AllGroups = GroupContext.AllGroups();
        public List<StudentContext> AllStudents = StudentContext.AllStudent();
        public List<WorkContext> AllWorks = WorkContext.AllWorks();
        public List<EvaluationContext> AllEvaluations = EvaluationContext.AllEvaluations();
        public List<DisciplineContext> AllDisciplines = DisciplineContext.AllDisciplines();
        public Main()
        {
            InitializeComponent();
            CreateGroupUI();
            CreateStudents();
        }

        public void CreateGroupUI() 
        {
            foreach (GroupContext Group in AllGroups)
                CBGroups.Items.Add(Group.Name);
            CBGroups.Items.Add("Выберите");
            CBGroups.SelectedIndex = CBGroups.Items.Count - 1;
        }

        public void CreateStudents(List<StudentContext> AllStudents) 
        {
            Parent.Children.Clear();

            foreach (StudentContext Student in AllStudents)
                Parent.Children.Add(new Items.Student(Student, this));
        }

        private void SelectGroup(object sender, SelectionChangedEventArgs e)
        {
            if (CBGroups.SelectedIndex != CBGroups.Items.Count - 1) {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroups.SelectedItem).Id;
                CreateStudents(AllStudents.FindAll(x => x.IdGroup == IdGroup));
            }
        }
        private void SelectStudents(object sender, KeyEventArgs e)
        {
            List<StudentContext> SearchStudent = AllStudents;
            if (CBGroups.SelectedIndex != CBGroups.Items.Count - 1)
            {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroups.SelectedItem).Id;
                SearchStudent = AllStudents.FindAll(x => x.IdGroup == IdGroup)
            }
            CreateStudents(SearchStudent.FindAll(x => $"{x.Lastname} {x.Firstname}".Contains(TBFIO.Text)));
        }

        private void ReportGeneration(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
