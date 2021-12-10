using System.IO;
public class DataLoader{
    public static int[][] LoadData(string path){
        string[] lines= File.ReadAllLines(path);
        int[][] result= new int[lines.Length][];
        for(int i=0;i<lines.Length;i++){
            result[i]= new int[lines[i].Length];
            for(int j=0;j<lines[i].Length;j++){
                result[i][j]=lines[i][j]=='1'?1:0;
            }
        }
        return result;
    }
}