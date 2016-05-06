using CoderCamps;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class CarService : ICarService
    {
        IGenericRepository _repo;

        public object Cars
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CarService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Method to get a single car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            var car = _repo.Query<Car>().Where(c => c.Id == id).Include(c => c.Reviews).ThenInclude(r => r.SentimentEntities).FirstOrDefault();
            return car;
        }

        /// <summary>
        /// Method to add a car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        public void AddCar(string id, Car car)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.CarsToLoan).FirstOrDefault();
            car.DateAdded = DateTime.Now;
            user.CarsToLoan.Add(car);
            _repo.SaveChanges();  
        }


        /// <summary>
        /// Method to delete a car
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCar(int id)
        {
            var car = _repo.Query<Car>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete<Car>(car);
            _repo.SaveChanges();
        }

        /// <summary>
        /// Method to update a cars specs
        /// </summary>
        /// <param name="car"></param>
        public void UpdateCar(Car car)
        {
            var originalCar = _repo.Query<Car>().Where(c => c.Id == car.Id).FirstOrDefault();
            originalCar.Image = car.Image;
            originalCar.Door = car.Door;
            originalCar.Make = car.Make;
            originalCar.Model = car.Model;
            originalCar.Price = car.Price;
            originalCar.Year = car.Year;
            originalCar.Condition = car.Condition;
            originalCar.CtyMpg = car.CtyMpg;
            originalCar.Description = car.Description;
            originalCar.HwyMpg = car.HwyMpg;
            originalCar.CtyMpg = car.CtyMpg;
            originalCar.Seats = car.Seats;
            originalCar.Transmission = car.Transmission;
            originalCar.Miles = car.Miles;
            originalCar.IsActive = car.IsActive;

            _repo.Update<Car>(originalCar);

        }
        
        /// <summary>
        /// Method for car paging
        /// </summary>
        /// <param name="pagenum"></param>
        /// <returns></returns>
        public List<Car> GetCarShortList(int pagenum)
        {
            var cars = _repo.Query<Car>().Skip(4 * (pagenum - 1)).Take(4).ToList();
            return cars;
        }

        /// <summary>
        /// Method to retrieve all cars
        /// </summary>
        /// <returns></returns>
        public List<Car> GetAllCars()
        {
            var cars = _repo.Query<Car>().ToList();
            return cars;
        }

        public int GetCarNumber()
        {
            var list = _repo.Query<Car>().ToList();
            var num = list.Count;
            return num;
        }
    }
}
