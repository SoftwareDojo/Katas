namespace CSharpKatas.Calc
{
    public abstract class OperationNode : Node
    {
        public Node Left;
        public Node Right;
    }

    public class AdditionNode : OperationNode
    {
        public override double Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }

        public override string ToString()
        {
            return Left + " + " + Right;
        }
    }

    public class MultiplicationNode : OperationNode
    {
        public override double Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }

        public override string ToString()
        {
            return Left + " * " + Right;
        }
    }

    public class SubtractionNode : OperationNode
    {
        public override double Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }

        public override string ToString()
        {
            return Left + " - " + Right;
        }
    }

    public class DivisionNode : OperationNode
    {
        public override double Evaluate()
        {
            return Left.Evaluate() / Right.Evaluate();
        }

        public override string ToString()
        {
            return Left + " / " + Right;
        }
    }
}