namespace Proj2;

public class DependencyInversionPrinciple
{
    
}

public interface IDatabaseService
{
    void SaveToDb();
}

public class SQLDatabase : IDatabaseService
{
    public void SaveToDb()
    {
        Console.WriteLine("Save to SQL DB");
    }
}

public class MongoDBDatabase : IDatabaseService
{
    public void SaveToDb()
    {
        Console.WriteLine("Save to MongoDB");
    }
}

// Here user will not directly toak to SQL or MongoDB service rather it will talk to an intermediate layer using interface

/*
 Here Open-Closed principle will also be entacted because let's say in future we want to save details to a new database,
 then we will just add class for that database which will implement IDatabaseService and we do not have to modify any
 existing class
 
 Quote
 "" If open-closed principle is the target then dependency inversion principle is the solution ""
 */
public class UserService
{
    private IDatabaseService _databaseService;  // has-a relationship

    public UserService(IDatabaseService databaseService)  // dependency injection
    {
        _databaseService = databaseService;
    }

    public void StoreUser()
    {
        _databaseService.SaveToDb();
    }
}