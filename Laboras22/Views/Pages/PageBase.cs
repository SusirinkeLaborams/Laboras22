using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.Views.Pages
{
    public abstract class PageBase : Page
    {
        protected MainWindow window;

        protected PageBase(MainWindow window)
        {
            this.window = window;
        }

        public virtual void OnDisplay()
        {
        }
    }
}
