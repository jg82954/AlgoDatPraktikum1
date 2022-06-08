using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    

    public class Treap : BinSearchTree
    {
        
        public class TreapItem : TreeItem
        {
            public int priority;

           
            public TreapItem(int value) : base(value)
            {
                Random rd = new Random();
                this.priority = rd.Next(0, 100);
            }


            public override string ToString()
            {
                int links, rechts, par;
                if (left == null)
                    links = 0;
                else
                    links = left.value;

                if (right == null)
                    rechts = 0;
                else
                    rechts = right.value;

                if (parent == null)
                    par = 0;
                else
                    par = parent.value;


                return $"val: {value}, p: {priority}, l: {links}, r: {rechts} par: {par}";
            }

        }
        
        public override bool insert(int _value)
        {
            bool done = false;
            TreeItem newItem = new TreapItem(_value);

            if (binInsert(ref newItem))
            {
                //Sortieren für Prio
                while (newItem != root && (newItem as TreapItem).priority <= (newItem.parent as TreapItem).priority)
                    rotate(newItem as TreapItem);

                done = true;  
            }
            return done;
        }

        public override bool delete(int value)
        {
            if (root == null)
                return false;
            if (search(value))
            {
                TreapItem Item2Del = searchResult as TreapItem;
                if(root.right == null && root.left == null) //Wenn das zu löschende Item das einzige im Baum ist
                {
                    root = null;
                    return true;
                }
                else 
                {
                    while (Item2Del.left != null || Item2Del.right != null) //Zu löschendes Item nach unten rotieren
                    {
                        if (Item2Del.left == null)
                        {
                            rotate(Item2Del.right as TreapItem);
                        }
                        else if (Item2Del.right == null || (Item2Del.left as TreapItem).priority < (Item2Del.right as TreapItem).priority)
                        {
                            rotate(Item2Del.left as TreapItem);
                        }
                        else
                        {
                            rotate(Item2Del.right as TreapItem);
                        }                        
                    }//Item wird gelöscht
                    if(Item2Del.parent.left == Item2Del)
                    {
                        Item2Del.parent.left = null;
                    }
                    else
                    {
                        Item2Del.parent.right = null;
                    }
                    return true;
                }
            }
            else
                return false;
        }
        
        public void rotate(TreapItem item)
        {

            if (item != root as TreapItem)
            {
                bool IsGrandparents_LeftChild = false;
                if (item.parent.parent != null && item.parent.parent.left == item.parent)
                {
                    IsGrandparents_LeftChild = true;
                }


                //ist item linkes Kind, dann Rotation nach rechts
                if (item.parent.left == item)
                {
                    //parent linkes oder rechtes Kind
                    if (item.right != null)
                        item.right.parent = item.parent;
                    item.parent.left = item.right;
                    item.right = item.parent;
                    item.parent = item.right.parent;
                    item.right.parent = item;
                    if (item.parent != null)
                    {
                        if (IsGrandparents_LeftChild)
                            item.parent.left = item;
                        else
                            item.parent.right = item;
                    }
                    else
                        root = item;


                }//ansonsten linksrotieren
                else
                {
                    if (item.left != null)
                        item.left.parent = item.parent;
                    item.parent.right = item.left;
                    item.left = item.parent;
                    item.parent = item.left.parent;
                    item.left.parent = item; 
                    if (item.parent != null)
                    {
                        if (IsGrandparents_LeftChild)
                            item.parent.left = item;
                        else
                            item.parent.right = item;
                    }
                    else
                        root = item;
                }
            }

        }

        

    }
}
