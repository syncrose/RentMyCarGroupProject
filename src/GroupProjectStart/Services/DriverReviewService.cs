using CoderCamps;
using GroupProjectStart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class DriverReviewService : IDriverReviewService
    {
        IGenericRepository _repo;
        public DriverReviewService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Method to return a list of all driver reviews
        /// </summary>
        /// <returns></returns>
        public List<DriverReview> GetReviews()
        { 
            var data = _repo.Query<DriverReview>().ToList();
            return data;
        }


        /// <summary>
        /// method to return just a single driver review
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DriverReview GetReview(int Id)
        {
            var data = _repo.Query<DriverReview>().Where(m => m.Id == Id).Include(m => m.SentimentEntities).FirstOrDefault();
            return data;
        }


        /// <summary>
        /// Method to add a review to a list within a ApplicationUser
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="review"></param>
        /// <param name="sp"></param>
        public async void AddDriverReview(string Id, DriverReview review, IServiceProvider sp)
        {
            var _db = sp.GetService<ApplicationDbContext>();

            var result = await Get(review.Message);


            //Adds sentiment info flattened data to a driver review
            review.SentimentEntities = new List<SentimentInfo>();
            foreach (var r in result)
            {
                var sent = new SentimentInfo()
                {
                    SentimentScore = r.sentiment.score,
                    SentimentType = r.sentiment.type

                };
                review.SentimentEntities.Add(sent);

            }


           
            review.TimeCreated = DateTime.Now;


            var user = _db.Users.Where(u => u.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            user.Reviews.Add(review);
            _db.SaveChanges();
           
        }

        /// <summary>
        /// Method that will update a review if need be
        /// </summary>
        /// <param name="review"></param>
        public void UpdateReview(DriverReview review)
        {
            var originalReview = _repo.Query<DriverReview>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<DriverReview>(originalReview);
        }


        /// <summary>
        /// Method to delete review 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteReview(int id)
        {
            var data = _repo.Query<DriverReview>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<DriverReview>(data);
            _repo.SaveChanges();
        }


        /// <summary>
        /// Method that talks to Alchemy API to determine entity and sentiment calculation
        /// </summary>
        /// <param name="sampleText"></param>
        /// <returns></returns>
        public async Task<List<Entity>> Get(string sampleText)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                    {
                       { "apikey", "20516fb6c289bac88bd5703e6ded4401ba95f983" },
                       { "text", sampleText},
                       { "outputMode", "json"},
                       { "sentiment", "1"},
                       { "disambiguate", "0"},
                       { "linkedData", "0"},
                       { "coreference", "0"},
                       { "quotations", "0"}
                    };

                var content = new FormUrlEncodedContent(values);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = await client.PostAsync("http://gateway-a.watsonplatform.net/calls/text/TextGetRankedNamedEntities", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    SentimentData sentimentData = JsonConvert.DeserializeObject<SentimentData>(responseString);
                    return sentimentData.entities;
                }

                //Testing
                return new List<Entity>();
            }

        }
    }
}
