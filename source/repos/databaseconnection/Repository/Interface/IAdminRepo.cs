
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databaseconnection.DataModel;

namespace databaseconnection.Repository.Interface
{
    public interface IAdminRepo
    {
        int InsertUser(AdminModel user);
        AdminModel GetById(int id);
        List<AdminModel> GetAll();
        int Delete(int id);
        int UpdateUser(AdminModel user);
    }
}
