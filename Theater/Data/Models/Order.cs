using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theater.Data.Models;

namespace Theater.Data.Models
{
    public class Order
    {
        public double price { get; set; }
		[Display(Name = "Введите Скидку")]
		public int discount { get; set; }
		[BindNever]
        public int id { get; set; }
		public int code { get; set; }
        public int userId { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина имени не более 30 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string surname { get; set; }

        [Phone]
        [Display(Name = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите почту")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<ShopCartItem> tickets { get; set; }

        
    }
}


