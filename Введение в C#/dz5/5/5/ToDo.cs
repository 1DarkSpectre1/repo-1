using System;
using System.Collections.Generic;
using System.Text;

namespace _5
{
    class ToDo
    {
        
  

        public string Title { get; set; }
        
        public bool IsDone { get; set; }
        public ToDo()
        {
            IsDone = false;
        }
        public void CreateTask(string str)
        {
            
            Title = str;
         
            
        }
    }
}
