using PROG7312.Models;

namespace PROG7312.Services
{
    public class BinarySearchTree // ReportID is being used for the binary search tree
    {
        public TreeNode Root { get; set; }

        public void Insert(TreeNode node)
        {
            if (Root == null) // if there is no root, the node becomes the root
            {
                Root = node;
            }
            else // is root exists, InsertDirection is used to determine where the new node goes, either left(for smaller id) or right(for larger id)
            {
                InsertDirection(Root, node); 
            }
        }

        public void InsertDirection(TreeNode currentNode, TreeNode newNode)
        {
            if (newNode.ReportID < currentNode.ReportID)  // checking if node being added is smaller than than current node to see if it gets added on the left of it or the right
            {
                if (currentNode.Left == null) // if there is no node to the left of current node and new node is smaller than current node, new node gets added to the left
                {
                    currentNode.Left = newNode;
                }
                else 
                {
                    InsertDirection(currentNode.Left, newNode); // if there is a node to the left, this is compared to that node reusing this method
                }

            }
            else // node goes right if it is larger than currentNode
            {
                if (currentNode.Right == null) // if there is no node to the right of current node and new node is bigger than current node, new node gets added to the right
                {
                    currentNode.Right = newNode; 
                }
                else // if there is a node to the right, this is compared to that node reusing this method
                {
                    InsertDirection(currentNode.Right, newNode);
                }
            }
        }

        public TreeNode GetNode(int ReportID) // method to retrieve node that matches entered ReportID
        {
            var currentNode = Root;

            while (currentNode != null) //while loop to loop until current node is null (breaks if reaches end of tree)
            {
                if (ReportID == currentNode.ReportID)
                {
                    return currentNode;  
                }

                if (currentNode.ReportID > ReportID) // goes left if report id is smaller than current node
                {
                    currentNode = currentNode.Left;
                }
                else // goes right if report id is larger than current node
                {
                    currentNode = currentNode.Right;
                }
            }

            return null;
        }

    }
}
