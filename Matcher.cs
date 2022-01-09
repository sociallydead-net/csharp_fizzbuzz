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
    internal class Matcher
    {
        public delegate void EntryMatchedEventHandler(Matcher sender, int value, Dictionary<int,object> resultSet);
        public event EntryMatchedEventHandler? EntryMatched;

        private readonly int from;
        private readonly int to;
        private readonly Dictionary<Func<int, bool>, object> ruleSet;
        private int current;

        public int From
        {
            get { return from; }
        }
        public int To
        {
            get { return to; }
        }
        public int Current
        {
            get { return current; }
        }

        public Matcher(int from, int to, Dictionary<Func<int, bool>, object> ruleSet)
        {
            this.from = from;
            this.to = to;
            this.ruleSet = ruleSet;
            this.current = from;
        }

        public void Run()
        {
            for (current = from; current <= to; current++)
            {
                Evaluate(current);
            }
        }

        protected void Evaluate(int i)
        {
            Dictionary<int, object> resultSet = new();
            int rule = 0;
            foreach (KeyValuePair<Func<int, bool>, object> entry in ruleSet)
            {
                if (entry.Key?.Invoke(i)==true)
                {
                    resultSet.Add(rule, entry.Value);
                    rule++;
                }
            }
            EntryMatched?.Invoke(this, i, resultSet);
        }
    }
}
