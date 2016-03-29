using System;
using System.Collections.Generic;

namespace CSharpKatas.Calc
{
    public class NodeFactory
    {
        private readonly IDictionary<string, Type> m_OperationNodes;

        public NodeFactory()
        {
            m_OperationNodes = new Dictionary<string, Type>();
        }

        public void Register(string operation, Type nodeType)
        {
            m_OperationNodes.Add(operation, nodeType);
        }

        public Node CreateNode(string expression)
        {
            string[] expressionValues = expression.Split(' ');
            Node prevNode = null;

            for (int i = expressionValues.Length-1; i >= 0; i--)
            {
                Type operationType;
                if (!m_OperationNodes.TryGetValue(expressionValues[i], out operationType))
                {
                    ValueNode vNode = new ValueNode(Convert.ToDouble(expressionValues[i]));
                    if (prevNode == null) prevNode = vNode;
                    else ((OperationNode)prevNode).Left = vNode;
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