using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1sem2
{
    class ViewTree
    {
        private ITrieTree tree;
        private TreeView treeView;

        public ViewTree(ITrieTree Tree, TreeView TreeView)
        {
            tree = Tree; treeView = TreeView;
        }

        public void GetView()
        {
            TreeNode root = tree.Head.TreeNode("root");
            treeView.Nodes.Clear();
            treeView.Nodes.Add(root);
            treeView.ExpandAll();
        }
    }
}
