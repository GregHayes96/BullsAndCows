
BullsAndCows game = new BullsAndCows (3456);


class BullsAndCows
{
    int value;      //field  -  Data Member 
    int guess;

    public BullsAndCows(int num)        //constructor
    {
        value = num;
    }

    public int GetVal()         //method  -  Function Member
    {
        return value;
    }

    public void SetVal(int num)
    {
        value = num;
    }

    public void NewGuess(int num)
    {
        guess = num;
    }
}