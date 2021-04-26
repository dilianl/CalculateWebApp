using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CalculateWebApp.Models
{
    public class TowIntNumbersModel
    {
        #region Messages
        readonly string NoValidationMesage = "Input data is not valid. Please Enter numbers in [" + Int64.MinValue.ToString() + "," + Int64.MaxValue.ToString() + "].";
        readonly string NoCombinationMessage = "No combination with these data.";
        #endregion

        [Required(ErrorMessage = "Please enter frist number.")]
        [Range(Int64.MinValue, Int64.MaxValue)]
        public Int64 FirstNumber { get; set; }

        [Required(ErrorMessage = "Please enter second number.")]
        [Range(Int64.MinValue, Int64.MaxValue)]
        public Int64 SecondNumber { get; set; }

        public string GetNoValidationMesage
        {
            get { return NoValidationMesage; }

        }
        public string GetNoCombinationMessage
        {
            get { return NoCombinationMessage; }
        }
        public string Display(string sum)
        {
            string secondNumber = (SecondNumber > 0) ? "+" + SecondNumber.ToString(): SecondNumber.ToString();
            string result = FirstNumber.ToString() + secondNumber + "=" + sum; 

            return result;
        }

        
            
    }
}
