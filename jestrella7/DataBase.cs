using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace jestrella7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
