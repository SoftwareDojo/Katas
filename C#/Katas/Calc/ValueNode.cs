
namespace Katas.Calc
{
    public abstract class Node
    {
        public abstract double Evaluate();
    }

    public class ValueNode : Node
    {
        private readonly double m_Value;

        public ValueNode(double value)
        {
            m_Value = value;
        }

        public override double Evaluate()
        {
            return m_Value;
        }

        public override string ToString()
        {
            return m_Value.ToString();
        }
    }
}
