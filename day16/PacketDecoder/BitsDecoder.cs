namespace Day16.PacketDecoder;
public class BitsDecoder
{
    string data;
    int index;
    public BitsDecoder(string data)
    {
        this.data = data;
    }

    public Packet Decode(){
        index=0;
        return DecodeData();
    }

    private Packet DecodeData()
    {
        var header = GetHeader(data);
        var packet=new Packet(){Version=header.Item1, Type=header.Item2};
        
        switch(packet.Type){
            case 4:
                packet.Data=decodeLiteral();
                break;
            default:
                packet.Packets=DecodeDataOperator(packet);
                break;
        }
        return packet;
    }

    private Packet[]? DecodeDataOperator(Packet packet)
    {
        List<Packet> packets=new List<Packet>();
        if(data[index]=='0'){
            //15 bits
            var subLength= Convert.ToInt32(data.Substring(index+1,15),2);
            index+=16;
            var oldIndex=index;
            do{
                packets.Add(DecodeData());
            }while(index<oldIndex+subLength);
        }
        else{
            //11 bits
            var subLength= Convert.ToInt32(data.Substring(index+1,11),2);
            index+=12;
            for(int i=0;i<subLength;i++){
                packets.Add(DecodeData());
            }
        }
        return packets.ToArray();
    }

    private long decodeLiteral(){
        var bits="";
        long result=0;
        for(;index<data.Length;index+=5){
            bits+=data.Substring(index+1, 4);
            if(data[index]=='0'){
                result= Convert.ToInt64(bits,2);
                index+=5;
                break;
            }
        }
        
        return result;
    }

    public (int,int) GetHeader(string data){
        int version= Convert.ToInt32(data.Substring(index,3), 2);
        int type= Convert.ToInt32(data.Substring(index+3,3), 2);
        index+=6;
        return (version,type);
    }

}
