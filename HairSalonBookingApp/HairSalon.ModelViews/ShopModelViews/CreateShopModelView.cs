﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.ShopModelViews
{
    public class CreateShopModelView
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string ShopEmail { get; set; } 

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string ShopPhone { get; set; } 

        [Required(ErrorMessage = "Open Time is required.")]
        public TimeSpan OpenTime { get; set; } 

        [Required(ErrorMessage = "Close Time is required.")]
        public TimeSpan CloseTime { get; set; } 

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        public int TotalServices { get; set; } 


        //public string? CreatedBy { get; set; }

        //[Required(ErrorMessage = "CreatedTime is required.")]
        //public DateTimeOffset CreatedTime { get; set; }

        //[Required(ErrorMessage = "Title is required.")]
        //public DateTimeOffset LastUpdatedTime { get; set; }
    }
}
