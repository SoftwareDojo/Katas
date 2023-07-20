namespace Katas.Calc
{
    public abstract class Node
    {
        public abstract double Evaluate();
    }

    public class ValueNode : Node
    {
        private readonly double value;

        public ValueNode(double value)
        {
            this.value = value;
        }

        public override double Evaluate()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
