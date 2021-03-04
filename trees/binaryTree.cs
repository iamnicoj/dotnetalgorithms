using System;
using System.Collections;
using System.Collections.Generic;

namespace trees.datastructure
{   
    public class Node<T>
    {
        private T element;

        internal Node<T> Left { get; set; }
        internal Node<T> Right { get; set; }

        public Node(T item)
        {
            element = item;            
        }

        internal T Element
        {
            get { return element; }
            set { element = value; }
        }

    }

    public class BinaryTree<T> 
    {
        public int Count { get; set; }
        private Node<T> Head { get; set; }
        public BinaryTree()
        {
            
        }

        public void Add(T item){
            if (this.Head == null){
                this.Head = new Node<T>(item);                
                return;
            }

            AddInnerTree(Head, item);
        }

        private void AddInnerTree(Node<T> current, T item)
        {
            if(Comparer<T>.Default.Compare(current.Element, item) < 0){
                if(current.Left == null)
                {
                    current.Left = new Node<T>(item);
                    return;
                }                
                AddInnerTree(current.Left, item);
            }                        
            else{
                if(current.Right == null)
                {
                    current.Right = new Node<T>(item);
                    return;
                }                
                AddInnerTree(current.Right, item);
            }
        }

        public void AddBalancedTree(T item){
            if (this.Head == null){
                this.Head = new Node<T>(item);
                return;
            }

            innerAddBalancedTree(this.Head, item);      
        }

        private void innerAddBalancedTree(Node<T> current, T item)
        {
            var value = Comparer<T>.Default.Compare(current.Element, item);

            if(value < 0){
                if (current.Left == null){
                    current.Left = new Node<T>(item);
                }
                else
                    innerAddBalancedTree(current.Left, item);
            }else{
                if (current.Right == null){
                    current.Right = new Node<T>(item);
                }
                else
                    innerAddBalancedTree(current.Right, item);
            }
            // CHECH BALANCE
            var leftLevels = innerLevels(current.Left);
            var rightLevels = innerLevels(current.Right);

            if((leftLevels-rightLevels) == -1)
            {
                if (current.Left == null){
                    var temp = current;
                    current = temp.Right;
                    current.Left = temp;
                }
            }

            if ((leftLevels-rightLevels) > 1){
                var temp = current;
                current = temp.Left;
                temp.Left = current.Right;
                current.Right = temp;
            }
            else if ((leftLevels-rightLevels) < -1){
                var temp = current;
                current = temp.Right;
                temp.Right = current.Left;
                current.Left = temp;
            }
        }

        public T searchRecursive(T item){
            return innerSearchRecursive(this.Head, item);
        }

        public T searchIterative(T item){
            return innerSearchIterative(this.Head, item);
        }
        private T innerSearchRecursive(Node<T> current, T item){
    
            if (current== null) return default(T);

            var comparation = Comparer<T>.Default.Compare(current.Element, item);

            if (comparation == 0) return current.Element;
            else if (comparation < 0) return innerSearchRecursive(current.Left, item);
            else { return innerSearchRecursive(current.Right, item); }
        }

        private T innerSearchIterative(Node<T> current, T item){
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

        private int innerLevels(Node<T> current)
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

         public void InnerPrintLevel(Node<T> current, int level, int elevator){
            if(current == null) return;
            if(level == elevator){
                System.Console.WriteLine("Level {0} Item {1}", level, current.Element.ToString());                
                return;
            }
            InnerPrintLevel(current.Left, level, elevator + 1);
            InnerPrintLevel(current.Right, level, elevator + 1);
        }

        public void PrintInOrder(){
            innerPrintInOrder(this.Head, 1);
        }

        private void innerPrintInOrder(Node<T> current, int level)
        {
            if (current != null){
                innerPrintInOrder(current.Left, level + 1);
                System.Console.WriteLine("Level {0} - Item {1}", level.ToString(), current.Element.ToString());
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