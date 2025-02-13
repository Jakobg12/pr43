using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;uid=root;database=pr43;pwd=;port=3306;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
