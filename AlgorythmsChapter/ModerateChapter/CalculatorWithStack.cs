using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.ModerateChapter
{
    internal class CalculatorWithStack
    {
        private readonly Stack<double> _stackWithNumbers;
        private readonly Stack<Operation> _opStack;

        public CalculatorWithStack()
        {
            _stackWithNumbers = new();
            _opStack = new();
        }

        /*public double Calculate(string calcualation)
        {
            var calculationTrimmed = calcualation.Replace(' ', '');
            var charArray = calculationTrimmed.ToCharArray();
            var index = 0;
            while (index <= charArray.Length)
            {
                var val = charArray[index];
                var op = charArray[index + 1];
                var item = int.Parse(val.ToString());
                _stackWithNumbers.Push(item);
                termsList.Add(term);
            }

            return termsList;

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
        }*/

        public void CollapseStack(Operation nextOperation)
        {
            if (_stackWithNumbers.Count < 2 && _opStack.Count < 1) return;

            if (GetOperatorPriority(nextOperation) >= GetOperatorPriority(_opStack.Pop()))
            {
                var secondNumber = _stackWithNumbers.Pop();
                var firstNumber = _stackWithNumbers.Pop();
                var oper = _opStack.Pop();
                var number = ApplyMath(firstNumber, secondNumber, oper);
                _stackWithNumbers.Push(number);
            }
        }

        public int GetOperatorPriority(Operation operation)
        {
            switch (operation)
            {
                case Operation.Subtract:
                    return 1;
                case Operation.Multiply:
                    return 2;
                case Operation.Divide:
                    return 2;
                case Operation.Add:
                    return 1;
                default:
                    return 0;
            }
        }
        public double ApplyMath(double left, double right, Operation operation)
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
}
