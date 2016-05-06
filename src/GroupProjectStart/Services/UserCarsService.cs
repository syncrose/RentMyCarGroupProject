using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class UserCarsService : IUserCarsService
    {
        IGenericRepository _repo;
        public UserCarsService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Basic method to return all users both with and without cars including their cars if they have them
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> GetUserCars()
        {

            
            var cars = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).ToList();

            return cars;
        }

        /// <summary>
        /// Returns 2 users and their cars for paging method
        /// </summary>
        /// <param name="pagenum"></param>
        /// <returns></returns>
        public List<ApplicationUser> GetPageCars(int pagenum)
        {
            var cars = _repo.Query<ApplicationUser>().Where(u => u.CarsToLoan.Count != 0).Skip(2 * (pagenum - 1)).Take(2).Include(u => u.CarsToLoan).ToList();
          
            return cars;
        }

        /// <summary>
        /// method to retrive total users who have a list of cars
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> getAllUsers()
        {
            var users = _repo.Query<ApplicationUser>().Where(u => u.CarsToLoan.Count != 0).ToList();
            return users;
        }


        /// <summary>
        /// returns just a single user, their cars, and sentiment data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationUser getUserCar(string id)
        {
            var user = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews).ThenInclude(r => r.SentimentEntities).Where(u => u.Id == id).FirstOrDefault();
       
            return user;
        }

    }
}

