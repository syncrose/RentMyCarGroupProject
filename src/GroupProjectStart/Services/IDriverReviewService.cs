using System.Collections.Generic;
using GroupProjectStart.Models;
using System;

namespace GroupProjectStart.Services
{
    public interface IDriverReviewService
    {
        void AddDriverReview(string Id, DriverReview review, IServiceProvider _db);
        void DeleteReview(int id);
        DriverReview GetReview(int Id);
        List<DriverReview> GetReviews();
        void UpdateReview(DriverReview review);
    }
}