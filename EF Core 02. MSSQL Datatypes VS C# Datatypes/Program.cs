// MSSQL Datatypes VS C# Datatypes

// https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver17
// https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

/*
SQL Server                              C#

int                                     int     (Int32)
bigint                                  long    (Int64)
smallint                                short   (Int16)
tinyint                                 byte    (Byte)

bit                                     bool    (Boolean)

float                                   double  (Double)
real                                    float   (Single)

decimal                                 decimal (Decimal)
numeric                                 decimal (Decimal)

money                                   decimal (Decimal)
smallmoney                              decimal (Decimal)

char                                    string  (String)
varchar                                 string  (String)
nchar                                   string  (String)
nvarchar                                string  (String)
text                                    string  (String)
ntext                                   string  (String)

date                                    DateTime
datetime                                DateTime
datetime2                               DateTime
smalldatetime                           DateTime
time                                    TimeSpan
datetimeoffset                          DateTimeOffset

binary                                  byte[]
varbinary                               byte[]
image                                   byte[]

uniqueidentifier                        Guid
 
*/
