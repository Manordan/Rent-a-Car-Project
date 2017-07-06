using System;
using System.ComponentModel.DataAnnotations;

namespace CarSite.ValdatianHelper
{
    public class ValdatianTz : ValidationAttribute
    {
       
    
        public ValdatianTz()
        {
            ErrorMessage = "incorect id number try again";
        }

        public override bool IsValid(object value)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;
            if (value == null)
                return false;

            value = value.ToString().PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(value.ToString().Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }
    }
}
