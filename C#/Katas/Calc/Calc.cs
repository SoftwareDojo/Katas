namespace Katas.Calc
{
    public class Calc
    {
        private readonly NodeFactory nodeFactory;

        public Calc()
        {
            nodeFactory = new NodeFactory();
            nodeFactory.Register("+", typeof(AdditionNode));
            nodeFactory.Register("*", typeof(MultiplicationNode));
            nodeFactory.Register("-", typeof(SubtractionNode));
            nodeFactory.Register("/", typeof(DivisionNode));
        }

        public double Evaluate(string expression, out string output)
        {
            var node = nodeFactory.CreateNode(expression);
            output = node.ToString();
            return node.Evaluate();
        }
    }
}
