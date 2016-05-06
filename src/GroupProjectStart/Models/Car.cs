﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        [Range(1900, 2018, ErrorMessage = "Year is required or out of bounds")]
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Door { get; set; }
        public string UserId { get; set; }
        //public ApplicationUser Loaner { get; set; } <----Jason------Don't do this stupid!--------from Jason
        public bool IsActive { get; set; }
        public string Condition { get; set; }
        public int Seats { get; set; }
        public int Miles { get; set; }
        public int HwyMpg { get; set; }
        public int CtyMpg { get; set; }
        public DateTime DateAdded { get; set; }
        public string Transmission { get; set; }
        public string Description { get; set; }
        public ICollection<RatingCar> CarRatings { get; set; }
        public decimal AverageRating { get; set; }
        public ICollection<CarReview> Reviews { get; set; }


    }
}
//id, make, model, year, price, image, doors