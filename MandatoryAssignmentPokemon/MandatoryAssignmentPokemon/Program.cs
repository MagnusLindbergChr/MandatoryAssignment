﻿using System;
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
            List<Move> CharmanderMoves = new List<Move>()
            {
                new Move("Ember"),
                new Move("Fire Blast")
            };
            List<Move> SquirtleMoves = new List<Move>()
            {
                new Move("Bubble"),
                new Move("Bite")
            };
            List<Move> BulbasaurMoves = new List<Move>()
            {
                new Move("Cut"),
                new Move("Mega Drain"),
                new Move("Razor Leaf")
            };

            List<Pokemon> roster = new List<Pokemon>();

            // INITIALIZE YOUR THREE POKEMONS HERE

            // Initializing pokemons
            Pokemon Charmander = new Pokemon("Charmander", 2, 52, 43, 39, Elements.Fire, CharmanderMoves);
            Pokemon Squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, SquirtleMoves);
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, BulbasaurMoves);

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
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight\nstart by choosing the player\nYou kan choose the pokemons: {0}, {1} or {2}\n", Charmander.Name, Squirtle.Name, Bulbasaur.Name);

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        Console.WriteLine("You chose the pokemon " + input + " as the player");
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = null;
                        Pokemon enemy = null;

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.Write("What move should we use? (");

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int move = -1;

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
