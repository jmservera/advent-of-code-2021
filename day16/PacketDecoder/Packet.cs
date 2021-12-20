namespace Day16.PacketDecoder;

public class Packet
{
    public int Version { get; set; }
    public int Type { get; set; }
    public long Data { get; set; }

    public Packet[]? Packets { get; set; }

    public int SumVersions()
    {
        int version = this.Version;
        if (Packets != null)
        {
            foreach (var packet in Packets)
            {
                version += packet.SumVersions();
            }
        }
        return version;
    }

    public long Calculate()
    {
        long result = 0;
        switch (Type)
        {
            case 0:
                {
                    if (Packets != null)
                    {
                        foreach (var packet in Packets)
                        {
                            result += packet.Calculate();
                        }
                    }
                    break;
                }
            case 1:
                {
                    result = 1;
                    if (Packets != null)
                    {
                        foreach (var packet in Packets)
                        {
                            result *= packet.Calculate();
                        }
                    }
                    break;
                }
            case 2:
                {
                    if (Packets != null)
                    {
                        result = long.MaxValue;
                        foreach (var packet in Packets)
                        {
                            result = Math.Min(result, packet.Calculate());
                        }
                    }
                    break;
                }
            case 3:
                {
                    if (Packets != null)
                    {
                        result = long.MinValue;
                        foreach (var packet in Packets)
                        {
                            result = Math.Max(result, packet.Calculate());
                        }
                    }
                    break;
                }
            case 4:
                {
                    result = Data;
                    break;
                }
            case 5:
                {
                    if (Packets != null)
                    {
                        result = Packets[0].Calculate() > Packets[1].Calculate() ? 1 : 0;
                    }
                    break;
                }
            case 6:
                {
                    if (Packets != null)
                    {
                        result = Packets[0].Calculate() < Packets[1].Calculate() ? 1 : 0;
                    }
                    break;
                }
            case 7:
                {
                    if (Packets != null)
                    {
                        result = Packets[0].Calculate() == Packets[1].Calculate() ? 1 : 0;
                    }
                    break;
                }


        }
        return result;
    }
}