﻿using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class BookMappingExtenstions
    {

        public static BookModel ToApiModel(this Book book)
        {
            // TODO: map the Book domain object to a BookModel
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                OriginalLanguage = book.OriginalLanguage,
                PublicationYear = book.PublicationYear,
                PublisherId = book.PublisherId,
                Publisher = book.Publisher != null
                    ? book.Publisher.Name + ", " + book.Publisher.HeadQuartersLocation
                    : null,
                AuthorId = book.AuthorId,
                Author = book.Author != null
                    ? book.Author.LastName + ", " + book.Author.FirstName
                    : null
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            // TODO: map the BookModel to a Book domain object
            return new Book
            {
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
