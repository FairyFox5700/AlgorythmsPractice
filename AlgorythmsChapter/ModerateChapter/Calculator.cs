using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.ModerateChapter
{

    //16.26 Calculator: Given an arithmetic equation consisting of positive integers,+,-,* and/ (no parentheses),
    //compute the result.
    internal class Calculator
    {
        public double Count(string calculation)
        {
            var termsList = ParseToTerms(calculation);
            var result = 0D;
            for (int i = 0; i < termsList.Count; i++)
            {
                var processing = new Term();
                var currentTerm = termsList[i];
                var nextTerm = (i + 1) < termsList.Count ? termsList[i + 1] : null;
                processing = CollapseTerms(processing, currentTerm);

                if (nextTerm != null &&
                    (Term.ParseOperator(nextTerm.Operator) == Operation.Add
                    || Term.ParseOperator(nextTerm.Operator) == Operation.Subtract))
                {
                    result = ApplyMath(result, currentTerm.Number, Term.ParseOperator(currentTerm.Operator));
                    processing = null;
                }


            }
            return result;
        }

        public Term CollapseTerms(Term primary, Term secondary)
        {
            var value = ApplyMath(primary.Number, secondary.Number, Term.ParseOperator(secondary.Operator));

            primary.Number = value;
            return primary;
        }

        private List<Term> ParseToTerms(string calcualation)
        {
            var termsList = new List<Term>();
            var calculationTrimmed = calcualation.Replace(' ', ' ');
            var charArray = calculationTrimmed.ToCharArray();
            var index = 0;
            while (index <= charArray.Length)
            {
                var val = charArray[index];
                var op = charArray[index + 1];
                var term = new Term()
                {
                    Number = val,
                    Operator = op,
                };
                index += 2;
                termsList.Add(term);
            }

            return termsList;
        }

        private double ApplyMath(double left, double right, Operation operation)
        {
            switch (operation)
            {
                case Operation.Subtract:
                    return left - right;
                case Operation.Multiply:
                    return left * right;
                case Operation.Divide:
                    return left / (double)right;
                case Operation.Add:
                    return left + right;
                default:
                    throw new AggregateException(nameof(operation));
            }
        }
    }

    public class Term
    {
        public double Number { get; set; }
        public char Operator { get; set; }

        public static Operation ParseOperator(char operatorInString)
        {
            switch (operatorInString)
            {
                case '-':
                    return Operation.Subtract;
                case '+':
                    return Operation.Add;
                case '/':
                    return Operation.Divide;
                case '*':
                    return Operation.Multiply;
                default:
                    throw new AggregateException(nameof(operatorInString));
            }
        }

    }

    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide,
    }
}
