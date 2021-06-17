using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TOA_project
{
    public partial class Form1 : Form
    {

        int i = 0;
        private static String input = "";
        MatchCollection stringarr;
        private static String[] tokens;
        private static String[] separators = { ";", "{", "}", ">", "<", "+", "-", "|", "&", "`" };
        private static String[] operators = { "()", "[]", "&&", "||", "++", "--", "==", "=<", "=>", "!=", "*", "/", "%", "(", ")", "[", "]", ",", "=" };

        Regex integer = new Regex("^[+|-]?[0-9]+$");
        Regex decimals = new Regex("^[+|-]?[0-9]*[.][0-9]+$");
        Regex strings = new Regex("[\"].*[\"]");
        Regex characters = new Regex("^[\'].?[\']$");                          
        Regex identifier = new Regex("^[a-zA-Z][0-9|a-zA-Z|_]*");
        Regex comments = new Regex("[/*].*[*/]");
        //Regex identifier = new Regex(@"[a-zA-Z]\w*");
        Regex seperatorss = new Regex("[;]|[{]|[}]|[|]|[&]|[`]");
        Regex operatorss = new Regex("^[()]|[[][]]|[&&]|[,]|[||]|[,]|[+]{2}|[-]{2}|[=]{2}|[<]|[=>]|[!=]|[=]|[*]|[/]|[%]|[(]|[)]|[[]|[]]|[,]|[=]|[+]|[-]|[>]|[<]$");

        Regex keywords = new Regex("abstract|as|base|bool|break|by|byte|case|catch|char|checked|" +
            "class|const|continue|decimal|default|delegate|do|double|descending|explicit|event|" +
            "extern|else|enum|false|finally|fixed|float|for|foreach|from|goto|group|if|implicit|" +
            "int|interface|internal|into|is|lock|long|new|null|namespace|object|operator|out|" +
            "override|orderby|params|private|protected|public|readonly|ref|return|switch|struct|" +
            "sbyte|sealed|short|sizeof|stackalloc|static|string|select|this|throw|true|try|" +
            "typeof|uint|ulong|unchecked|unsafe|ushort|using|var|virtual|volatile|void|while|where|yield"); 
        public Form1()
        {

            InitializeComponent();
        }

        private void browse_Btn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    input = System.IO.File.ReadAllText(file);

                    richTextBox1.Text = System.IO.File.ReadAllText(file);
                }
                catch (System.IO.IOException) { }
            }
        }

        private void analyze_Btn_Click(object sender, EventArgs e)
        {
            codePrep();
            
        }

        void codePrep()
        {
            richTextBox1.Text = "";

            stringarr = strings.Matches(input);
            input = Regex.Replace(input, "[\"].*[\"]", "__");
            input = Regex.Replace(input, @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", "");
            //input = Regex.Replace(input, @"[/*](.|[\n])*[*/]", "");

            for (int i = 0; i < operators.Length; i++)
                input = input.Replace(operators[i], " " + operators[i] + " ");

            for (int i = 0; i < separators.Length; i++)
                input = input.Replace(separators[i], " " + separators[i] + " ");

            input = input.Replace("+  +", "++");
            input = input.Replace("-  -", "--");
            input = input.Replace(">  =", ">=");
            input = input.Replace("<  =", "<=");
            input = input.Replace("|  |", "||");
            input = input.Replace("&  &", "&&");

            var copyinput = new StringBuilder(input);
            for (int i = 0; i < copyinput.Length; i++)
            {
                if (copyinput[i] == '\n')
                    copyinput[i] = '$';
            }

            copyinput = copyinput.Replace("\n", String.Empty);
            copyinput = copyinput.Replace("\r", String.Empty);
            copyinput = copyinput.Replace("\t", String.Empty);
            copyinput = copyinput.Replace("$", "");
            copyinput = copyinput.Replace("~", "");
            //copyinput = copyinput.Replace("\" \"", "sub");
            //copyinput = copyinput.Replace("\' \'", "subch");
            tokens = copyinput.ToString().Split(' ');

            richTextBox1.Text = "";
            foreach (var token in tokens)
            {
                analyze(token);
            }

        }

        void analyze(string x)
        {

            if(x.Equals("__"))
            {
                richTextBox1.AppendText(stringarr.ElementAt(i).ToString() + " -> String\n");
                i++;
            }
            else if (integer.IsMatch(x))
            {
                richTextBox1.AppendText(x + " -> Integer\n");
            }
            else if (decimals.IsMatch(x))
            {
                richTextBox1.AppendText(x + " -> Floating Value\n");
            }

            else if (seperatorss.IsMatch(x))
                richTextBox1.AppendText(x + " -> Seperator\n");

            else if (operatorss.IsMatch(x))
                richTextBox1.AppendText(x + " -> Operator\n");

            else if (strings.IsMatch(x))
            {
                
                richTextBox1.AppendText(x+ " -> String\n");
            }

            else if (characters.IsMatch(x))
            {
                richTextBox1.AppendText(x + " -> Character\n");
            }

            else if (keywords.IsMatch(x))
                richTextBox1.AppendText(x + " -> KeyWord\n");

            else if (x.Equals("\n") || x.Equals("\r") || x.Equals("\r\n") || x.Equals("") || x.Equals(" "))
            {

            }

            else if(identifier.IsMatch(x))
            {
                richTextBox1.AppendText(x + " -> Identifier\n");
            }

            else
            {
                richTextBox1.AppendText(x + " -> Invalid token\n");
            }

        }
    }
}
