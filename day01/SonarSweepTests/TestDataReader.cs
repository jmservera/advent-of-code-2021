using Xunit;

public class TestDataReader
{
    [Fact]
    public void ReadData()
    {
        using(TestData<int> testData = new TestData<int>("input.txt")){
            var enumerator=testData.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(169, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(150, enumerator.Current);
        }
    }

    [Fact]
    public void ReadAllData(){
        using(TestData<int> testData = new TestData<int>("input.txt")){
            foreach(var i in testData){
                Assert.True(i>0);
            }
        }
    }

    [Fact]
    public void ReadAllDataPlus(){
        using(TestData<int> testData = new TestData<int>("input.txt")){            
            foreach(var i in testData){
                Assert.True(i>0);
            }
            int l=0;
            foreach(var i in testData){
                l++;
                Assert.True(i>0);
            }
            Assert.True(l>0);
        }
    }
}
