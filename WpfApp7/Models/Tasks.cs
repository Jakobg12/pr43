using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using WpfApp7.Classes;

namespace WpfApp7.Models
{
    public class Tasks : Notification
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success) MessageBox.Show("Название не должно быть пустым, и не более 50 символов!", "Не корректный ввод названия.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string discription;

        public string Discription
        {
            get { return discription; }
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success) MessageBox.Show("Описание не должен быть пустым, и не более 100 символов!", "Не корректный ввод описания.");
                else
                {
                    discription = value;
                    OnPropertyChanged("Discription");
                }
            }
        }

        private int categorysId;

        public int CategorysId
        {
            get { return categorysId; }
            set
            {
                categorysId = value;
                OnPropertyChanged("CategorysId");
            }
        }

        [Schema.NotMapped]
        private bool isEnable;

        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }

        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModel.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                });
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить задание?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).vm_tasks.Contact.Remove(this);
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                });
            }
        }

        [Schema.NotMapped]
        public ObservableCollection<Categorys> Categorys
        {
            get
            {
                return new ObservableCollection<Categorys>(new Context.CategorysContext().Categorys);
            }
        }
    }
}
