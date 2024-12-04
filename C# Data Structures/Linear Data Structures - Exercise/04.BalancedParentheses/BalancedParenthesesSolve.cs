using System;

namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (String.IsNullOrEmpty(parentheses) ||
                parentheses.Length % 2 == 1)
            {
                return false;
            }

            var openingBrackets = new Stack<char>(parentheses.Length / 2);

            foreach (var currentBracket in parentheses)
            {
                char expectedBracket = default;

                switch (currentBracket)
                {
                    case ')':
                        expectedBracket = '(';
                        break;
                    case ']':
                        expectedBracket = '[';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    default:
                        openingBrackets.Push(currentBracket);
                        break;
                }

                if (expectedBracket == default)
                {
                    continue;
                }

                if (openingBrackets.Pop() != expectedBracket)
                {
                    return false;
                }
            }

            return openingBrackets.Count == 0;
        }
    }
}
