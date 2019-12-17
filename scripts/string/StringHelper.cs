using System.Collections.Generic;

namespace Codebycandle.Util.String
{
    public static class StringHelper
    {
        public static string[] GetWords(string value)
        {
            return value.Split(" ".ToCharArray());
        }

        public static string RemoveWhiteSpace(string value)
        {
            return value.Replace(" ", string.Empty);
        }

        public static string RemovveChar(string value, char c)
        {
            return value.Replace(c.ToString(), string.Empty);
        }

        public static List<int> AllIndexesOf(string str, char c)
        {
            // if(String.IsNullOrEmpty(c.ToString()))
            //     throw new ArgumentException("The stirng to find may not be empty", "value");
            
            int startIndex = 0;
            int result = -1;
            List<int> indices = new List<int>();
            for(int i = 0; i < str.Length; i++)
            {
                result = str.IndexOf(c, startIndex);
                if(result == -1)
                {
                    break;
                }
                else
                {
                    indices.Add(result);

                    startIndex = result + 1;

                    // end loop IF posIndex = last string char
                    if(result == (str.Length - 1))
                        break;
                }
            }

            return (indices.Count > 0) ? indices : null;
        }
    }
}