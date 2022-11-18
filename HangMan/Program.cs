using System;

bool inputCorrect = true;
string playerChar = " ";
char guessChar = ' ';
int num;

Console.WriteLine("Hello, please enter a word");
string input = Console.ReadLine();
char[] chars = input.ToCharArray();
char[] mysteryWord = input.ToCharArray();
int tryCount = 0;

for (int i = 0; i < chars.Length; i++)
{
    chars[i] = '*';
}

do
{
    PlayGround(chars, tryCount);

    if (chars.SequenceEqual(mysteryWord))
    {
        Console.WriteLine("\nWell done! Mystery word is: " + input);
        break;
    }

    if (tryCount == 4)
    {
        Console.WriteLine("\nYou lose! Mystery word is: " + input);
        break;
    }

    do
    {
        Console.WriteLine("\nPlease pick a letter: ");
        playerChar = Console.ReadLine();

        if ((playerChar.Length == 1) && (playerChar.Length != 0))
        {
            if (!int.TryParse(playerChar, out num))
            {
                guessChar = char.Parse(playerChar);

                if (!input.Contains(guessChar))
                {
                    inputCorrect = true;
                    tryCount++;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (guessChar == input[i])
                    {
                        chars[i] = guessChar;
                        inputCorrect = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("You picked a number. Please enter a letter");
                inputCorrect = false;
            }
        }
        else
        {
            Console.WriteLine("Please pick only one letter");
            inputCorrect = false;
        }

    } while (!inputCorrect);

} while (true);

static void PlayGround(char[] chars, int counter)
{   
    char head = ' ';
    char body = ' ';
    char armLegLeft = ' ';
    char armLegRight = ' ';

    if (counter == 1)
        head = 'O';
    else if (counter == 2)
    {
        head = 'O'; body = '|';
    }
    else if (counter == 3)
    {
        head = 'O'; body = '|'; armLegRight = '/';
    }
    else if (counter == 4)
    {
        head = 'O'; body = '|'; armLegLeft = '\\'; armLegRight = '/';
    }

    Console.Clear();
    Console.WriteLine("    /=====\\  ");
    Console.WriteLine("   //      |  ");                                 
    Console.WriteLine("   ||      {0}  ", head);
    Console.WriteLine("   ||     {0}{1}{2} ", armLegRight, body, armLegLeft);
    Console.WriteLine("   ||      {0}  ", body);      
    Console.WriteLine("   ||     {0} {1}", armLegRight, armLegLeft);
    Console.WriteLine("___||_________   ");
    Console.WriteLine(" ");
        
    foreach (char i in chars)
    {
        Console.Write(i);
    }
}
