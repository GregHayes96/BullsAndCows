
BullsAndCows game1 = new BullsAndCows (3456);  
BullsAndCows game2 = new BullsAndCows(2367);

game1.NewGuess(1357);
game1.NewGuess(3459);
game1.NewGuess(3456);

Console.WriteLine(BullsAndCows.GameTot);

class BullsAndCows
{
    int Value;      //field  -  Data Member 
    public static int GameTot;
    readonly int[] ValArr = new int[4];
    readonly int[] GuessArr = new int[4];
    int[] BaC = new int[2] { 0, 0 };     //first value represents bulls, second cows 

    public BullsAndCows(int num)        //constructor
    {
        Value = num;
        SetValArr(num);
        GameTot += 1;
    }

    public void SetVal(int num)     //method  -  Function Member
    {
        Value = num;
        SetValArr(num);
    }

    public void NewGuess(int num)
    {
        SetGuessArr(num);
        if(Compare() == true) //game won
        {
            Console.WriteLine("Congratulations, game won!");
        }
        else
        {
            Console.WriteLine($"Wrong guess - Bulls:{BaC[0]}    Cows:{BaC[1]}");
        }
        ResetGame();
    }

    //issue, i require an elegant way of checking the index position of a bull an eliminating that from the list of numbers to be checked for cows  -   line 42
    public bool Compare()
    {
        bool[] index = new bool[4] {false,false,false,false};   //if a bull exists in the index position, bool changes to true
        //check for bulls, 4 bulls will return true, which is a win
        for(int i = 0; i < 4; i++)
        {
            if (GuessArr[i] == ValArr[i]) 
            {
                index[i] = true;
                BaC[0]++; 
            }
            if (BaC[0] == 4) return true;
        }

        for (int i = 0; i < 4; i++)
        {
            if (index[i] == true) ;   //do nothing
            else
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (index[j] == true) ;     //skip
                    else if (GuessArr[i] == ValArr[j]) BaC[1]++;    //matching number, wrong position, add a cow  
                }

            }
        }
            return false;
    }

    public void ResetGame()
    {
        BaC[0] = 0;
        BaC[1] = 0;
    }

    public void SetValArr(int num)
    {
        string temp = num.ToString();
        for (int i = 0; i < temp.Length; i++)
        {
            ValArr[i] = temp[i];
        }
    }

    public void SetGuessArr(int num)
    {
        string temp = num.ToString();
        for (int i = 0; i < temp.Length; i++)
        {
            GuessArr[i] = temp[i];
        }
    }
}