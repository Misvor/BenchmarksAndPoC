using System.Text;

namespace ReadExcelAndParseToScript;

public static class StringBuildingExtensions
{
    public static string FormComplaintString(this StringBuilder sb, string name, int order, string complaintCategoryName, string sysname, string testSample)
    {
        return sb.Append("""
                         UPDATE dbo.Complaints WITH (UPDLOCK, SERIALIZABLE)
                         SET Sysname='
                         """)
            .Append(sysname)
            .Append("""', TestSample='""")
            .Append(testSample)
            .Append("""' WHERE Name=N'""")
            .Append(name)
            .Append("""' AND [Order]=""")
            .Append(order)
            .Append(""" AND TestSample='""")
            .Append(testSample)
            .Append("""
                    ';

                    IF @@ROWCOUNT = 0
                        BEGIN
                            INSERT dbo.Complaints(ComplaintId, Name, ComplaintCategoryId, CreateDateUtc, [Order], TestSample, Sysname)
                            SELECT ComplaintId = NEWID(), Name = N'
                    """)
            .Append(name)
            .Append("""', ComplaintCategoryId = @""")
            .Append(complaintCategoryName)
            .Append(""", CreateDateUtc = GETDATE(), [Order] = """)
            .Append(order)
            .Append(""", TestSample = '""")
            .Append(testSample)
            .Append("""', Sysname = '""")
            .Append(sysname)
            .Append("""
                    ';
                        END

                    """)
            .ToString();
    }
    
    public static string FormComplaintCategoryString(this StringBuilder sb, string name, string description, int order, string testSample)
    {
        return sb.Append("""

                         UPDATE dbo.ComplaintCategories WITH (UPDLOCK, SERIALIZABLE)
                         SET TestSample='
                         """)
            .Append(testSample)
            .Append("""', Description=N'""")
            .Append(description)
            .Append("""' WHERE Name='""")
            .Append(name)
            .Append("""' AND [Order]=""")
            .Append(order)
            .Append(""" AND TestSample='""")
            .Append(testSample)
            .Append("""
                    ';

                    IF @@ROWCOUNT = 0
                        BEGIN
                            INSERT dbo.ComplaintCategories(Name, Description, CreateDateUtc, [Order], TestSample)
                            SELECT Name = '
                    """)
            .Append(name)
            .Append("""', Description = N'""")
            .Append(description)
            .Append("""', CreateDateUtc = GETDATE(), [Order] = """)
            .Append(order)
            .Append(""", TestSample = '""")
            .Append(testSample)
            .Append("""
                    ';
                        END

                    """)
            .ToString();
    }
}