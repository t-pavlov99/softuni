﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                name = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid input!");
                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                gender = value;
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}\n{ProduceSound()}";
        }
    }
}
