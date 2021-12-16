using System;
using System.Collections.Generic;

namespace Day12.PassagePathing
{
    public class Cave
    {
        Dictionary<string, CaveNode> nodes=new Dictionary<string, CaveNode>();
        public Cave(string[][] paths){
            foreach(var path in paths){
                var from = path[0];
                var to = path[1];
                if(!nodes.ContainsKey(from)){
                    nodes.Add(from, new CaveNode(from));
                }
                if(!nodes.ContainsKey(to)){
                    nodes.Add(to, new CaveNode(to));
                }
                var node1 = nodes[from];
                var node2 = nodes[to];
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
            }
        }

        public int CountPaths(){         
            return CountPaths(nodes["start"]);
        }

        public int CountPaths2(){
            return CountPaths2(nodes["start"]);
        }
        public int CountPaths(CaveNode node){
            var count=0;
            foreach(var neighbor in node.Neighbors){
                count+=countR(neighbor,new List<string>(new string[]{node.Name}));
            }
            return count;
        }

        public int CountPaths2(CaveNode node){
            var count=0;
            foreach(var neighbor in node.Neighbors){
                count+=countR2(neighbor,new List<string>(new string[]{node.Name}));
            }
            return count;
        }
        int countR(CaveNode node, List<string> visited){
            if(node.Name=="start"){
                return 0;
            }
            if(node.Name=="end"){
                return 1;
            }
            if(char.IsLower(node.Name[0])){

                if(visited.Contains(node.Name)){
                    //invalid path
                    return 0;
                }
                else{
                    visited.Add(node.Name);
                }
            }

            var count=0;

            foreach(var neighbor in node.Neighbors){
                var partial=countR(neighbor,new List<string>(visited));
                count+=partial;
            }  
            return count;
        }

        int countR2(CaveNode node, List<string> visited, string doubleVisited=""){
            if(node.Name=="start"){
                return 0;
            }
            if(node.Name=="end"){
                return 1;
            }
            if(char.IsLower(node.Name[0])){

                if(visited.Contains(node.Name)){
                    //invalid path
                    if(doubleVisited==""){
                        doubleVisited=node.Name;
                    }
                    else                 
                        return 0;
                }
                else{
                    visited.Add(node.Name);
                }
            }

            var count=0;

            foreach(var neighbor in node.Neighbors){
                var partial=countR2(neighbor,new List<string>(visited),doubleVisited);
                count+=partial;
            }  
            return count;
        }

    }
}
