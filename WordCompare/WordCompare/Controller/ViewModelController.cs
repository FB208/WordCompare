using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompare.ViewModel;

namespace WordCompare.Controller
{
    public static class ViewModelController
    {
        public static MainWindowVM mainWindowVM = new MainWindowVM();
        public static IntersectWindowVM intersectWindowVM = new IntersectWindowVM();
        public static AttributeWindowVM attributeWindowVM = new AttributeWindowVM();

        public static string ignoreFilePath = "";
    }
}
