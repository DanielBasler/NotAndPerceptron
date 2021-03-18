namespace NotAndPerceptron
{
    public class CoachingItem
    {
        public double[] Inputs { get; private set; }
        public bool Output { get; private set; }

        public CoachingItem(bool expectedOutput, params double[] inputs)
        {
            Output = expectedOutput;
            Inputs = inputs;
        }
    }
}
