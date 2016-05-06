using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class DriverRatingService : IDriverRatingService
    {
        IGenericRepository _repo;

        public DriverRatingService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Gets a list of ratings associated with a ApplicationUser
        /// </summary>
        /// <returns></returns>
        public List<RatingDriver> GetDriverRatings()
        {
            var driverRatings = _repo.Query<RatingDriver>().ToList();
            return driverRatings;
        }


        /// <summary>
        /// Method to get a single user rating
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RatingDriver GetDriverRating(int id)
        {
            var driverRating = _repo.Query<RatingDriver>().Where(c => c.Id == id).FirstOrDefault();
            return driverRating;
        }


        /// <summary>
        /// Method to add a rating to a applicationuser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driverRating"></param>
        /// <returns></returns>
        public decimal AddDriverRating(string id, RatingDriver driverRating)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(c => c.DriverRatings).FirstOrDefault();
            user.DriverRatings.Add(driverRating);
            _repo.SaveChanges();

            //Helper method that calculates the driverRating sent
            this.CalculateDriverRating(user, driverRating);
            _repo.SaveChanges();

            return user.AverageRating;

        }


        /// <summary>
        /// Helper method used for calculating average RatingDriver
        /// Also separated logic for easier unit testing
        /// </summary>
        /// <param name="user"></param>
        /// <param name="driverRating"></param>
        /// <returns></returns>
        public decimal CalculateDriverRating(ApplicationUser user, RatingDriver driverRating)
        {
            var total = ((driverRating.PaymentExperience) + (driverRating.ProfessionalismOfDriver) + (driverRating.PromptReplies) + (driverRating.SchedulingExperience) + (driverRating.Trustworthiness) + (driverRating.ConditionOfReturnedCar) + (driverRating.DeliveryExperience)) / 7;
            driverRating.OverallRating = total;

            if (user.DriverRatings.Count == 0) {
                user.AverageRating = ((user.AverageRating * user.DriverRatings.Count) + total) / user.DriverRatings.Count;
            } else
            {
                user.AverageRating = ((user.AverageRating * (user.DriverRatings.Count - 1)) + total) / user.DriverRatings.Count;
            }
            return user.AverageRating;
        }

        /// <summary>
        /// Method to delete a single driver rating
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDriverRating(int id)
        {
            var driverRating = _repo.Query<RatingDriver>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete<RatingDriver>(driverRating);
            _repo.SaveChanges();
        }

        /// <summary>
        /// Method to update a driverRating
        /// </summary>
        /// <param name="driverRating"></param>
        public void UpdateDriverRating(RatingDriver driverRating)
        {
            var originalDriverRating = _repo.Query<RatingDriver>().Where(c => c.Id == driverRating.Id).FirstOrDefault();
            originalDriverRating.PaymentExperience = driverRating.PaymentExperience;
            originalDriverRating.ProfessionalismOfDriver = driverRating.ProfessionalismOfDriver;
            originalDriverRating.PromptReplies = driverRating.PromptReplies;
            originalDriverRating.SchedulingExperience = driverRating.SchedulingExperience;
            originalDriverRating.Trustworthiness = driverRating.Trustworthiness;
            originalDriverRating.OverallRating = driverRating.OverallRating;

            _repo.Update<RatingDriver>(originalDriverRating);

        }
    }
}
