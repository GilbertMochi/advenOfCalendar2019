using System;

namespace _2ndDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[] { 1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 10, 19, 1, 9, 19, 23, 1, 13, 23, 27, 1, 5, 27, 31, 2, 31, 6, 35, 1, 35, 5, 39, 1, 9, 39, 43, 1, 43, 5, 47, 1, 47, 5, 51, 2, 10, 51, 55, 1, 5, 55, 59, 1, 59, 5, 63, 2, 63, 9, 67, 1, 67, 5, 71, 2, 9, 71, 75, 1, 75, 5, 79, 1, 10, 79, 83, 1, 83, 10, 87, 1, 10, 87, 91, 1, 6, 91, 95, 2, 95, 6, 99, 2, 99, 9, 103, 1, 103, 6, 107, 1, 13, 107, 111, 1, 13, 111, 115, 2, 115, 9, 119, 1, 119, 6, 123, 2, 9, 123, 127, 1, 127, 5, 131, 1, 131, 5, 135, 1, 135, 5, 139, 2, 10, 139, 143, 2, 143, 10, 147, 1, 147, 5, 151, 1, 151, 2, 155, 1, 155, 13, 0, 99, 2, 14, 0, 0 };

            GetResultFromArray(numArray);
            FindNounAndVerbForGivenResult(numArray, 19690720);
        }

        static void FindNounAndVerbForGivenResult(int[] arr, int result)
        {

            int[] array = new int[arr.Length];
            arr.CopyTo(array, 0);

            int opcodeIndex = 0;
            int firstIndex = 1;
            int secondIndex = 2;
            int resultIndex = 3;

            for (int j = 0; j <= 99; j++)
            {
                for (int k = 0; k <= 99; k++)
                {
                    for (int i = 0; i < array.Length - 5; i += 4)
                    {
                        if(array[i] != 99)
                        {
                            array[1] = j;
                            array[2] = k;

                            opcodeIndex = i;
                            firstIndex = i + 1;
                            secondIndex = i + 2;
                            resultIndex = i + 3;

                            int firstNum = array[firstIndex];
                            int secondNum = array[secondIndex];
                            int whereToPutResult = array[resultIndex];

                            array[whereToPutResult] = executeOpCode(array[opcodeIndex], array[firstNum], array[secondNum]);//lovely equation here
                        }

                        if (array[i] == 99)//if opcode is 99
                        {
                            i = array.Length;//halt third loop                  

                            if (array[0] == result)
                            {
                                Console.WriteLine($"\nnoun={j}, verb={k}.");
                                k = 100;//halt second loop
                                j = 100;//halt first loop
                            }
                            
                            Console.WriteLine($"\nProgram halted. Value in position [0] : {array[0]}. \n");
                        }

                    }


                }
            }

        }

        static void GetResultFromArray(int[] arr)
        {
            int[] array = new int[arr.Length];
            arr.CopyTo(array, 0);

            int opcodeIndex = 0;
            int firstIndex = 1;
            int secondIndex = 2;
            int resultIndex = 3;

            for (int i = 0; i < array.Length - 5; i += 4)
            {

                if (array[i] != 99)
                {
                    opcodeIndex = i;
                    firstIndex = i + 1;
                    secondIndex = i + 2;
                    resultIndex = i + 3;

                    int firstNum = array[firstIndex];
                    int secondNum = array[secondIndex];
                    int whereToPutResult = array[resultIndex];

                    Console.WriteLine($"i = {i}, OpCode index = {opcodeIndex}, first index = {firstIndex}, second index = {secondIndex}.");
                    Console.WriteLine($"OpCode = {array[opcodeIndex]}, first num = {array[firstNum]}, second num = {array[secondNum]}.");

                    array[whereToPutResult] = executeOpCode(array[opcodeIndex], array[firstNum], array[secondNum]);//lovely equation here

                    Console.WriteLine($"result index = {whereToPutResult}, result = {array[whereToPutResult]}.\n");
                }

                if (array[i] == 99)//if opcode is 99
                {
                    i = array.Length + 1;//i will be changed to equal the length of the array and for loop will be finished
                    Console.WriteLine($"\nProgram halted. Value in position [0] : {array[0]}. \n");
                }
            }
        }

        static int executeOpCode(int opCode, int a, int b)
        {
            int result = 0;
            switch (opCode)
            {
                case 1:
                    result = a + b;
                    Console.WriteLine($"Added together {a} + {b} = {(a + b).ToString()}.");
                    break;
                case 2:
                    result = a * b;
                    Console.WriteLine($"Multiplied {a} * {b} = {(a * b).ToString()}.");
                    break;
                default:
                    break;
            }

            return result;
        }

    }
}