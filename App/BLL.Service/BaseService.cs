//using BLL.Service.Interface;
//using DAL.Entity.Models;
using DAL.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ModelBinding;

namespace BLL.Service
{
    public class BaseService : IBaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService([Dependency("UnitOfWork")] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


    }

}

