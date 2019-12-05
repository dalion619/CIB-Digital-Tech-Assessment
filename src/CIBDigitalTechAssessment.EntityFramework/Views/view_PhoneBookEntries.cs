namespace CIBDigitalTechAssessment.EntityFramework.Views
{
    public static class view_PhoneBookEntries
    {
        public static string Drop = $@"DROP VIEW IF EXISTS {nameof(view_PhoneBookEntries)};";

        public static string Create =
            $@"CREATE OR ALTER VIEW {nameof(view_PhoneBookEntries)}
AS
SELECT phoneBookEntry.Id AS 'EntryId', person.PersonId, person.PersonFirstName, person.PersonLastName, phoneBookEntry.PhoneNumber, phoneBookEntry.Description
FROM dbo.PhoneBookEntries phoneBookEntry
INNER JOIN (
	SELECT DISTINCT person.Id AS 'PersonId', person.FirstName AS 'PersonFirstName', person.LastName AS 'PersonLastName'
	FROM dbo.People person
	GROUP BY person.Id, person.FirstName, person.LastName
) person ON phoneBookEntry.PersonId=person.PersonId 
GO";
    }
}