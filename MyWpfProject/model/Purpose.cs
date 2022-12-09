using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MyWpfProject.model
{
    internal class Purpose
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public int FinalAmountMony { get; set; }
        public int CollectedAmountMony { get; set; }
        public Purpose()
        {

        }
        public Purpose(string title, string discription, int amountMony, int collectedAmountMony)
        {
            Title = title;
            Discription = discription;
            FinalAmountMony = amountMony;
            CollectedAmountMony = collectedAmountMony;
        }

        public decimal GetCollectedPercentageOfTheAmountMony() => CollectedAmountMony/FinalAmountMony * 100;
        public decimal GetRemainingAmountMony() => FinalAmountMony - CollectedAmountMony;

    }
}
