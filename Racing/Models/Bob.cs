namespace Racing.Models
{
    public class Bob : Punter
    {
        //Initialize the Bob class paramater
        public Bob()
        {
            ClassName = "Bob";
            Money = 50;
            Type = CommonClass.Punter_Type.Bob;
        }
        //Reset the money to initial value
        public override void Reset()
        {
            Money = 50;
        }
        //Retrieve money in hand
        public int GetMoney()
        {
            return Money;
        }
    }
}
