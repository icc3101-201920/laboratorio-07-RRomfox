using Laboratorio_6_OOP_201902.Cards;
using Laboratorio_6_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_6_OOP_201902.Static
{
    public static class Visualization
    {
        public static void ShowHand(Hand hand)
        {
            CombatCard combatCard;
            Console.WriteLine("Hand: ");
            for (int i = 0; i<hand.Cards.Count; i++)
            {
                if (hand.Cards[i] is CombatCard)
                {
                    combatCard = hand.Cards[i] as CombatCard;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"|({i}) {combatCard.Name} ({combatCard.Type}): {combatCard.AttackPoints} |");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"|({i}) {hand.Cards[i].Name} ({hand.Cards[i].Type}) |");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        public static void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select one Deck:");
            for (int i = 0; i<decks.Count; i++)
            {
                Console.WriteLine($"({i}) Deck {i+1}");
            }
        }
        public static void ShowCaptains(List<SpecialCard> captains)
        {
            Console.WriteLine("Select one captain:");
            for (int i = 0; i < captains.Count; i++)
            {
                Console.WriteLine($"({i}) {captains[i].Name}: {captains[i].Effect}");
            }
        }
        public static int GetUserInput(int maxInput, bool stopper = false)
        {
            bool valid = false;
            int value;
            int minInput = stopper ? -1 : 0;
            while (!valid)
            {

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minInput && value <= maxInput)
                    {
                        return value;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The option ({value}) is not valid, try again");
                        Console.ResetColor();
                    }
                }
                else
                {
                    ConsoleError($"Input must be a number, try again");
                }
            }
            return -1;
        }
        public static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowListOptions (List<string> options, string message = null)
        {
            if (message != null) Console.WriteLine($"{message}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"({i}) {options[i]}");
            }
        }
        public static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }

        public static void ShowBoard(Board board, int player, int[] lifePoints, int[] attackPoints)
        {

            int[] totalAttackLR = board.GetAttackPoints(EnumType.longRange);
            int[] totalAttackR = board.GetAttackPoints(EnumType.range);
            int[] totalAttackM = board.GetAttackPoints(EnumType.melee);


            Console.WriteLine("Board: \n");
            Console.WriteLine($"Opponent - LifePoints: {lifePoints[Math.Abs(player - 1)]} - AttackPoints: { attackPoints[Math.Abs(player - 1)]}");

            Console.Write($"(longRange) [{totalAttackLR[Math.Abs(player - 1)]}]: ");
            if (board.PlayerCards[Math.Abs(player - 1)].ContainsKey(EnumType.longRange))
            {
                foreach (CombatCard card in board.PlayerCards[Math.Abs(player - 1)][EnumType.longRange])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }

            Console.Write($"\n(range) [{totalAttackR[Math.Abs(player - 1)]}]: ");
            if (board.PlayerCards[Math.Abs(player - 1)].ContainsKey(EnumType.range))
            {
                foreach (CombatCard card in board.PlayerCards[Math.Abs(player - 1)][EnumType.range])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }

            Console.Write($"\n(melee) [{totalAttackM[Math.Abs(player - 1)]}]: ");
            if (board.PlayerCards[Math.Abs(player - 1)].ContainsKey(EnumType.melee))
            {
                foreach (CombatCard card in board.PlayerCards[Math.Abs(player - 1)][EnumType.melee])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }
            Console.WriteLine("");

            Console.Write("\nWeather Cards: ");
            if (board.WeatherCards.Count > 0)
            {
                foreach (SpecialCard card in board.WeatherCards)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"|{card.Name}|");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("");

            Console.WriteLine($"\nYou - LifePoints: {lifePoints[player]} - AttackPoints: {attackPoints[player]}");

            Console.Write($"(longRange) [{totalAttackLR[player]}]: ");
            if (board.PlayerCards[player].ContainsKey(EnumType.longRange))
            {
                foreach (CombatCard card in board.PlayerCards[player][EnumType.longRange])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }
            
            Console.Write($"\n(range) [{totalAttackR[player]}]: ");
            if (board.PlayerCards[player].ContainsKey(EnumType.range))
            {
                foreach (CombatCard card in board.PlayerCards[player][EnumType.range])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }
            
            Console.Write($"\n(melee) [{totalAttackM[player]}]: ");
            if (board.PlayerCards[player].ContainsKey(EnumType.melee))
            {
                foreach (CombatCard card in board.PlayerCards[player][EnumType.melee])
                {
                    Console.Write($"|{card.AttackPoints}|");
                }
            }
            Console.WriteLine("");
        }

    }
    
}
