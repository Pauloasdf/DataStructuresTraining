using DataStructuresTraining;
using DataStructuresTraining.Extensions;
using static DataStructuresTraining.Models.Enums;

Console.WriteLine(AddBinary("11", "1"));
Console.WriteLine(AddBinary("1010", "1011"));

string AddBinary(string firstBinaryNumber, string SecondBinaryNumber)
{
    string result = "";
    char lastColumnSumRemaining = '0';

    for (int i = 1; i <= firstBinaryNumber.Length; i++)
    {
        if (firstBinaryNumber[^i] == '1')
        {
            (result, lastColumnSumRemaining) = CalculateColumnSum(SecondBinaryNumber, result, (i <= SecondBinaryNumber.Length 
                                                                                    ? SecondBinaryNumber[^i] 
                                                                                    : lastColumnSumRemaining));

            if(i == firstBinaryNumber.Length && result[0] == '0') 
                result = $"1{result}";
        }


    }

    return result;
}

(string, char) CalculateColumnSum(string b, string result, char curPosition)
{
    char curSumResult = curPosition == '1' ? '0' : '1';
    char curSumRemain = curSumResult == '1' ? '0' : '1';
    return ($"{curSumResult}{result}", curSumRemain);
}