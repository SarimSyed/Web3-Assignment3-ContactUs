using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
* Course: 		Web Programming 3
* Assessment: 	Assignment XYZ
* Created by: 	Sarim Syed
* Date: 		9 Nov 2022
* Class Name: 	ReCATCHASettings.cs
* Description: Stores the recaptcha key and secret in this class.
       */
namespace Web3_Assignment3_ContactUs.Services
{
    public class ReCAPTCHASettings
    {
        public string ReCAPTCHA_Site_Key { get; set; }
        public string ReCAPTCHA_Secret_Key { get; set; }
    }
}
