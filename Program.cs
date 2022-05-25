using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberCorrect = 0;
            
            Console.WriteLine("What is your name, adventurer?");
            string userName = Console.ReadLine();
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge forsbergAge = new Challenge("How old is Peter Forsberg?", 48, 30);
            Challenge leeAge = new Challenge("How old is Lee Jenning?", 31, 25);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe myRobe = new Robe()
            {
                Colors = new List<string> {"Red", "Blue", "Yellow"},
                Length = 61
            };
            Hat myHat = new Hat()
            {
                ShininessLevel = 5
            };
            Prize myPrize = new Prize("The prize is one million dollars!");

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, myRobe, myHat, NumberCorrect);

            
            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                forsbergAge,
                leeAge
            };

            // Loop through all the challenges and subject the Adventurer to them
            void startChallenges()
            {
                Console.WriteLine(theAdventurer.GetDescription());
                List<Challenge> fiveChallenges = new List<Challenge>();

                int count = 0;
                while(count < 5)
                {
                    int ranNum = new Random().Next(0, 5);
                    if(!fiveChallenges.Contains(challenges[ranNum]))
                    {
                        fiveChallenges.Add(challenges[ranNum]);
                        count++;
                    }
                }
                
                foreach (Challenge challenge in fiveChallenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }
            }
            startChallenges();

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            bool playAgain = true;
            while(playAgain)
            {
                myPrize.ShowPrize(theAdventurer);
                Console.Write("Would you like to play again? (Y/N)");
                string playAgainAnswer = Console.ReadLine().ToLower();
                if(playAgainAnswer == "y")
                {
                    theAdventurer.Awesomeness += theAdventurer.NumberCorrect * 10;
                    startChallenges();
                }
                else {
                    Console.WriteLine("I guess you've had enough of my challenges. See ya!");
                    playAgain = false;
                }
            }

        }
    }
}