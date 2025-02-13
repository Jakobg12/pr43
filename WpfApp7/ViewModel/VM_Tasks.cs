using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp7.Classes;
using WpfApp7.Models;

namespace WpfApp7.ViewModel
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();

        public ObservableCollection<Tasks> Tasks { get; set; }

        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>();

        public RealyCommand OnAddTasks
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Tasks NewTasks = new Tasks();
                    Tasks.Add(NewTasks);
                    tasksContext.Contact.Add(NewTasks);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}
