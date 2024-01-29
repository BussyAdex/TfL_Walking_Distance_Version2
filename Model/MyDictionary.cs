using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfL_Walking_Distance_Version2.Model
{
     class MyDictionary
    {
        public int DictKey { get; set; }
        public string DictValue { get; set; }

        public MyDictionary(int key, string value)
        {
            DictKey = key;
            DictValue = value;
        }
        public MyDictionary()
        {
            DictKey = 0;
            DictValue = "";
        }
    }
}
