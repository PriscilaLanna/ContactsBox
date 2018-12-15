using System;

namespace ContactsBox.Infra.CrossCuttting.Extensions
{
    public static class Formats
    {
        public static string FormatTelephone(this string number)
        {
            return number.ToString().Length > 10 ? String.Format("{0:(##) #####-####}", number)
                : String.Format("{0:(##) ####-####}", number);
            //Regex.Replace("11999998888", @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
        }          
    }
}
