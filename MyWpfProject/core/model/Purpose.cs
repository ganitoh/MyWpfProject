namespace MyWpfProject.core.model
{
    public class Purpose
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int FinalAmountMoney { get; set; }
        public int CollectedAmountMoney { get; set; }
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
            FinalAmountMoney = amountMony;
            CollectedAmountMoney = collectedAmountMony;

        }

        public decimal GetCollectedPercentageOfTheAmountMony() => CollectedAmountMoney/FinalAmountMoney * 100;
        public decimal GetRemainingAmountMony() => FinalAmountMoney - CollectedAmountMoney;

    }
}
