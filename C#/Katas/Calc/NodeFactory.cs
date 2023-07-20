using System;
using System.Collections.Generic;

namespace Katas.Calc
{
    public class NodeFactory
    {
        private readonly IDictionary<string, Type> operationNodes;

        public NodeFactory()
        {
            operationNodes = new Dictionary<string, Type>();
        }

        public void Register(string operation, Type nodeType)
        {
            operationNodes.Add(operation, nodeType);
        }

        public Node CreateNode(string expression)
        {
            string[] expressionValues = expression.Split(' ');
            Node prevNode = null;

            for (int i = expressionValues.Length - 1; i >= 0; i--)
            {
                if (!operationNodes.TryGetValue(expressionValues[i], out var operationType))
                {
                    var node = new ValueNode(Convert.ToDouble(expressionValues[i]));
                    if (prevNode == null) prevNode = node;
                    else ((OperationNode)prevNode).Left = node;
                    continue;
                }

                OperationNode oNode = (OperationNode)Activator.CreateInstance(operationType);
                oNode.Right = prevNode;
                prevNode = oNode;
            }

            return prevNode;
        }
    }
}
