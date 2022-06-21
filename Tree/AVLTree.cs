using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    
    public class AVL : BinSearchTree
    {
        //private class Knoten
        //      {
        //	public int data;
        //	public Knoten links;
        //	public Knoten rechts;
        //          public Knoten parent = null;
        //          public Knoten(int data)
        //          {
        //		this.data = data;
        //          }


        //      }
        public AVL() : base()
        {

        }
        public override bool insert(int elem)
        {

            if (base.insert(elem))
            {
                inorder(root);
                return true;
            }
            else
                return false;






        }
        public override bool delete(int elem)
        {
            if (base.delete(elem))
            {
                inorder(root);
                return true;
            }
            else
                return false;

            //TreeItem deleteitem = base.delete_(elem);
            //if (deleteitem != root && deleteitem!=null)
            //{
            //    do
            //    {
            //        deleteitem = deleteitem.parent;
            //        BalanceTree(deleteitem);

            //    } while (deleteitem.parent != null);
            //}

            //if (deleteitem == root)
            //    return true;
            //return false;


        }


        //public override bool search(int elem)
        //{
        //    return base.search(elem);
        //}

        //public override void print()
        //{
        //    base.print();
        //}

        private void inorder(TreeItem n)
        {
            if (n.left != null)
                inorder(n.left);
            if (n.right != null)
                inorder(n.right);
            if (Hoehe(n) > 1 || Hoehe(n) < -1)
                BalanceTree(n);

        }
        private TreeItem _search(int _value)
        {
            TreeItem current_item = root;
            //bool found = false;
            bool treeCompleted = false;

            do
            {
                if (_value == current_item.value)       //currentItem hat die gesuchte Value
                {
                    searchResult = current_item;
                    return current_item;
                }

                else if (_value < current_item.value)   //linker Teilbaum --> neue Zahl gehört links unter item
                {
                    if (current_item.left == null)
                    {
                        parentPointer = current_item;
                        pointerIsLeftChild = true;
                        treeCompleted = true;
                    }
                    else
                        current_item = current_item.left;
                }

                else                                    //rechter Teilbaum
                {
                    if (current_item.right == null)
                    {
                        parentPointer = current_item;
                        pointerIsLeftChild = false;
                        treeCompleted = true;
                    }
                    else
                        current_item = current_item.right;
                }
            } while (!treeCompleted);

            return current_item;
        }


        private TreeItem RechtsLinksrotation(TreeItem knoten)
        {
            Rechtsrotation(knoten);
            return Linksrotation(knoten);


        }

        private TreeItem LinksRechtsrotation(TreeItem knoten)
        {
            Linksrotation(knoten);
            return Rechtsrotation(knoten);
        }

        private TreeItem Rechtsrotation(TreeItem knoten)
        {

            TreeItem Temp = knoten.right; //knoten.right
            TreeItem parentKnoten;
            //if(knoten == root)
            //{
            //    return null;
            //}
            parentKnoten = knoten.parent.parent;
            knoten.parent.left = Temp;
            knoten.right = knoten.parent; //knoten.right
            if (parentKnoten != null)
            {
                parentKnoten.right = knoten;
            }
            knoten.parent.parent = knoten;
            knoten.parent = parentKnoten;
            if (Temp != null)
            {
                Temp.parent = knoten.right;

            }
            if (parentKnoten == null)
            {
                root = knoten;
            }
            return Temp;
        }

        private TreeItem Linksrotation(TreeItem knoten)
        {

            TreeItem Temp = knoten.left; //knoten.right
            TreeItem parentKnoten;
            //if (knoten == root)
            //{
            //    return null;
            //}
            parentKnoten = knoten.parent.parent;
            knoten.parent.right = Temp;
            knoten.left = knoten.parent; //knoten.right
            if (parentKnoten != null)
            {
                parentKnoten.left = knoten;
            }
            knoten.parent.parent = knoten;
            knoten.parent = parentKnoten;
            if (Temp != null)
            {
                Temp.parent = knoten.left;

            }
            if (parentKnoten == null)
            {
                root = knoten;
            }
            return Temp;
        }

        private int Hoehe(TreeItem knoten)
        {

            int height = 0;
            int m;
            if (knoten != null)
            {
                int l = Hoehe(knoten.left);
                int r = Hoehe(knoten.right);
                if (l > r)
                    m = l;
                else
                    m = r;

                height = m + 1;
            }
            return height;

        }

        private int Balance_Faktor(TreeItem knoten)  // Balance Faktoren errechnen sich aus der Differenz der linken und rechten Teilbäume
        {
            if (knoten == null)
                return 0;
            int r = 0;
            int l = 0;

            if (knoten.right != null)
                r = Hoehe(knoten.right);
            if (knoten.left != null)
                l = Hoehe(knoten.left);
            int faktor = l - r;
            return faktor;
        }

        private TreeItem BalanceTree(TreeItem knoten)
        {
            int balanceFak = Balance_Faktor(knoten);

            //Rechtslastig
            if (balanceFak < -1)
            {
                if (Balance_Faktor(knoten.right) < 0)  // 1. Fall
                    knoten = Linksrotation(knoten.right);
                else
                    knoten = RechtsLinksrotation(knoten.right.left);  // 2. Fall
            }

            //Linkslastig
            if (balanceFak > 1)
            {
                if (Balance_Faktor(knoten.left) > 0)      // 3. Fall
                    knoten = Rechtsrotation(knoten.left);
                else
                    knoten = LinksRechtsrotation(knoten.left.right);  // 4. Fall
            }

            return knoten;
        }
    }
}
