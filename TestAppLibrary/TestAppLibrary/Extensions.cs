using System.Collections.Generic;
using System.Linq;

namespace TestAppLibrary
{
    public static class StringExtension
    {
        public static bool CheckString(this string text)
        {
            bool result = true;

            //словарь проверяемых символов
            Dictionary<char, int[]> keys = new Dictionary<char, int[]>
            {
                ['('] = new int[] { 1, 1 },
                [')'] = new int[] { 1, 0 },
                ['{'] = new int[] { 2, 1 },
                ['}'] = new int[] { 2, 0 },
                ['['] = new int[] { 3, 1 },
                [']'] = new int[] { 3, 0 }
            };

            //строка со скобками
            string braces = "";

            //убираем все кроме скобок
            foreach (var c in text)
            {
                foreach (var key in keys)
                {
                    if (c == key.Key)
                    {
                        braces += c;
                    }
                }
            }

            //проверяем скобки на валидность
            for (int i = 0; i < braces.Length; i++)
            {
                foreach (var key in keys)
                {
                    //проверка является ли скобка закрывающей
                    if (braces[i] == key.Key && key.Value[1] == 0)
                    {
                        //проверка является ли закрывающая скобка такого же семейства как предыдущая
                        if (keys.Where(k => k.Key == braces[i - 1]).FirstOrDefault().Value[0] == key.Value[0])
                        {
                            braces = braces.Remove(i - 1, 2);
                            i = 0;
                            break;
                        }
                        else return false;
                    }
                }
            }

            if (braces != "") return false;
            return result;
        }
    }
}
