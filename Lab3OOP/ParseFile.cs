using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System;

namespace Lab3OOP
{
    public class ParseFile
    {
        public Match myId = null;
        public string name = string.Empty;
        public string val = string.Empty;
        
        public List<Tuple<Match, string, string>> t = new List<Tuple<Match, string, string>>();
        
        public void getAnalysis(string line)
        {
            showMatch1(line, @"\[.*\]");
            //showMatch2(line, @".*\;");
            match(line);
        }

        public void showMatch1(string text, string expr) {
            MatchCollection mc = Regex.Matches(text, expr);
            
            foreach (Match m in mc)
            {
                myId = m;
                //]Console.WriteLine(m);
            }
        }

        public void match(string line)
        {
            //Console.WriteLine(line);
            int check = 0;
            int index = -1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ';')
                    return;
                
                if (line[i] == '=')
                {
                    String substring = line.Substring(0, i - 1);
                    name = substring;
                    index = i + 1;
                    break;
                }
            }
            
            if (index != -1)
            {
                index++;
                for (int i = index; i < line.Length; i++)
                {
                    if (line[i] == ';' || i == line.Length - 1 || line[i] == ' ')
                    {
                        String substring = line.Substring(index, i - index + 1);
                        //Console.WriteLine(substring);
                        val = substring;
                        check = 1;
                        t.Add(Tuple.Create(myId, name, val));
                        break;
                    }
                }
            }
            
            if (check == 0 && line[0] != ';' && line != myId.ToString()) 
            {
                throw new IniWrongFormat();
            }
            
        }
        public void getList()
        {
            for(int i = 0; i < t.Count; i++)
                Console.WriteLine(t[i].Item1 +  " " + t[i].Item2 + " " + t[i].Item3);
        }
        

        public void searchListInt(string m, string s, string par)
        {
            string getval = null;
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i].Item1.ToString() == m && t[i].Item2 == s)
                {
                    getval = t[i].Item3;
                }
            }

            if (getval == null)
            {
                throw new IniSectionNotExists();
            }

            getRes(getval, par);
        }

        public void getRes(string val, string par)
        {
            if (par == "int")
            {
                int res = -1;
                bool success = Int32.TryParse(val, NumberStyles.Number, new CultureInfo("en-US"), out res);
                if (success == false)
                {
                    throw new IniConvertNotExists();
                }
                Console.WriteLine("Converted '{0}' to {1}.", val, res);
                /*
                if (success)
                {
                    Console.WriteLine("Converted '{0}' to {1}.", val, res);         
                }
                else
                {
                    Console.WriteLine("Attempted conversion of '{0}' failed.", 
                        val ?? "<null>");
                }
                */
            }
                    
            else if (par == "double")
            {
                double res;
                bool success = Double.TryParse(val, NumberStyles.Number, new CultureInfo("en-US"), out res);
                if (success == false)
                {
                    throw new IniConvertNotExists();
                }
                Console.WriteLine("Converted '{0}' to {1}.", val, res);
            }
                    
            else if (par == "string")
            {
                Console.WriteLine("Converted to string " + val);
            }
        }
        
    }
}