using AppointmentScheduler.Models;
using AppointmentScheduler.Models.ViewModels;
using AppointmentScheduler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _db;
        

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<DoctorVM> GetDoctorList()
        {
            var doctor = (from user in _db.Users
                          join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                          join roles in _db.Roles.Where(x=>x.Name==Helper.Doctor) on userRoles.RoleId equals roles.Id
                          select new DoctorVM
                          {
                              Id = user.Id,
                              Name = user.Name
                          }
                          ).ToList();
            return doctor;
        }

        public List<PatientVM> GetPatientList()
        {
            var patient = (from user in _db.Users
                           join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(x=>x.Name==Helper.Patient) on userRoles.RoleId equals roles.Id
                           select new PatientVM
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                          ).ToList();
            return patient;
        }
    }
}
