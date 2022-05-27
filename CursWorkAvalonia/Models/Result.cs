using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CursWorkAvalonia.Models
{
    public class Result
    {
        public List<Nhlscore> result { get; set; }
        public Result()
        {
            result = new List<Nhlscore>();
        }
        public void Add(string e)
        {
            
        }
    }
}
