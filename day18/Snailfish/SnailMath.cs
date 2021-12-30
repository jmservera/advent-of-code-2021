using System.Text;
using System;

namespace Day18.Snailfish;

    public enum SnailNodeType{
        Array,
        Number
    }
    public class SnailNode{
        public SnailNodeType Type {get; private set;}
        public int Value {get;set;}

        public int Level {get;set;}

        public SnailNode? Left {get;set;}
        public SnailNode? Right {get;set;}

        public SnailNode? Up {get;set;}

        public SnailNode(int value){
            this.Type = SnailNodeType.Number;
            this.Value = value;
        }

        public SnailNode(SnailNode? left, SnailNode? right){
            this.Type = SnailNodeType.Array;
            this.Left = left;
            if(left!=null){
                left.Up=this;
            }
            this.Right = right;
            if(right!=null){
                right.Up=this;
            }
        }

        public override string ToString(){
            if(this.Type == SnailNodeType.Number){
                return $"{this.Value}";
            }
            return $"[{this.Left},{this.Right}]";
        }

        public static SnailNode Parse(string input, int level=0){
            SnailNode? left,right=null;

            if(input[0]!='['){
                var pair=input.Split(',',2);

                left=new SnailNode(int.Parse(pair[0])){Level = level};

                if(pair.Length==2){
                    right=Parse(pair[1],level+1);
                }               
            }
            else{
                int endIndex=1;
                int countBrackets=0;
                
                do{
                    if(input[endIndex]=='['){
                        countBrackets++;
                    }
                    if(input[endIndex]==']'){
                        countBrackets--;
                    }                
                    endIndex++;
                }while(countBrackets>0);

                left=Parse(input.Substring(1,endIndex-1),level+1);
                //remember to remove comma
                right=Parse(input.Substring(endIndex+1,input.Length-endIndex-2),level+1);
            }

            if(right!=null)
                return new SnailNode(left,right){Level = level};
            else
                return left;
        }

        public void RecalcLevels(){
            if(this.Type == SnailNodeType.Number){
                return;
            }
            if(this.Left!=null){
                this.Left.Level = this.Level+1;
                this.Left.RecalcLevels();
            }
            if(this.Right!=null){
                this.Right.Level = this.Level+1;
                this.Right.RecalcLevels();
            }
        }
    }

public class SnailMath
{
    public string Sum(string left, string right){
        var sum=SimpleSum(left,right);
        while(true){
            var exploded=Explode(sum);
            if(exploded!=sum){
                sum=exploded;
                continue;
            }

            var splitted=Split(exploded);
            if(splitted!=exploded){
                sum=splitted;
                continue;
            }
            return splitted;
        }
    }

    public int Magnitude(string input)
    {
        var node=SnailNode.Parse(input);
        return magnitude(node);
    }

    public int MaxSum(string[] lines)
    {
        var max=0;
        for(int i=0;i<lines.Length;i++){
            for(int j=i+1;j<lines.Length;j++){
                var sum=Sum(lines[i],lines[j]);
                var magnitude=Magnitude(sum);
                if(magnitude>max){
                    max=magnitude;
                }
                sum=Sum(lines[j],lines[i]);
                magnitude=Magnitude(sum);
                if(magnitude>max){
                    max=magnitude;
                }
            }
        }
        return max;
    }

    private int magnitude(SnailNode node)
    {
        if(node.Type==SnailNodeType.Number){
            return node.Value;
        }

        if(node.Left!=null && node.Right!=null){
            return magnitude(node.Left)*3+magnitude(node.Right)*2;
        }
        
        throw new InvalidOperationException("node has no pair");
    }

    public string Split(string number)
    {
        int i=0;
        while(i<number.Length-1){
            if(char.IsDigit(number[i])){
                int start=i;
                while(char.IsDigit(number[i])){
                    i++;
                }
                int n=int.Parse(number.Substring(start,i-start));
                if(n>=10){
                    int n1=n/2;
                    int n2=n-n1;
                    return $"{number.Substring(0,start)}[{n1},{n2}]{number.Substring(i)}" ;
                }
            }
            i++;
        }
        
        return number;
    }

    public string SimpleSum(string left, string right){
        return $"[{left},{right}]";
    }

    public string Explode(string input)
    {
        int level=0;

        for(int i=0;i<input.Length;i++){
            if(input[i]=='['){
                level++;
            }
            else if(input[i]==']'){
                level--;
            }
            if(level==5){
                return explode(input,i);
            }
        }
        return input;
    }

    string explode(string input, int position){
        StringBuilder sb=new StringBuilder();
        int i=position;
        while(input[i]!=']'){
            i++;
        }
        int endIndex=i;
        while(input[i]!='['){
            i--;
        }
        int startIndex=i;
        var numbers=input.Substring(startIndex+1,endIndex-startIndex-1).Split(',');

        //find leftmost
        i=startIndex;
        while(i>0 && !char.IsDigit(input[i])){
            i--;
        }
        if(i>0){
            int leftEndIndex=i;
            while(char.IsDigit(input[i])){
                i--;
            }
            int leftStartIndex=i;
            sb.Append(input.Substring(0,leftStartIndex+1));
            int leftValue=int.Parse(input.Substring(leftStartIndex+1,leftEndIndex-leftStartIndex))+int.Parse(numbers[0]);
            sb.Append(leftValue.ToString());
            sb.Append(input.Substring(leftEndIndex+1,startIndex-leftEndIndex-1));
        }
        else{
            sb.Append(input.Substring(0,startIndex));
        }
        sb.Append("0");

        //find rightmost
        i=endIndex;
        while(i<input.Length && !char.IsDigit(input[i])){
            i++;
        }
        if(i<input.Length){
            int rightStartIndex=i;
            while(char.IsDigit(input[i])){
                i++;
            }
            int rightEndIndex=i;
            sb.Append(input.Substring(endIndex+1,rightStartIndex-endIndex-1));
            int rightValue=int.Parse(input.Substring(rightStartIndex,rightEndIndex-rightStartIndex))+int.Parse(numbers[1]);
            sb.Append(rightValue.ToString());
            sb.Append(input.Substring(rightEndIndex,input.Length-rightEndIndex));
        }
        else{
            sb.Append(input.Substring(endIndex+1,input.Length-endIndex-1));
        }
        return sb.ToString();

    }
}
