using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Helpers
{
    public static class RandomHelper
    {
        public static string GenerateRandomPassword(int theLength) {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[theLength];
            Random rd = new Random();
            for (int i = 0; i < theLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
    }
}
