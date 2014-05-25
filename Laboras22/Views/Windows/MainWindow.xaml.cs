using Laboras22.Classes;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages;
using Laboras22.Views.Pages.Projects;
using Laboras22.Views.Pages.Users;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        private Stack<PageBase> pages = new Stack<PageBase>();
        internal SessionViewModel Session { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            AzureService.Connect();

            DataContext = this;

            PushPage(new LoginPage(this));
        }

        public void PushPage(PageBase page)
        {
            pages.Push(page);

            m_Frame.Content = page;
            page.OnDisplay();            
        }

        public void PopPage()
        {
            if(pages.Count > 1)
            {
                pages.Pop();

                var page = pages.Peek();
                m_Frame.Content = page;
                page.OnDisplay();
            }
        }

        protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == System.Windows.Input.Key.Back)
            {
                var focusedControl = Keyboard.FocusedElement;

                if (!(focusedControl is TextBox) && !(focusedControl is PasswordBox))
                {
                    PopPage();
                }
            }
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            m_Frame.NavigationService.RemoveBackEntry();
        }

        public bool IsBackButtonEnabled
        {
            get
            {
                return pages.Count > 1;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopPage();
        }
    }
}
