using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Collections;

namespace MarketScanner.Common
{
    sealed class MarketTreeView : TreeView
    {
        private bool DoHashMatch { get; set; }

        private Hashtable _htAvailLogItems;
        private int _maxTreeDepth;

        public MarketTreeView()
        {
            this.AllowDrop = true;
            this.ItemDrag += MarketTreeViewItemDrag;
        }

        void MarketTreeViewItemDrag( object sender, ItemDragEventArgs e )
        {

            //TreeNode sourceNode = (TreeNode)e.Item;
            
            DoDragDrop( e.Item.ToString(), DragDropEffects.Move | DragDropEffects.Copy );
        }


        private void DisplayXml( XmlNode xmldoc, TreeView tvw )
        {
            // Add it to the TreeView Nodes collection
            DisplayXmlNode( xmldoc, tvw.Nodes );
            // Expand the root node.
            //tvw.Nodes[0].Expand();
        }

        private void DisplayXmlNode( XmlNode xmlnode, TreeNodeCollection nodes )
        {
            // Add a TreeView node for this XmlNode.
            // (Using the node's Name is OK for most XmlNode types.)
            TreeNode tvNode = null;

            switch (xmlnode.NodeType)
            {
                case XmlNodeType.Element:
                    if (xmlnode.Name == "ItemCategory")
                    {
                        if (xmlnode.FirstChild.Name == "Name")
                        {
                            tvNode = nodes.Add( xmlnode.FirstChild.InnerText );
                            Font font = new Font( "Arial", 8 );
                            tvNode.NodeFont = font;
                            //tvNode.Tag = "ItemCategory";
                            if (xmlnode.LastChild.Name == "Subcategories")
                            {
                                xmlnode = xmlnode.LastChild;
                            }
                            if (xmlnode.LastChild.Name == "Items")
                            {
                                xmlnode = xmlnode.LastChild;
                            }
                        }
                    }
                    if (xmlnode.Name == "Item")
                    {
                        // Set leaf node name
                        if (xmlnode.FirstChild.Name == "Name")
                        {
                            if (DoHashMatch)
                            {
                                // Get Item Hash
                                string sItemName = xmlnode.FirstChild.InnerText;
                                int iHash = sItemName.GetHashCode();
                                if (!_htAvailLogItems.Contains( iHash ))
                                {
                                    tvNode = nodes.Add( xmlnode.FirstChild.InnerText ); // Add the node
                                    Font font = new Font( "Arial", 8 );
                                    tvNode.NodeFont = font;
                                    tvNode.ForeColor = Color.Gray;
                                    //tvNode.Tag = "ItemGreyed";
                                }
                                else
                                {
                                    tvNode = nodes.Add( xmlnode.FirstChild.InnerText ); // Add the node
                                    tvNode.ForeColor = Color.Black;
                                    Font boldFont = new Font( "Arial", 8, FontStyle.Bold );
                                    tvNode.NodeFont = boldFont;
                                    tvNode.EnsureVisible();
                                    tvNode.Tag = _htAvailLogItems[iHash]; // set treenode tag for later selection
                                }
                                // calculate max depth of tree for later pruning
                                _maxTreeDepth = (tvNode.Level > _maxTreeDepth) ? tvNode.Level : _maxTreeDepth;
                            }
                            xmlnode = null;
                        }
                    }
                    break;
                case XmlNodeType.Text:
                    break;
                case XmlNodeType.CDATA:
                    break;
                case XmlNodeType.Document:
                    // Get first category node
                    xmlnode = xmlnode.FirstChild.NextSibling;
                    break;
                default:
                    break;
                // ignore other node types.
            }

            // Only continue if any nodes were added.
            TreeNodeCollection newNodes = (tvNode == null) ? nodes : tvNode.Nodes;

            if (xmlnode == null) return;
            // Call this routine recursively for each child node.
            XmlNode xmlChild = xmlnode.FirstChild;
            while (xmlChild != null)
            {
                DisplayXmlNode( xmlChild, newNodes );
                xmlChild = xmlChild.NextSibling;
            }
        }


        private void LoadTreeView()
        {
            this.Cursor = Cursors.WaitCursor;

            // Load the XML file.
            XmlDocument dom = DataHandler.FromCompressedXmlFile( Values.sAppPath + Values.APP_RESOURCE_ITEMS_XML );

            // Load the XML into the TreeView.
            this.Nodes.Clear();

            this.BeginUpdate();

            DisplayXml( dom, this );
            // Show all or only available, as per ShowAllAvailableMarketItemsInTreeView setting in options
            if (!Values.ShowAllAvailableMarketItemsInTreeView) PruneTreeView();

            this.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        public void LoadTreeView( ref Hashtable ht )
        {
            _htAvailLogItems = ht;
            DoHashMatch = true;
            LoadTreeView();
            _htAvailLogItems = null;
        }



        public void SelectByTag( object o )
        {
            TreeNodeCollection nodes = this.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursiveTag( n, o );
            }
        }



        private void FindRecursiveTag( TreeNode treeNode, object o )
        {

            foreach (TreeNode tn in treeNode.Nodes)
            {
                // if the text properties match, color the item
                if (tn.Tag != null && tn.Tag.Equals( o ))
                {
                    SelectTreeNode( tn );
                }
                FindRecursiveTag( tn, o );
            }
        }

        private void SelectTreeNode( TreeNode tnSelected )
        {

            this.HideSelection = false;
            this.SelectedNode = tnSelected;
            //tnSelected.BackColor = Color.Yellow;
            this.SelectedNode.EnsureVisible();

        }

        private void PruneTreeView()
        {
            // prune each node recursively.
            // TODO: Do it in a bottom up fashion, so that the many recursions aren't necessary
            for (int i = 0 ; i < _maxTreeDepth + 1 ; i++)
            {
                RemoveCheckedNodes( this.Nodes );
            }
        }


        static void RemoveCheckedNodes( TreeNodeCollection nodes )
        {
            List<TreeNode> checkedNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == null && node.FirstNode == null)
                {
                    checkedNodes.Add( node );
                }
                else
                {
                    RemoveCheckedNodes( node.Nodes );
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove( checkedNode );
            }
        }



    }
}
