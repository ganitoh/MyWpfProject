using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MyWpfProject.model
{
    public class Purpose
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int FinalAmountMony { get; set; }
        public int CollectedAmountMony { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool IsMainPurposes { get; set; }
        public Purpose()
        {

        }
        public Purpose(int userId,string title, string discription, int amountMony, int collectedAmountMony)
        {
            UserId = userId;
            Title = title;
            Discription = discription;
            FinalAmountMony = amountMony;
            CollectedAmountMony = collectedAmountMony;
        }

        public decimal GetCollectedPercentageOfTheAmountMony() => CollectedAmountMony/FinalAmountMony * 100;
        public decimal GetRemainingAmountMony() => FinalAmountMony - CollectedAmountMony;

    }
}
