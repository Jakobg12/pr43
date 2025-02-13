using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp7.Classes;

namespace WpfApp7.ViewModel
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_sotrud = new VM_Tasks();

        public VM_Categorys vm_groups = new VM_Categorys();

        public VM_Pages() => MainWindow.init.frame.Navigate(new View.Tasks.Main(vm_Tasks));

        public RealyCommand OpenTasks
        {
            get => new RealyCommand(obj => MainWindow.init.frame.Navigate(new View.Tasks.Main(vm_tasks)));
        }

        public RealyCommand OpenCatergorys
        {
            get => new RealyCommand(obj => MainWindow.init.frame.Navigate(new View.Categorys.Main(vm_categorys)));
        }
    }
}
