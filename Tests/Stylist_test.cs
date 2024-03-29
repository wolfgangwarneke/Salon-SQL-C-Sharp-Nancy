using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      Stylist testStylist = new Stylist("John", 1);
      Stylist secondTestStylist = new Stylist("John", 1);

      Assert.Equal(testStylist, secondTestStylist);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Stylist testStylist = new Stylist("Carly");
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist>{testStylist};

      Assert.Equal(testStylistList, result);
    }
    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Jeremiah");
      testStylist.Save();
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_Update_UpdatesStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Sofia");
      testStylist.Save();
      testStylist.Update("Sophie");
      string result = testStylist.GetName();

      Assert.Equal("Sophie", result);
    }
    [Fact]
    public void Test_Delete_RemoveStylistFromDatabase()
    {
      Stylist testStylist1 = new Stylist("Barb");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Chaz");
      testStylist2.Save();

      testStylist1.Delete();
      List<Stylist> resultStylist = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist2};

      Assert.Equal(testStylistList, resultStylist);
    }
  }
}
