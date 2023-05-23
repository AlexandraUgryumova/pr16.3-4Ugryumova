using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Угрюмова_практика_16
{
    class SubjectIndex
    {
        public string word { get; set; }
        public int[] page { get; set; }
        public SubjectIndex(string word, int[] page)
        {
            this.word = word;
            this.page = page;
        }
        public string Info()
        {
            string page2="";
            for(int i = 0; i < page.Length; i++)
            {
                page2 += " " + page[i].ToString();
            }
            return word  + page2;
        }
    }
}
