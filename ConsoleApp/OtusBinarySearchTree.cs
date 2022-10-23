namespace ConsoleApp
{
    public class OtusBinarySearchTree<TKey, TValue> where TKey : IComparable
    {
        class TreeNode<TKeyNode, TValueNode>
        {
            public TKeyNode Key { get; set; }
            public TValueNode Value { get; set; }

            public TreeNode<TKeyNode, TValueNode>? Left { get; set; }
            public TreeNode<TKeyNode, TValueNode>? Right { get; set; }

            public TreeNode(TKeyNode key, TValueNode value,
                TreeNode<TKeyNode, TValueNode>? left = null,
                TreeNode<TKeyNode, TValueNode>? right = null)
            {
                Key = key;
                Value = value;
                Left = left;
                Right = right;                
            }
        }

        private TreeNode<TKey, TValue>? _root;

        public OtusBinarySearchTree() => _root = null;        

        public void AddNode(TKey key, TValue value)
        {            
            if (_root == null)
            {
                _root = new TreeNode<TKey, TValue>(key, value, left: null, right: null);
            }
            else
            {
                TreeNode<TKey, TValue>? currentNode = _root;
                while (true)
                {
                    if (key.CompareTo(currentNode.Key) < 0)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new TreeNode<TKey, TValue>(key, value, left: null, right: null);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = new TreeNode<TKey, TValue>(key, value, left: null, right: null);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }
        }
        
        // Для обхода дерева буду использовать Stack, чтобы избежать рекурсии.
        public IEnumerable<Tuple<TKey, TValue>> InOrderTraversal()
        {         
            if (_root != null)
            {             
                var stack = new Stack<TreeNode<TKey, TValue>>();

                var currentNode = _root;                
                bool toTurnLeftNext = true;
                
                stack.Push(currentNode);

                while (stack.Count > 0)
                {                    
                    if (toTurnLeftNext)
                    {
                        while (currentNode.Left != null)
                        {
                            stack.Push(currentNode);
                            currentNode = currentNode.Left;
                        }
                    }                    
                    yield return new Tuple<TKey, TValue>(currentNode.Key, currentNode.Value);
                    
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;                        
                        toTurnLeftNext = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        toTurnLeftNext = false;
                    }
                }                
            }
            yield break;
        }
        
        public TValue? LookingFor(TKey key)
        {
            TreeNode<TKey, TValue>? currentNode = _root;
            while (true)
            {
                if (currentNode == null)
                {
                    return default;
                }
                else
                {
                    var compareResult = key.CompareTo(currentNode.Key);
                    if (compareResult == 0)
                    {
                        return currentNode.Value;
                    }
                    else if(compareResult < 0)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }                        
                }
            }            
        }
    }
}
