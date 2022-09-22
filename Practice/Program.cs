
BullsAndCows game1 = new BullsAndCows ();  
BullsAndCows game2 = new BullsAndCows();

game1.NewGuess(1234);
game1.NewGuess(5678); 
game1.NewGuess(9012);
game1.NewGuess(8632);


Console.WriteLine(BullsAndCows.GameTot);

class BullsAndCows
{      //field  -  Data Member 
    public static int GameTot;
    readonly int[] ValArr = new int[4];
    readonly int[] GuessArr = new int[4];
    int[] BaC = new int[2] { 0, 0 };     //first value represents bulls, second cows 

    public BullsAndCows()        //constructor
    {
        ResetGame();
        GameTot += 1;
    }

    public void SetVal(int num)     //method  -  Function Member
    {
       
        SetValArr();
    }

    public void NewGuess(int num)
    {
        SetGuessArr(num);
        if(Compare() == true) //game won
        {
            Console.WriteLine("Congratulations, game won!");
            ResetGame();
        }
        else
        {
            Console.WriteLine($"Wrong guess - Bulls:{BaC[0]}    Cows:{BaC[1]}");
        }
    }

    //issue, i require an elegant way of checking the index position of a bull an eliminating that from the list of numbers to be checked for cows  -   line 42
    public bool Compare()
    {
        bool[] index = {false,false,false,false};   //if a bull exists in the index position, bool changes to true
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
        //reset the bulls and cows score
        BaC[0] = 0;
        BaC[1] = 0;

        Random r1 = new Random();   //randomise the 4 digit number
        ValArr[0] = r1.Next(10);    //first number doesnt need a check if it is a repeat
        
        for (int i = 1; i < 4; i++)     //this is going to check the new random number against the previous two, creates a new random if its a repeat
        {
            bool pass = false;
            while(pass == false)
            {
                int temp = r1.Next(10);
                if (NotRepeat(temp,i)) 
                { 
                    ValArr[i] = temp;
                    pass = true;
                }
                
            }   
        }
    }

    public bool NotRepeat(int n,int l)
    {
        for(int i = 0; i < l; i++)
        {
            if (ValArr[i] == n) { return false; }   //the number is already in ValArr
        }
        return true;
    }

    //i think this is a function that can be cut. would be simpler to just change the way the guess is stored instead
    public void SetValArr()
    {
        string temp = "";
        for(int i = 0; i < 4; i++) { temp += ValArr[i].ToString(); }
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