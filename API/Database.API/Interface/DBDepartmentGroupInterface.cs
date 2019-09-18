using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Interface
{
    public interface DBDepartmentGroupInterface
    {
        List<DbDepartmentGroup> GetDepartments();

        List<DbDepartmentGroup> GetGroups();
        string AddListOfValue(DbDepartmentGroup value);
        string EditListOfValue(DbDepartmentGroup value, string OLDDEPARTMENTGROUP, string OLDDEPARTMENTNAME);
        List<DbDepartmentGroup> GetDataOfValue(DbDepartmentGroup value);
        string DeleteOfValue(DbDepartmentGroup value);


    }
}
