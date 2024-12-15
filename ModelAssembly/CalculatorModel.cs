using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public static class CalculatorModel
{
  // patternOfCalculation = @"^\d+(\+\d+)*$";
    private static bool IsValidExpression(string _input) => Regex.IsMatch(_input, @"^\d+(\+\d+)*$");
    public static bool TryCalculate(string _input, out int result)
    {
        result = default;
        if (!IsValidExpression(_input) || string.IsNullOrWhiteSpace(_input) || !_input.Contains("+")) return false;

        try
        {
            string[] partsOfExpression = _input.Split('+');
            foreach (var p in partsOfExpression)
            {
                if (!int.TryParse(p, out int number)) return false;
                else result += int.Parse(p);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
