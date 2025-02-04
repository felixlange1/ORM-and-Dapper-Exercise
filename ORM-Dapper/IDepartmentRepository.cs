
using System;
using System.Collections.Generic;
using ORM_Dapper;

namespace IntroSQL
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments(); 
        
        public void InsertDepartment(string newDepartmentName);
    }
}