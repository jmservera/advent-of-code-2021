using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class TestData<T> : IEnumerable<T> , IDisposable
{
    StreamReader reader;
    public TestData(string fileName){
        reader = File.OpenText(fileName);
    }

    public void Close(){
        this.Dispose(true);
    }

    void IDisposable.Dispose()
    {
        Dispose(true);
    }

    ~TestData()
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
    private IEnumerable<T> ReadFile() 
    {
        reader.DiscardBufferedData();
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        while (!reader.EndOfStream)
        {
            yield return (T)Convert.ChangeType(reader.ReadLine(), typeof(T));
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ReadFile().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}