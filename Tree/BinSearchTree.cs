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

        protected TreeItem root = null;
        protected TreeItem parentPointer = null; //Zeiger auf den parent des hinzuzufügenden Blattes aus Search-Fktn
        protected TreeItem searchResult = null; //gesuchtes TreeItem aus Search-Fktn
        protected bool pointerIsLeftChild = false;

        protected bool binInsert(ref TreeItem newItem)
        {
            bool done = false;
            

            if (root == null)
            {
                root = newItem;     //Baum war vorher leer
                done = true;
            }

            else if (search(newItem.value))    //Dieses Element ist bereits im Baum
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
                //HeigthChange(newItem);
            }
            return done;
        }
        public virtual bool insert(int _value)
        {
            TreeItem newItem = new TreeItem(_value);
            return binInsert(ref newItem);
        }

        public virtual bool search(int _value)
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

        //public void HeigthChange(TreeItem item)
        //{
            
        //    if (item != root)
        //    {
        //        if (item == item.parent.left) //item ist linkes Kind
        //        {
        //            item.parent.h_left += 1;
        //        }

        //        else                         //item ist rechtes Kind
        //        {
        //            item.parent.h_right += 1;
        //        }

        //        HeigthChange(item.parent);
        //    }
        //}

        protected void calcHeights()
        {
            calcHeight(root);

            void calcHeight(TreeItem item)
            {
                if (item.left != null)
                {
                    //Hier fertigstellen
                }
            }
        }


        public virtual void print()
        {
            nodePrint(root, 0, "nicht definiert");
        }

        protected void nodePrint(TreeItem node, int level, string richtung)
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

                    if (symm != itemToDelete.left) //Fall 4.1: symm ist nicht direkter linker Nachfolger von itemToDelete
                    {
                        //==> linkes Kind von symm wird symms parent geknüpft (beidseitig))
                        symm.parent.right = symm.left; 

                        if(symm.left != null)
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
            {
                root = ersatz;
            }

            else if (itemToDelete.parent.left == itemToDelete) //Fall 1: itemToDelete ist linkes Kind
            {
                itemToDelete.parent.left = ersatz;
            }
            else //Fall 2: itemToDelete ist rechtes Kind
            {
                itemToDelete.parent.right = ersatz;
            }


            if (ersatz != null)
            {
                if (itemToDelete != root)
                    ersatz.parent = itemToDelete.parent;
                else
                    ersatz.parent = null;



                if (itemToDelete.left != ersatz) //ersatz ist direkter linker Nachfolger von ItemToDelete -> soll nicht auf sich selbst verweisen
                    ersatz.left = itemToDelete.left;

                if(itemToDelete.right != ersatz)
                    ersatz.right = itemToDelete.right;
            }
        }
    }
}
