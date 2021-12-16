using System;
using System.Collections.Generic;

namespace Day12.PassagePathing
{
    public class CaveNode
    {
        public string Name {get; private set;}
        public List<CaveNode> Neighbors {get; private set;}
        public CaveNode(string name){
            this.Name=name;
        }

        public void AddNeighbor(CaveNode node){
            if(this.Neighbors == null){
                this.Neighbors = new List<CaveNode>();
            }
            if(!this.Neighbors.Contains(node)){
                this.Neighbors.Add(node);
            }
        }
    }
}