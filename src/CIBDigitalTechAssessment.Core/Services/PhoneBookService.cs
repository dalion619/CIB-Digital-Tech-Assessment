using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Abstractions.Interfaces;
using CIBDigitalTechAssessment.Core.Extensions;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Specifications.ViewPhoneBookEntries;
using CIBDigitalTechAssessment.Entities;
using CIBDigitalTechAssessment.ResponseModels.Common;
using CIBDigitalTechAssessment.ResponseModels.PhoneBook;
using CIBDigitalTechAssessment.Utilities;
using CIBDigitalTechAssessment.Views;

namespace CIBDigitalTechAssessment.Core.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IViewRepository<ViewPhoneBookEntries> _viewRepositoryPhoneBookEntries;
        private readonly IEntityRepository<PhoneBookEntry> _entityRepositoryPhoneBookEntry;

        public PhoneBookService(IEntityRepository<PhoneBookEntry> entityRepositoryPhoneBookEntry,
                                IViewRepository<ViewPhoneBookEntries> viewRepositoryPhoneBookEntries)
        {
            _viewRepositoryPhoneBookEntries = viewRepositoryPhoneBookEntries;
            _entityRepositoryPhoneBookEntry = entityRepositoryPhoneBookEntry;
        }

        public async Task AddPerson(string firstName, string lastName, string phoneNumber, string description)
        {
            var phoneBookEntry = new PhoneBookEntry()
                                 {
                                     PhoneNumber = phoneNumber,
                                     Description = description,
                                     Person = new Person()
                                              {
                                                  FirstName = firstName,
                                                  LastName = lastName
                                              }
                                 };
           await _entityRepositoryPhoneBookEntry.AddAsync(phoneBookEntry);
        }

        public async Task<PaginationResponseModel<PhoneBookResponseModel, AlphaPaginationMetaResponseModel>>
            ListPhoneBook(int currentPageNumber)
        {
            var phoneBookEntriesSpec = new ViewPhoneBookEntriesSpecifications();
            var phoneBookEntries = await _viewRepositoryPhoneBookEntries.ListAsync(phoneBookEntriesSpec);

            var list = phoneBookEntries.GroupBy(g => g.PersonId)
                                       .Select(s =>
                                       {
                                           var person = s.FirstOrDefault();
                                           var model = person.ToPhoneBookResponseModel();
                                           model.Id = person.PersonId;
                                           model.FirstName = person.PersonFirstName;
                                           model.LastName = person.PersonLastName;
                                           model.Entries =
                                               s.ToList().Select(e =>
                                                   e.ToPhoneBookEntryResponseModel()).ToList();
                                           return model;
                                       }).ToList();

            var dataList = new List<PhoneBookResponseModel>();
            var groupings = new List<int>();
            for (int i = 0; i < AlphaPagination.AlphaArray.Length; i++)
            {
                var letter = AlphaPagination.AlphaArray[i].ToString();
                var result = list.FirstOrDefault(f => string.Equals(f.LastName.Substring(0, 1),
                    letter, StringComparison.InvariantCultureIgnoreCase));
                if (result != null)
                {
                    var pageNumber = AlphaPagination.LettersToPageNumber(letter) * 100;
                    groupings.Add(pageNumber);
                    if (currentPageNumber == pageNumber && currentPageNumber % 100 == 0)
                    {
                        dataList.AddRange(list.FindAll(f => string.Equals(f.LastName.Substring(0, 1),
                            letter, StringComparison.InvariantCultureIgnoreCase)));
                    }
                }
            }

            var pageListings = new List<int>();
            for (int i = 0; i < AlphaPagination.AlphaArray.Length; i++)
            {
                int currentPrimaryPageNumber = currentPageNumber / 100;
                var letter = AlphaPagination.PageNumberToLetters(currentPrimaryPageNumber) +
                             AlphaPagination.AlphaArray[i].ToString();
                var result = list.FirstOrDefault(f => string.Equals(f.LastName.Substring(0, 2),
                    letter, StringComparison.InvariantCultureIgnoreCase));
                if (result != null)
                {
                    pageListings.Add(AlphaPagination.LettersToPageNumber(letter));
                    if (currentPageNumber       == AlphaPagination.LettersToPageNumber(letter) &&
                        currentPageNumber % 100 != 0)
                    {
                        dataList.AddRange(list.FindAll(f => string.Equals(f.LastName.Substring(0, 2),
                            letter, StringComparison.InvariantCultureIgnoreCase)));
                    }
                }
            }

            var paginatedPhoneBook =
                new PaginationResponseModel<PhoneBookResponseModel, AlphaPaginationMetaResponseModel>();

            var paginationMeta = new AlphaPaginationMetaResponseModel(groupings, pageListings);
            paginationMeta.PageNumber = currentPageNumber;
            paginationMeta.TotalItems = list.Count;

            paginatedPhoneBook.Meta = paginationMeta;
            paginatedPhoneBook.Data = dataList;
            return paginatedPhoneBook;
        }
    }
}