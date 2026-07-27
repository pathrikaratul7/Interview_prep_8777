namespace Interview_prep_8777
{
    public class MSSQL
    {
        #region Banking Database

        /*
        Banking Database
        ----------------

        Customer
        -------------------------
        CustomerId
        CustomerName
        Mobile
        City

        Account
        -------------------------
        AccountId
        CustomerId
        AccountType
        Balance

        Transaction
        -------------------------
        TransactionId
        AccountId
        Amount
        TransactionType
        TransactionDate

        Branch
        -------------------------
        BranchId
        BranchName
        City
        */

        #endregion

        #region 1. Primary Key

        /*
        Interview Question

        What is a Primary Key?

        Answer

        A Primary Key uniquely identifies every row in a table.

        Rules
        -----
        • Cannot contain NULL
        • Cannot contain Duplicate values

        Practical Example

        CREATE TABLE Customer
        (
            CustomerId INT PRIMARY KEY,
            CustomerName VARCHAR(100),
            Mobile VARCHAR(10)
        );

        Insert

        INSERT INTO Customer
        VALUES
        (1,'Rahul','9999999999');

        Trying Duplicate

        INSERT INTO Customer
        VALUES
        (1,'Amit','8888888888');

        Output

        Violation of PRIMARY KEY constraint.

        Banking Example

        CustomerId uniquely identifies every customer.
        */

        #endregion

        #region 2. Foreign Key

        /*
        Practical Example

        CREATE TABLE Account
        (
            AccountId INT PRIMARY KEY,
            CustomerId INT,
            Balance MONEY,

            FOREIGN KEY(CustomerId)
            REFERENCES Customer(CustomerId)
        );

        INSERT INTO Account
        VALUES
        (101,1,25000);

        Trying

        INSERT INTO Account
        VALUES
        (102,50,1000);

        Output

        Customer 50 doesn't exist.

        Foreign Key Constraint Failed
        */

        #endregion

        #region 3. INNER JOIN

        /*
        Requirement

        Display Customer Name and Balance.

        SELECT
            C.CustomerName,
            A.Balance
        FROM Customer C
        INNER JOIN Account A
            ON C.CustomerId = A.CustomerId;

        Output

        Rahul    25000
        Amit     50000
        */

        #endregion

        // Continue the remaining topics exactly the same...
        #region 4. LEFT JOIN

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is LEFT JOIN?

        ===========================================================
        ANSWER
        ===========================================================

        LEFT JOIN returns all records from the left table and
        matching records from the right table.

        If there is no matching record, NULL is returned.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Display all customers whether they have opened
        an account or not.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        SELECT
            C.CustomerName,
            A.AccountId,
            A.Balance
        FROM Customer C
        LEFT JOIN Account A
        ON C.CustomerId = A.CustomerId;

        ===========================================================
        OUTPUT
        ===========================================================

        Rahul      101      25000
        Amit       102      40000
        Ramesh     NULL     NULL

        ===========================================================
        INTERVIEW TIP
        ===========================================================

        LEFT JOIN always returns all rows from the LEFT table.

        */
        #endregion

        #region 5. GROUP BY

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is GROUP BY?

        ===========================================================
        ANSWER
        ===========================================================

        GROUP BY groups rows having the same values into one group.

        It is commonly used with aggregate functions.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Find total balance city-wise.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        SELECT
            C.City,
            SUM(A.Balance) AS TotalBalance
        FROM Customer C
        INNER JOIN Account A
        ON C.CustomerId=A.CustomerId
        GROUP BY C.City;

        ===========================================================
        OUTPUT
        ===========================================================

        Pune        75000
        Mumbai      35000

        ===========================================================
        COMMON FUNCTIONS
        ===========================================================

        SUM()
        AVG()
        MIN()
        MAX()
        COUNT()

        */
        #endregion

        #region 6. HAVING

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        Difference between WHERE and HAVING?

        ===========================================================
        ANSWER
        ===========================================================

        WHERE filters rows before grouping.

        HAVING filters groups after GROUP BY.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Show cities having total balance greater than 50000.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        SELECT
            City,
            SUM(Balance) TotalBalance
        FROM Customer C
        INNER JOIN Account A
        ON C.CustomerId=A.CustomerId
        GROUP BY City
        HAVING SUM(Balance)>50000;

        ===========================================================
        OUTPUT
        ===========================================================

        Pune    75000

        */
        #endregion

        #region 7. Stored Procedure

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Stored Procedure?

        ===========================================================
        ANSWER
        ===========================================================

        A Stored Procedure is a precompiled collection of SQL
        statements stored inside SQL Server.

        ===========================================================
        ADVANTAGES
        ===========================================================

        ✔ Better Performance

        ✔ Reusable

        ✔ Secure

        ✔ Easy Maintenance

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Deposit Money

        ===========================================================
        SQL SCRIPT
        ===========================================================

        CREATE PROC usp_DepositMoney
        (
            @AccountId INT,
            @Amount MONEY
        )
        AS
        BEGIN

        UPDATE Account
        SET Balance=Balance+@Amount
        WHERE AccountId=@AccountId;

        END

        ===========================================================
        EXECUTE
        ===========================================================

        EXEC usp_DepositMoney
        @AccountId=101,
        @Amount=5000;

        ===========================================================
        OUTPUT
        ===========================================================

        Balance Updated Successfully.

        */
        #endregion

        #region 8. Transaction

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Transaction?

        ===========================================================
        ANSWER
        ===========================================================

        A Transaction is a group of SQL statements executed
        as one unit.

        ===========================================================
        ACID PROPERTIES
        ===========================================================

        Atomicity

        Consistency

        Isolation

        Durability

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Transfer money from Account A to Account B.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        BEGIN TRAN

        UPDATE Account
        SET Balance=Balance-5000
        WHERE AccountId=101;

        UPDATE Account
        SET Balance=Balance+5000
        WHERE AccountId=102;

        COMMIT;

        IF @@ERROR<>0
        BEGIN
            ROLLBACK;
        END

        ===========================================================
        INTERVIEW ANSWER
        ===========================================================

        Money should never be debited without being credited.

        */
        #endregion

        #region 9. Trigger

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Trigger?

        ===========================================================
        ANSWER
        ===========================================================

        A Trigger executes automatically when
        INSERT, UPDATE or DELETE occurs.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Maintain Account History.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        CREATE TABLE AccountHistory
        (
            AccountId INT,
            OldBalance MONEY,
            ModifiedDate DATETIME
        );

        CREATE TRIGGER TR_AccountHistory
        ON Account
        AFTER UPDATE
        AS

        INSERT INTO AccountHistory
        SELECT
        D.AccountId,
        D.Balance,
        GETDATE()
        FROM deleted D;

        ===========================================================
        INTERVIEW TIP
        ===========================================================

        Triggers are commonly used for

        Audit

        Logging

        History

        Validation

        */
        #endregion

        #region 10. Index

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        Why do we use Index?

        ===========================================================
        ANSWER
        ===========================================================

        Indexes improve query performance.

        ===========================================================
        WITHOUT INDEX
        ===========================================================

        SQL scans every row.

        Table Scan

        ===========================================================
        WITH INDEX
        ===========================================================

        SQL directly locates the required rows.

        Index Seek

        ===========================================================
        SQL SCRIPT
        ===========================================================

        CREATE NONCLUSTERED INDEX IX_Account
        ON Account(AccountId);

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Searching Account Number among 50 lakh records.

        Without Index : Slow

        With Index : Fast

        ===========================================================
        INTERVIEW FOLLOW-UP
        ===========================================================

        Types

        Clustered

        Non-Clustered

        Composite

        Filtered

        Covering

        */
        #endregion

        #region 11. ROW_NUMBER()

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is ROW_NUMBER()?

        ===========================================================
        ANSWER
        ===========================================================

        Assigns unique row numbers.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Latest transaction per account.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        SELECT *
        FROM
        (
        SELECT *,
        ROW_NUMBER() OVER
        (
        PARTITION BY AccountId
        ORDER BY TransactionDate DESC
        )RN
        FROM Transaction
        )A
        WHERE RN=1;

        */
        #endregion

        #region 12. CTE

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is CTE?

        ===========================================================
        ANSWER
        ===========================================================

        CTE stands for Common Table Expression.

        It is a temporary result set.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Customers having balance above average.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        WITH AvgBalance
        AS
        (
        SELECT AVG(Balance) AvgBal
        FROM Account
        )

        SELECT *
        FROM Account
        CROSS JOIN AvgBalance
        WHERE Balance>AvgBal;

        ===========================================================
        ADVANTAGES
        ===========================================================

        Readable

        Recursive Queries

        Better Organization

        */
        #endregion

        #region 13. Dynamic SQL

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Dynamic SQL?

        ===========================================================
        ANSWER
        ===========================================================

        Dynamic SQL is SQL generated at runtime.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        DECLARE @TableName VARCHAR(50)

        SET @TableName='Customer'

        EXEC('SELECT * FROM '+@TableName)

        Safer Version

        EXEC sp_executesql
        N'SELECT *
        FROM Customer
        WHERE CustomerId=@Id',
        N'@Id INT',
        @Id=1;

        ===========================================================
        INTERVIEW TIP
        ===========================================================

        Prefer sp_executesql to avoid SQL Injection.

        */
        #endregion

        #region 14. Execution Plan

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Execution Plan?

        ===========================================================
        ANSWER
        ===========================================================

        Execution Plan shows how SQL Server executes a query.

        ===========================================================
        LOOK FOR
        ===========================================================

        Table Scan

        Index Scan

        Index Seek

        Key Lookup

        Hash Match

        Nested Loop

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Customer Search taking 20 seconds.

        Execution Plan shows Table Scan.

        Create Index.

        Query becomes faster.

        */
        #endregion

        #region 15. Deadlock

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Deadlock?

        ===========================================================
        ANSWER
        ===========================================================

        Deadlock occurs when two transactions wait for each
        other forever.

        SQL Server kills one transaction.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Transaction A

        Locks Customer

        Waiting Account

        Transaction B

        Locks Account

        Waiting Customer

        Deadlock occurs.

        ===========================================================
        PREVENTION
        ===========================================================

        Access tables in same order.

        Keep transactions short.

        Proper indexes.

        */
        #endregion

        #region 16. Parameter Sniffing

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is Parameter Sniffing?

        ===========================================================
        ANSWER
        ===========================================================

        SQL Server creates an execution plan based on the
        first parameter value.

        Sometimes the same plan becomes inefficient for
        other parameter values.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        usp_SearchCustomer

        First execution

        City='Pune'

        Creates execution plan.

        Second execution

        City='Nagpur'

        Same execution plan reused.

        Performance may become slow.

        ===========================================================
        SOLUTION
        ===========================================================

        OPTION(RECOMPILE)

        OPTIMIZE FOR

        Update Statistics

        */
        #endregion

        #region 17. MERGE

        /*
        ===========================================================
        INTERVIEW QUESTION
        ===========================================================

        What is MERGE?

        ===========================================================
        ANSWER
        ===========================================================

        MERGE performs INSERT, UPDATE and DELETE
        in one statement.

        ===========================================================
        BANKING EXAMPLE
        ===========================================================

        Synchronize Daily Account Records.

        ===========================================================
        SQL SCRIPT
        ===========================================================

        MERGE TargetAccount T
        USING SourceAccount S
        ON T.AccountId=S.AccountId

        WHEN MATCHED THEN
        UPDATE
        SET Balance=S.Balance

        WHEN NOT MATCHED THEN
        INSERT(AccountId,Balance)
        VALUES(S.AccountId,S.Balance);

        ===========================================================
        ADVANTAGES
        ===========================================================

        Single Statement

        Better Synchronization

        Useful in ETL

        SQL Server System-Versioned Temporal Tables

SQL Server also provides a built-in feature called System-Versioned Temporal Tables.

CREATE TABLE Customer
(
    CustomerId INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Mobile VARCHAR(20),

    ValidFrom DATETIME2 GENERATED ALWAYS AS ROW START,
    ValidTo DATETIME2 GENERATED ALWAYS AS ROW END,

    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
)
WITH
(
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = dbo.CustomerHistory
    )
);

SQL Server automatically stores previous versions of rows in the history table whenever data changes.

Advantages
Complete audit trail
Recover previous values
Regulatory compliance
Data recovery
Useful for reporting
Supports auditing and troubleshooting
Interview Questions
Why do banks maintain history tables?

Answer: To maintain an audit trail, comply with regulations, recover previous data, and know who changed what and when.

Which approach is better?

Answer:

Stored Procedure + History Table → Most common in enterprise banking applications because it provides full control over business logic.
System-Versioned Temporal Tables → Excellent when automatic row version history is sufficient and your SQL Server version supports it.
Can we use the OUTPUT clause instead of a trigger?

Yes. The OUTPUT clause can capture old (deleted) and new (inserted) values during INSERT, UPDATE, or DELETE operations and insert them directly into a history table. This is often preferred over triggers because the logic is explicit and easier to maintain.

Example:

UPDATE Customer
SET Mobile = '9999999999'
OUTPUT
    deleted.CustomerId,
    deleted.CustomerName,
    deleted.Mobile,
    'UPDATE',
    GETDATE()
INTO CustomerHistory
(
    CustomerId,
    CustomerName,
    Mobile,  
    ActionType,
    ActionDate
)
WHERE CustomerId = 101;

This is a clean and efficient approach when the history needs to be captured as part of the update operation.




        ===========================================================
        INTERVIEW NOTE
        ===========================================================

        Be cautious when using MERGE in production. Test thoroughly,
        as older SQL Server versions have had bugs related to MERGE.
        In some cases, separate INSERT, UPDATE, and DELETE statements
        can be a safer choice.



        */
        #endregion
        #region Interview Revision Notes

        /*
        For every MSSQL topic remember:

        ✔ Interview Definition
        ✔ Real Banking Scenario
        ✔ Database Design
        ✔ Sample Data
        ✔ SQL Script
        ✔ Output
        ✔ Interview Explanation
        ✔ Performance Notes
        ✔ Common Mistakes
        ✔ Follow-up Interview Questions
        ✔ Production Best Practices
        */

        #endregion
    }
}