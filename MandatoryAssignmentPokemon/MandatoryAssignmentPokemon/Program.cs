using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignmentPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Making moves list
            List<Move> moves = new List<Move>();

            // Making roster list
            List<Pokemon> roster = new List<Pokemon>();

            // INITIALIZE YOUR THREE POKEMONS HERE

            // Initializing pokemons
            Pokemon Charmander = new Pokemon("Charmander", 2, 52, 43, 39, Elements.Fire, new List<Move>() { new Move("Ember"), new Move("Fire Blast")});
            Pokemon Squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, new List<Move>() { new Move("Bubble"), new Move("Bite") });
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, new List<Move>() { new Move("Cut"), new Move("Mega Drain"), new Move("Razor Leaf")});

            // Adding pokemons to roster list
            roster.Add(Charmander);
            roster.Add(Squirtle);
            roster.Add(Bulbasaur);

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        Console.WriteLine("You have to following pokemons in your roster: ");
                        for (int i = 0; i < roster.Count; i++)
                        {
                            Console.WriteLine(roster[i].Name);
                        }
                        break;

                    case "fight":
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = null;
                        Pokemon enemy = null;

                        while (player == null || enemy == null)
                        {
                            //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                            Console.Write("Choose who should fight\nYou can choose the pokemons: {0}, {1} or {2}\n", Charmander.Name, Squirtle.Name, Bulbasaur.Name);

                            //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                            string input = Console.ReadLine();
                            string[] inputs = input.Split(" ");
                            // If less than two pokemon are typed in
                            if (inputs.Length < 2)
                            {
                                Console.WriteLine("You haven't typed in two pokemons!");
                            }
                            // If more than two pokemons are typed in
                            else if (inputs.Length > 2)
                            {
                                Console.WriteLine("Only two pokemons at a time!");
                            }
                            // If the two pokemons typed in are the same
                            else if (inputs[0] == inputs[1])
                            {
                                Console.WriteLine("You can't type in the same pokemon");
                            }
                            else
                            {
                                // Looping through the roster
                                for (int i = 0; i < roster.Count; i++)
                                {
                                    // If the first input matches -> Set as player
                                    if (roster[i].Name.Contains(inputs[0]))
                                    {
                                        player = roster[i];
                                    }
                                    // If the second input matches -> Set as enemy
                                    else if (roster[i].Name.Contains(inputs[1]))
                                    {
                                        enemy = roster[i];
                                    }
                                }

                                if (player == null || enemy == null)
                                {
                                    Console.WriteLine("I didn't understand that... try again");
                                }
                            }
                        }
                        

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.Write("What move should we use? You can choose between the following:\n");
                                for (int i = 0; i<player.Moves.Count; i++)
                                {
                                    Console.WriteLine($"{ i + 1}: {player.Moves[i].Name}");
                                }
                                Console.Write("Write the number of the move you want to use!\n");

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                string MoveInput = Console.ReadLine();
                                int move = -1;
                                move = Convert.ToInt32(MoveInput);
                                while (move > 0 && move < player.Moves.Count +1 )
                                {
                                    Console.WriteLine("You picked the move {0}", player.Moves[move - 1].Name);
                                    //CALCULATE AND APPLY DAMAGE
                                    int damage = -1;

                                    //print the move and damage
                                    Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                    //if the enemy is not dead yet, it attacks
                                    if (enemy.Hp > 0)
                                    {
                                        //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                        Random rand = new Random();
                                        /*the C# random is a bit different than the Unity random
                                         * you can ask for a number between [0,X) (X not included) by writing
                                         * rand.Next(X) 
                                         * where X is a number 
                                         */
                                        int enemyMove = -1;
                                        int enemyDamage = -1;

                                        //print the move and damage
                                        Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                    }
                                }
                                while(move <= 0 || move > player.Moves.Count)
                                {
                                    Console.WriteLine("Your pokemons doesn't have that move!\nPick a move that your pokemon has!");
                                    break;
                                }
                                
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER

                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
