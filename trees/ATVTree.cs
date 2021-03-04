using System;
using System.Collections;
using System.Collections.Generic;

namespace trees.datastructure
{   
    public class AVTNode<T>
    {
        private T element;

        internal AVTNode<T> Left { get; set; }
        internal AVTNode<T> Right { get; set; }

        internal int BalanceFactor { get; set; }

        public AVTNode(T item)
        {
            element = item;            
        }

        internal T Element
        {
            get { return element; }
            set { element = value; }
        }
    }

    public class AVTBinaryTree<T> 
    {
        public int Count { get; set; }
        private AVTNode<T> Head { get; set; }
        public AVTBinaryTree()
        {
            
        }

        public void Add(T item){
            if (this.Head == null){
                this.Head = new AVTNode<T>(item);
                return;
            }
            innerAddBalancedTree(this.Head, item);      
        }

        private void innerAddBalancedTree(AVTNode<T> current, T item)
        {
            var value = Comparer<T>.Default.Compare(current.Element, item);

            if(value > 0){
                if (current.Left == null){
                    current.Left = new AVTNode<T>(item);
                }
                else{
                    innerAddBalancedTree(current.Left, item);
                }
            }else{
                if (current.Right == null){
                    current.Right = new AVTNode<T>(item);
                }
                else{
                    innerAddBalancedTree(current.Right, item);
                }
            }

            current.BalanceFactor = this.innerLevels(current.Right) - this.innerLevels(current.Left);

            // CHECH BALANCE            
            AVTNode<T> temp = null;
            switch (current.BalanceFactor)
            {
                case 2:
                    if(current.Right != null){
                        // Left-Rotation
                        // 2, 1
                        if(current.Right.BalanceFactor == 1){
                            temp = current;
                            current = temp.Right;
                            temp.Right = current.Left;
                            current.Left = temp;
                            temp.BalanceFactor -= 2;
                            current.BalanceFactor--;
                        }
                        // Right-Left
                        // 2, -1
                        else if (current.Right.BalanceFactor == -1){
                            temp = current;
                            current = temp.Right.Left;
                            temp.Right.Left = current.Right;
                            current.Right = temp.Right;
                            temp.Right = current.Left;
                            current.Left = temp;
                            temp.BalanceFactor -= 2;
                            current.Right.BalanceFactor++;
                        }
                    }
                    break;
                case -2:
                    if(current.Left != null){
                        // Left-Right
                        // -2, 1
                        if(current.Left.BalanceFactor == 1){
                            temp = current;
                            current = temp.Left.Right;
                            temp.Left.Right = current.Left;
                            current.Left = temp.Left;
                            temp.Left = current.Left;
                            current.Right = temp;
                            temp.BalanceFactor += 2;
                            current.Left.BalanceFactor--;
                        }
                        // Right-Rotation
                        // -2, -1
                        else if (current.Left.BalanceFactor == -1){
                            temp = current;
                            current = temp.Left;
                            temp.Left = current.Right;
                            current.Right = temp;
                            temp.BalanceFactor += 2;
                            current.BalanceFactor++;
                        }
                    }                
                break;

                default:
                break;
            }         
            
            // current.BalanceFactor = this.innerLevels(current.Right) - this.innerLevels(current.Left);
            // if(temp!= null)
            // {
            // temp.BalanceFactor = this.innerLevels(temp.Right) - this.innerLevels(temp.Left);
                
            // }


        }

        public T searchRecursive(T item){
            return innerSearchRecursive(this.Head, item);
        }

        public T searchIterative(T item){
            return innerSearchIterative(this.Head, item);
        }
        private T innerSearchRecursive(AVTNode<T> current, T item){
    
            if (current== null) return default(T);

            var comparation = Comparer<T>.Default.Compare(current.Element, item);

            if (comparation == 0) return current.Element;
            else if (comparation < 0) return innerSearchRecursive(current.Left, item);
            else { return innerSearchRecursive(current.Right, item); }
        }

        private T innerSearchIterative(AVTNode<T> current, T item){
            if (current== null) return default(T);

            while(current != null){                
                var comparation = Comparer<T>.Default.Compare(current.Element, item);
                switch (comparation)
                {
                    case 0:
                        return current.Element;
                    case -1:
                        current = current.Left;
                        break;
                    default:
                        current = current.Right;
                        break;
                }
            }
            return default(T);
        }

        // TODO
        public bool RemoveItem(T item){
            return false;
        }

        public int Levels(){
            return innerLevels(this.Head);
        }

        private int innerLevels(AVTNode<T> current)
        {
            // Empty case
            if(current == null) return 0;
            // Leaf case
            else if (current.Left == null && current.Right == null) return 1;

            var levelLeft = innerLevels(current.Left);
            var levelRight = innerLevels(current.Right);

            return (levelLeft > levelRight ? levelLeft + 1 : levelRight + 1);
        }

        public void PrintByLevel(){
            for(int i = 1; i <= this.Levels(); i++){
                InnerPrintLevel(this.Head, i, 1);
            }
        }

         public void InnerPrintLevel(AVTNode<T> current, int level, int elevator){
            if(current == null) return;
            if(level == elevator){
                System.Console.WriteLine("Level {0} Item {1} BalanceFactor {2}", level, current.Element.ToString(), current.BalanceFactor.ToString());                
                return;
            }
            InnerPrintLevel(current.Left, level, elevator + 1);
            InnerPrintLevel(current.Right, level, elevator + 1);
        }

        public void PrintInOrder(){
            innerPrintInOrder(this.Head, 1);
        }

        private void innerPrintInOrder(AVTNode<T> current, int level)
        {
            if (current != null){
                innerPrintInOrder(current.Left, level + 1);
                System.Console.WriteLine("Level {0} - Item {1} -  BalanceFactor {2}", level.ToString(), current.Element.ToString(), current.BalanceFactor);
                innerPrintInOrder(current.Right, level + 1);
            }
        }

        public List<T>  InOrderTransverse(){
            return null;
        }

        // TODO
        public void BalanceTree(){

        }
    }
}