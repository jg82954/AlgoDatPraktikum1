using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    public class BinSearchTree : IDictionary
    {
        public class TreeItem
        {
            public int value; // -> Wert des Knotens
            public TreeItem left = null;
            public TreeItem right = null;

            //public int h = 0;
            public int h_right = 0;
            public int h_left = 0;
            public TreeItem elter = null;

            public TreeItem(int _item)
            {
                value = _item;
            }
        }

        TreeItem root = null;
        TreeItem parentPointer = null; //Zeiger auf den parent des hinuzufügenden Blattes aus Search-Fktn
        TreeItem searchResult = null; //gesuchtes TreeItem aus Search-Fktn

        bool pointerIsLeftChild = false;

        public bool insert(int _value)
        {
            bool done = false;
            TreeItem newItem = new TreeItem(_value);

            if (root == null)
            {
                root = newItem;     //Baum war vorher leer
                done = true;
            }

            else if (search(_value))    //Dieses Element ist bereits im Baum
                Console.WriteLine("Element bereits im Baum enthalten!\n");

            else                    //Element kommt noch nicht vor -> soll tatsächlich eingefügt werden
            {
                //Neu
                
                if (pointerIsLeftChild)
                {
                    newItem = parentPointer.left;
                }

                else
                {
                    newItem = parentPointer.right;
                }

                done = true;
                newItem.elter = parentPointer;
                heigthChange(newItem);
            }
            return done;
        }

        public bool search(int _value)
        {
            TreeItem current_item = root;
            bool found = false;
            bool treeCompleted = false;

            do
            {
                if (_value == current_item.value)       //currentItem hat die gesuchte Value
                {
                    searchResult = current_item;
                    found = true;
                    return found;
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

            return found;
        }

        public void heigthChange(TreeItem item)
        {
            
            if (item != root)
            {
                if (item == item.elter.left) //item ist linkes Kind
                {
                    item.elter.h_left += 1;
                }

                else                         //item ist rechtes Kind
                {
                    item.elter.h_right += 1;
                }

                heigthChange(item.elter);
            }
        }

        
        public void print()
        {

        }

        public bool delete(int _value)
        {
            return true;
        }
    }

    //class BinTree
    //{
    //    class BItem
    //    {
    //        public int number;
    //        public BItem left, right = null;

    //        public BItem(int Number) { number = Number; }

    //        public override string ToString()
    //        {
    //            string lString = (left == null) ? "null" : left.number.ToString();
    //            string rString = (right == null) ? "null" : right.number.ToString();

    //            return $"{lString} <-- {number} --> {rString}";
    //        }
    //    }

    //    BItem root = null; //oberstes Element

    //    public void BInsert(int Number)
    //    {
    //        BItem newItem = new BItem(Number);

    //        if (root == null)   //Tree war vorher noch leer
    //            root = newItem;

    //        else
    //        {
    //            bool done = false;
    //            BItem item = root;

    //            do
    //            {
    //                if (Number < item.number)    //linker Teilbaum --> neue Zahl gehört links unter item
    //                {
    //                    if (item.left == null)
    //                    {
    //                        item.left = newItem;
    //                        done = true;
    //                    }
    //                    else
    //                        item = item.left;
    //                }
    //                else                        //rechter Teilbaum
    //                {
    //                    if (item.right == null)
    //                    {
    //                        item.right = newItem;
    //                        done = true;
    //                    }
    //                    else
    //                        item = item.right;
    //                }
    //            } while (!done);
    //        }
    //    }

    //    public bool FindItem(int Number)
    //    {
    //        BItem item = root;

    //        while (item != null)
    //        {
    //            if (Number == item.number) //Gesuchte Nummer gefunden
    //                return true;

    //            item = (Number < item.number) ? item.left : item.right; //gehen wir nach links oder nach rechts weiter?
    //        }
    //        return false;
    //    }

    //    public void InOrderPrint() { InOrderPrint(root); }

    //    private void InOrderPrint(BItem item)
    //    { //kleiner -- item -- größer
    //        if (item != null)
    //        {
    //            if (item.left != null)
    //            {
    //                InOrderPrint(item.left);
    //            }
    //            Console.Write(item.number + "  "); // das soll erst ausgegeben werden, wenn kein kleineres Kinderelement gefunden wird

    //            if (item.right != null)
    //            {
    //                InOrderPrint(item.right);
    //            }

    //        }
    //    }
    //}

}
