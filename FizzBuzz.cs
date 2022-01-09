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

namespace FizzBuzz
{
    class FizzBuzz
    {
        public static void Main()
        {
            Dictionary<Func<int, bool>, object> ruleSet = new();
            ruleSet.Add((value) => value % 3 == 0, "Fizz");
            ruleSet.Add((value) => value % 5 == 0, "Buzz");

            Matcher matcher = new(1, 100, ruleSet);
            string format = "D" + matcher.To.ToString().Length;

            matcher.EntryMatched += (sender, value, resultSet) =>
            {
                Console.Write(value.ToString(format));
                Console.Write(": ");

                foreach (KeyValuePair<int, object> result in resultSet)
                {
                    Console.Write(result.Value);
                }

                Console.Write(Environment.NewLine);
            };

            matcher.Run();
        }
    }
}