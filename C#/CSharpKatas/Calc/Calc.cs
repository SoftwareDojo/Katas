namespace CSharpKatas.Calc
{
    public class Calc
    {
        private readonly NodeFactory m_NodeFactory;

        public Calc()
        {
            m_NodeFactory = new NodeFactory();
            m_NodeFactory.Register("+", typeof(AdditionNode));
            m_NodeFactory.Register("*", typeof(MultiplicationNode));
            m_NodeFactory.Register("-", typeof(SubtractionNode));
            m_NodeFactory.Register("/", typeof(DivisionNode));
        }

        public double Evaluate(string expression, out string output)
        {
            var node = m_NodeFactory.CreateNode(expression);
            output = node.ToString();
            return node.Evaluate();
        }
    }
}
