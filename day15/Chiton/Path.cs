using System;
using System.Collections.Generic;
using System.Linq;

using Priority_Queue;

namespace Day15.Chiton
{
    public class Node:FastPriorityQueueNode{
        public Node up,down,left,right;
        public int x,y,value;

        public Node(int x, int y, int value){
            this.x = x;
            this.y = y;
            this.value=value;
        }

        public override string ToString(){
            return $"({x},{y}):{value}";
        }

        public override int GetHashCode()
        {
            return x*10000+ y;
        }
    }
    public class Path
    {

        Node[][] nodes;

        public Path(int[][] originalData, bool expand = false)
        {
            generateMap(originalData, expand);
        }
        void generateMap(int[][] data, bool expand)
        {
            int iterations=expand?5:1;
            nodes= new Node[data.Length * iterations ][];

            for (int i = 0; i < iterations; i++)
            {
                for (int x = 0; x < data.Length; x++)
                {
                    var xpos=x + i * data.Length;
                    nodes[xpos] = new Node[data[0].Length * iterations];
                    for (int j = 0; j < iterations; j++)
                    {
                        for (int y = 0; y < data[0].Length; y++)
                        {
                            var ypos=y + j * data[0].Length;
                            var value = ( data[x][y] + i + j) - (((data[x][y] + i + j - 1) / 9) * 9);
                            nodes[xpos][ypos] = new Node(xpos ,ypos,value);
                        }
                    }
                }
            }

            for(int x=0;x<nodes.Length;x++){
                for(int y=0;y<nodes[x].Length;y++){
                    var node=nodes[x][y];
                    if(x>0){
                        node.left=nodes[x-1][y];
                    }
                    if(y>0){
                        node.up=nodes[x][y-1];
                    }
                    if(x<nodes.Length-1){
                        node.right=nodes[x+1][y];
                    }
                    if(y<nodes[x].Length-1){
                        node.down=nodes[x][y+1];
                    }
                }
            }   
        }
        public long LowestRisk()
        {
            Console.WriteLine($"{nodes.Length}x{nodes[0].Length}");
            return lowerRisk();
        }

        long lowerRisk()
        {
            var priorityQueue = new FastPriorityQueue<Node>(nodes.Length * nodes[0].Length);

            for(int x=0;x<nodes.Length;x++){
                for(int y=0;y<nodes[0].Length;y++){
                    priorityQueue.Enqueue(nodes[x][y],int.MaxValue);
                }
            }
            priorityQueue.UpdatePriority(nodes[0][0],0);

            while(priorityQueue.Count>0){
                if(priorityQueue.Count%1000==0){
                    Console.Write($"{priorityQueue.Count}.");
                }
                var current = priorityQueue.Dequeue();

                var x = current.x;
                var y = current.y;
                var value = (int)current.Priority;
                if(x==nodes.Length-1 && y==nodes[0].Length-1){
                    return value;
                }
                if(x>0){             
                    var node=current.left;       
                    if(priorityQueue.Contains(node)){
                        var newValue = value + node.value;
                        if(newValue<node.Priority){
                            priorityQueue.UpdatePriority(node,newValue);                            
                        }
                    }
                }
                if(y>0){
                    var node=current.up;       
                    if(priorityQueue.Contains(node)){
                        var newValue = value + node.value;
                        if(newValue<node.Priority){
                            priorityQueue.UpdatePriority(node,newValue);                            
                        }
                    }
                }
                if(x<nodes.Length-1){
                     var node=current.right;       
                    if(priorityQueue.Contains(node)){
                        var newValue = value + node.value;
                        if(newValue<node.Priority){
                            priorityQueue.UpdatePriority(node,newValue);                            
                        }
                    }
                }
                if(y<nodes[0].Length-1){
                    var node=current.down;       
                    if(priorityQueue.Contains(node)){
                        var newValue = value + node.value;
                        if(newValue<node.Priority){
                            priorityQueue.UpdatePriority(node,newValue);                            
                        }
                    }
                }
            }

            //not found
            return -1;
        }
    }
}
