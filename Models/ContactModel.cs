using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/*
* Course: 		Web Programming 3
* Assessment: 	Assignment XYZ
* Created by: 	Sarim Syed
* Date: 		9 Nov 2022
* Class Name: 	Contact.cs
* Description: Has the fields for the form input
       */
namespace Web3_Assignment3_ContactUs.Models
{
    public class ContactModel
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "Last Name can not be longer than 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "First Name cannot contain numbers")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage ="Last Name can not be longer than 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last Name cannot contain numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@".*@.*\.\w{2,}", ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        public string Topic { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [MaxLength(7, ErrorMessage = "Please enter valid postal code")]
        [RegularExpression(@"^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$", ErrorMessage = "Invalid postal code")]
       // [RegularExpression(@"^[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY]\d[abceghjklmnprstvxyABCEGHJKLMNPRSTVWXYZ][ -]?\d[abceghjklmnprstvxyABCEGHJKLMNPRSTVWXYZ]\d$", ErrorMessage = "Invalid postal code")]



        public string PostalCode { get; set; }

        //Code below breaks the input field so it will be done 

        //private string postalCode;
        //Regex will get rid of the space if the user has a space and it will allow the db to store the postal code properly
        //public string PostalCode
        //{
        //    get
        //    {
        //       return postalCode;
        //    }
        //    set
        //    {
        //        string temp = value;
        //        temp = Regex.Replace(temp, @"\s", "");
        //        postalCode = temp;

        //    }

        
        //}

        [Required]
        [MaxLength(300)]
        public string Message { get; set; }

    }
}
