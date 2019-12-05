using CIBDigitalTechAssessment.Abstractions.Bases;

namespace CIBDigitalTechAssessment.Core.Specifications.ViewPhoneBookEntries
{
    public class ViewPhoneBookEntriesSpecifications : ViewSpecificationBase<Views.ViewPhoneBookEntries>
    {
        public ViewPhoneBookEntriesSpecifications(string id="")
            : base(u => !string.Equals(u.EntryId, ""))
        {
            this.ApplyOrderBy(o => o.PersonLastName);
        }

        public ViewPhoneBookEntriesSpecifications(int skip, int take)
            : base(u => u != null)
        {
            this.ApplyOrderBy(o => o.PersonLastName);
            this.ApplyPaging(skip, take);
        }
    }
}