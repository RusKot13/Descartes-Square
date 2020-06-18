using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Descartes_Square
{
    [Serializable]
   public class User
    {       
        public string[] PlusIfIDoList { get; set; } 
        public string[] PlusIfIDontDoItList { get; set; } 
        public string[] ConsIfIDoList { get; set; } 
        public string[] ConsIfIDontDoItDoList { get; set; } 

        public User() { }
        public User (string[] PlusIfIDoList, string[] PlusIfIDontDoItList, string[] ConsIfIDoList, string[] ConsIfIDontDoItDoList)
        {
            this.PlusIfIDoList = PlusIfIDoList;
            this.PlusIfIDontDoItList = PlusIfIDontDoItList;
            this.ConsIfIDoList = ConsIfIDoList;
            this.ConsIfIDontDoItDoList = ConsIfIDontDoItDoList;
        }
    }
}
