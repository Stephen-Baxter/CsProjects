namespace RPG_Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            RPG_Dice RPG_Dice = new RPG_Dice();

            do
            {
                RPG_Dice.ResetConsole();
                RPG_Dice.OutputRollBuffer();
                RPG_Dice.Instructions();
                RPG_Dice.GetUserInput();
            }
            while (RPG_Dice.DiceRoll());

           RPG_Dice = null;
        }
    }
}
