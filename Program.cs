/*
 * FizzBuzz
 * Copyright (C) 2022 Andreas Fischer / Sociallydead.net
 * You can reach my under andreas@sociallydead.net by email or
 * visit https://andreas.sociallydead.net for more videos
 * ( well soon, its under construction :) )
 * 
 * The sociallydead.net version of FizzBuzz...
 * A reply to an awesome video by Tom Scott (I am a big fan!)
 * You can see his video and this javascript version here:
 * https://www.youtube.com/watch?v=QPZ0pIK_wsc
 * 
 * Meanwhile leave it to me to complety overengineer a childs game :)
 * My solution seperates the evaluation and the rendering, it also
 * works on a "ruleSet" so you can change the number and text in a 
 * central place, you can also easily at a 3rd or 4th value etc.
 * 
 * Also I HATE else statements because they can become messy really fast,
 * so if you wonder why I dont use else in the render part that is why
 * 
 * I hope you like my solution, and if it helps you at a job interview you
 * can buy me a beer over paypal: afischer@jsyntax.com
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

class FizzBuzz
{
    private int from;
    private int to;
    private Dictionary<int, string> ruleSet;
    private string format;

    public FizzBuzz(int from, int to, Dictionary<int, string> ruleSet)
    {
        this.from = from;
        this.to = to;
        this.ruleSet = ruleSet;

        int length = to.ToString().Length;
        format = "D" + length.ToString();
    }

    public void Run()
    {
        for (int i = from; i <= to; i++)
        {
            Dictionary<int, string> resultSet = Evaluate(i);
            Render(i, resultSet);
        }
    }

    protected Dictionary<int, string> Evaluate(int value)
    {
        Dictionary<int, string> resultSet = new Dictionary<int, string>();
        foreach (KeyValuePair<int, string> entry in ruleSet)
        {
            if (value % entry.Key == 0)
            {
                resultSet.Add(entry.Key, entry.Value);
            }
        }
        return resultSet;
    }

    protected void Render(int value, Dictionary<int, string> resultSet)
    {
        ConsoleColor consoleColor = Console.ForegroundColor;

        int results = resultSet.Count;

        if (results == 0)
            Console.ForegroundColor = ConsoleColor.White;
        if (results != 0)
            Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write(value.ToString(format));
        Console.Write(": ");


        if (results >= 2)
            Console.ForegroundColor = ConsoleColor.Red;
        if (results == 1)
            Console.ForegroundColor = ConsoleColor.Green;

        foreach (KeyValuePair<int, string> result in resultSet)
        {
            Console.Write(result.Value);
        }

        Console.Write(Environment.NewLine);

        Console.ForegroundColor = consoleColor;
    }

    public static void Main()
    {
        Dictionary<int, string> ruleSet = new Dictionary<int, string>();
        ruleSet.Add(3, "Fizz");
        ruleSet.Add(5, "Buzz");

        FizzBuzz fizzBuzz = new FizzBuzz(1, 100, ruleSet);
        fizzBuzz.Run();
    }
}
