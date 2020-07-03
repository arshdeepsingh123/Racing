namespace Racing.Models
{
    public class Joe : Punter
    {
        // Initialize the Joe class
        public Joe()
        {
            ClassName = "Joe";
            Money = 50;
            Type = CommonClass.Punter_Type.Joe;
        }
        //Reset the money and initialize to original value
        public override void Reset()
        {
            Money = 50;
        }
        //Retrive the money in hand
        public int GetMoney()
        {
            return Money;
        }
    }
}
