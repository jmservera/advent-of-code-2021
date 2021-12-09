using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class DataReader : IEnumerable<(string,int)> , IDisposable
{
    StreamReader reader;
    public DataReader(string fileName){
        reader = File.OpenText(fileName);
    }

    public void Close(){
        this.Dispose(true);
    }

    void IDisposable.Dispose()
    {
        Dispose(true);
    }

    ~DataReader()
    {
        Dispose(false);
    }    
    
    void Dispose(bool disposing)
    {
        if (disposing)
        {
            reader.Dispose();
        }
        GC.SuppressFinalize(this);
    }

    private IEnumerable<(string,int)> ReadFile() 
    {
        reader.DiscardBufferedData();
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            var l= line.Split(' ');

            yield return (l[0], int.Parse(l[1]));
        }
    }

    public IEnumerator<(string,int)> GetEnumerator() => ReadFile().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}