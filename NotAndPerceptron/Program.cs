using System;

namespace NotAndPerceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            CoachingItem[] trainingSet =
            {
                new CoachingItem(true, 1, 0, 0),
                new CoachingItem(true, 1, 0, 1),
                new CoachingItem(true, 1, 1, 0),
                new CoachingItem(false, 1, 1, 1)
            };

            Perceptron perceptron = new Perceptron(3);

            int attemptCount = 0;

            while (true)
            {
                Console.WriteLine("---- Versuch: " + (++attemptCount) +" ----");

                int errorCount = 0;
                foreach (var item in trainingSet)
                {                    
                    var output = perceptron.Coaching(item.Output, item.Inputs);
                    
                    if (output != item.Output)
                    {
                        Console.WriteLine("Durchgefallen\t {0} & {1} & {2} != {3}", item.Inputs[0], item.Inputs[1], item.Inputs[2], output);
                        errorCount++;
                    }
                    else
                    {
                        Console.WriteLine("Richtig\t {0} & {1} & {2} = {3}", item.Inputs[0], item.Inputs[1], item.Inputs[2], output);
                    }
                }
                
                if (errorCount == 0)
                    break;
            }

            //Anpassung fuer VS 2017
            Console.ReadLine();
        }
    }
}
