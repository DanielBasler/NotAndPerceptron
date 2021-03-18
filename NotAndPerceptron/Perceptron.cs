using System;
using System.Linq;

namespace NotAndPerceptron
{
    public class Perceptron
    {
        public double LearningRate { set; get; }
        public double Threshold { set; get; }
        public double[] Weights { set; get; }

        public Perceptron(int inputCount, double learningRate = 0.2, double threshold = 0.5)
        {
            Weights = new double[inputCount];
            LearningRate = learningRate;
            Threshold = threshold;
        }

        public bool Coaching(bool expectedResult, params double[] inputs)
        {

            bool result = GetResult(inputs);

            if (result != expectedResult)
            {
                double error = (expectedResult ? 1 : 0) - (result ? 1 : 0);
                for (int i = 0; i < Weights.Length; i++)
                {
                    Weights[i] += LearningRate * error * inputs[i];
                }
            }

            return result;
        }

        public bool GetResult(params double[] inputs)
        {
            if (inputs.Length != Weights.Length)
                throw new ArgumentException("Ungültige Anzahl von Eingaben. Erwartet werden: " + Weights.Length);
            
            return DotProduct(inputs, Weights) > Threshold;
        }

        private double DotProduct(double[] inputs, double[] weights)
        {
            return inputs.Zip(weights, (value, weight) => value * weight).Sum();
        }

        
    }
}
