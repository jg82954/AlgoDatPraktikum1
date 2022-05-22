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
            public TreeItem parent = null;

            public TreeItem(int _item)
            {
                value = _item;
            }

            public override string ToString()
            {
                return $"{value} l:{h_left} r:{h_right}";
            }
        }

        TreeItem root = null;
        TreeItem parentPointer = null; //Zeiger auf den parent des hinzuzufügenden Blattes aus Search-Fktn
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
                if (pointerIsLeftChild)
                {
                    parentPointer.left = newItem;
                }

                else
                {
                    parentPointer.right = newItem;
                }

                done = true;
                newItem.parent = parentPointer;
                HeigthChange(newItem);
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

        public void HeigthChange(TreeItem item)
        {
            
            if (item != root)
            {
                if (item == item.parent.left) //item ist linkes Kind
                {
                    item.parent.h_left += 1;
                }

                else                         //item ist rechtes Kind
                {
                    item.parent.h_right += 1;
                }

                HeigthChange(item.parent);
            }
        }

        public void print()
        {
            nodePrint(root, 0, "nicht definiert");
        }

        private void nodePrint(TreeItem node, int level, string richtung)
        {
            if (node != null)
            {
                nodePrint(node.right, level + 1, "rechts");
                indentPrint(node, level, richtung);
                nodePrint(node.left, level + 1, "links");
            }
        }

        private void indentPrint(TreeItem node, int level, string richtung)
        {
            if (level == 0) //der zu printende Konten ist root
            {
                Console.WriteLine(node);
            }

            else if (level == 1)
                if (richtung == "rechts")
                    Console.WriteLine("    /-- " + node);
                else
                    Console.WriteLine("    \\-- " + node);
            else
            {
                for (int i = 0; i < level - 1; i++)
                {
                    Console.Write("       ");
                }
                if (richtung == "rechts")
                    Console.WriteLine("    /-- " + node);
                else
                    Console.WriteLine("    \\-- " + node);
            }
        }
        
        public virtual bool delete(int delValue) //offizielle delete-Funktion, returnt true sobald das Element erfolgreich gelöscht wurde
        {
            TreeItem deletedItem = delete_(delValue);

            if (deletedItem == null) //zu löschendes Item wurde nicht im Baum gefunden
                return false;
            else                     //Item wurde erfolgreich gelöscht
                return true;
        }

        protected TreeItem delete_(int delValue)
        {
            if (!search(delValue)) //Fall 1: itemToDelete existiert nicht
                return null;

            else
            {
                TreeItem itemToDelete = searchResult;
                if (itemToDelete.left == null && itemToDelete.right == null) //Fall 2: itemToDelete ist ein Blatt (hat keine Nachfolger)
                    ErsetzeZuLoeschendenKnoten(itemToDelete, null);


                else if (itemToDelete.left == null || itemToDelete.right == null) //Fall 3: itemToDelete hat genau einen Nachfolger
                {
                    if (itemToDelete.left != null) //Fall 3.1: itemToDelete hat linkes Kind
                        ErsetzeZuLoeschendenKnoten(itemToDelete, itemToDelete.left);

                    else //Fall 3.2: itemToDelete hat linkes Kind
                        ErsetzeZuLoeschendenKnoten(itemToDelete, itemToDelete.right);
                }

                else //Fall 4: itemToDelete hat genau zwei Nachfolger
                {
                    TreeItem symm = itemToDelete.left; //Initialisierung des symmetrischen Vorgängers

                    while (symm.right != null)
                        symm = symm.right;

                    //TreeItem symmParent = symm.parent;




                    if (symm != itemToDelete.left) //Fall 4.1: symm ist nicht direkter linker Nachfolger von itemToDelete
                    {
                        symm.parent.right = symm.left;
                        symm.left.parent = symm.parent;
                    }

                    ErsetzeZuLoeschendenKnoten(itemToDelete, symm);



                }
                return itemToDelete;
            }
        }

        public void ErsetzeZuLoeschendenKnoten(TreeItem itemToDelete, TreeItem ersatz)
        {
            if (itemToDelete == root)
                root = ersatz;

            else if (pointerIsLeftChild) //Fall 1: itemToDelete ist linkes Kind
            {
                itemToDelete.parent.left = ersatz;
                ersatz.parent = itemToDelete.parent;

            }
            else //Fall 2: itemToDelete ist rechtes Kind
            {
                itemToDelete.parent.right = ersatz;
                ersatz.parent = itemToDelete.parent;
            }
        }

        public int BerechneKnotenhoehe(TreeItem item)
        {
            return 0;
        }
    }
}
