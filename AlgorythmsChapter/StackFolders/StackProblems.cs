using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter
{
    internal class StackProblems
    {
        //Discuss how stacks can be used for checking balancing of symbols.
        //  Solution: Stacks can be used to check whether the given expression has balanced symbols.This
        //  algorithm is very useful in compilers.Each time the parser reads one character at a time. If the
        //  character is an opening delimiter such as (, {, or[-then it is written to the stack.When a closing
        //  delimiter is encountered like ), }, or ]-the stack is popped.

        /*Algorithm:

        Declare a character stack S.
        Now traverse the expression string exp.
        If the current character is a starting bracket (‘(‘ or ‘{‘ or ‘[‘) then push it to stack.
        If the current character is a closing bracket (‘)’ or ‘}’ or ‘]’) then pop from stack and if the popped character is the matching starting bracket then fine else brackets are not balanced.
        After complete traversal, if there is some starting bracket left in stack then “not balanced”
        */
        public void StackBalacingSymbols(string[] array)
        {
            var stack = new Stack<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "(" || array[i] == "[" | array[i] == "{")
                {
                    stack.Push(array[i]);
                }
                else if (array[i] == "}" || array[i] == "]" | array[i] == ")")
                {
                    var character = stack.Pop();
                    if (character != Reverse(array[i]))
                    {
                        throw new InvalidDataException(nameof(character));
                    }
                }
                else
                {
                    throw new InvalidDataException("Invalid arguments in array");
                }
            }

            if (stack.Count > 0)
            {
                throw new InvalidDataException("Not balanced");
            }
        }

        private string Reverse(string s)
        {
            switch (s)
            {
                case "{":
                    return "}";
                case "[":
                    return "]";
                case "(":
                    return ")";
            }

            return s;
        }
    }
}