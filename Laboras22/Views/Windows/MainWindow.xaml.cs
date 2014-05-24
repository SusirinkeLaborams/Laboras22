using Laboras22.Classes;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Stack<Page> pages = new Stack<Page>();
        public MainWindow()
        {
            InitializeComponent();
            AzureService.Connect();
            
            PushPage(new LoginPage());
        }
        public void PushPage(Page page)
        {
            pages.Push(page);
            m_Frame.Content = pages.Peek();
        }
        public void PopPage()
        {
            if(pages.Count > 0)
            {
                pages.Pop();
                m_Frame.Content = pages.Count != 0 ? pages.Peek() : null;
            }
        }
        protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == System.Windows.Input.Key.Back)
                PopPage();
        }
    }
}
