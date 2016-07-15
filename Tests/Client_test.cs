using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      Client testClient = new Client("John", 1, 1);
      Client secondTestClient = new Client("John", 1, 1);

      Assert.Equal(testClient, secondTestClient);
    }
    [Fact]
    public void Test_Save_SavesClientToDatabase()
    {
      Client testClient = new Client("Carly", 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testClientList = new List<Client>{testClient};

      Assert.Equal(result, testClientList);
    }
    // [Fact]
    // public void Test_Find_FindsClientInDatabase()
    // {
    //   Client testClient = new Client("Jeremiah", 1);
    //   testClient.Save();
    //   Client foundClient = Client.Find(testClient.GetId());
    //
    //   Assert.Equal(testClient, foundClient);
    // }
    // [Fact]
    // public void Test_Update_UpdatesClientInDatabase()
    // {
    //   Client testClient = new Client("Sofia", 1);
    //   testClient.Save();
    //   testClient.Update("Sophie");
    //   string result = testClient.GetName();
    //
    //   Assert.Equal("Sophie", result);
    // }
    // [Fact]
    // public void Test_Delete_RemoveClientFromDatabase()
    // {
    //   Client testClient1 = new Client("Barb", 1);
    //   testClient1.Save();
    //   Client testClient2 = new Client("Chaz", 1);
    //   testClient2.Save();
    //
    //   testClient1.Delete();
    //   List<Client> resultClient = Client.GetAll();
    //   List<Client> testClientList = new List<Client> {testClient2};
    //
    //   Assert.Equal(testClientList, resultClient);
    // }
  }
}
