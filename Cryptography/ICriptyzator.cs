using System;
using System.Collections.Generic;
using System.Text;

namespace Criptology
{
    public interface ICriptyzator
    {
        string Ecrypt(string text, object key);
        string Dcrypt(string text, object key);
        string Replace(string text, string str1, string str2);
    }
}
