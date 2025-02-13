using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using WpfApp7.Classes;
using WpfApp7.Models;

namespace WpfApp7.ViewModel
{
    public class VM_Categorys : Notification
    {
        public CategorysContext categorysContext = new CategorysContext();

        public ObservableCollection<Categorys> Categorys { get; set; }

        public VM_Categorys() => Categorys = new ObservableCollection<Categorys>();

        public RealyCommand OnAddCategorys
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Categorys NewCategorys = new Categorys();
                    Categorys.Add(NewCategorys);
                    categorysContext.Groups.Add(NewCategorys);
                    categorysContext.SaveChanges();
                });
            }
        }
    }
}
