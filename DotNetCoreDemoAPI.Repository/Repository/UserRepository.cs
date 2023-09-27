using InfucareRx.PatientHealthApp.Database;
using InfucareRx.PatientHealthApp.Database.Entity;
using InfucareRx.PatientHealthApp.Repository.Interfaces;
using InfucareRx.PatientHealthApp.Repository.Interfaces.Base;
using InfucareRx.PatientHealthApp.Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(InfucareRxPatientHealthAppDbContext context) : base(context) { }
    }
}
