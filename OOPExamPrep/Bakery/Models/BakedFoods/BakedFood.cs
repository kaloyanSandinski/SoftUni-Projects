﻿using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Bakery.Utilities.Messages.ExceptionMessages.InvalidName);
                }

                name = value;
            }
        }

        public int Portion
        {
            get
            {
                return portion;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                portion = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Portion}g - {Price:f2}";
        }
    }
}
